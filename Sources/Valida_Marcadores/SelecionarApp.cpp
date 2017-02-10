#include "SelecionarApp.h"

using namespace std;
using namespace cv;

Mat img, img_copy, img_backup, img_polys, img_contours, img_fill;
Point pt1;
Point pt2;
Scalar color(0, 0, 255);
vector<Point> points;
vector<Point> points_backup;
vector<vector<Point> >polygons;

int dist = 0;
bool mouse_down = 0;

bool isInsidePoly(Point point, Mat& img_polys) {
	
    Vec3b color_px = img_polys.at<Vec3b>(point);
    if (color_px.val[0] != 0) {
        return true;
    }
    return false;
}

Rect findBbox(vector<Point> poly) {

	Point min = Point(img.cols, img.rows);
	Point max = Point(0, 0);

	for (int i = 0; i < poly.size(); i++) {
		if (poly[i].x <= min.x) {
			min.x = poly[i].x;
		}
		else if (poly[i].x >= max.x) {
			max.x = poly[i].x;
		}
		if (poly[i].y <= min.y) {
			min.y = poly[i].y;
		}
		else if (poly[i].y >= max.y) {
			max.y = poly[i].y;
		}
	}

	return Rect(min, max);
}

void drawLinesImg(Mat& img, vector<Point> points) {
	for (size_t i = 0; i < points.size() - 1; i++) {
		line(img, points[i], points[i + 1], color, 2);
	}
}

void waterToWhite(Mat& img, Mat& preenchido, Mat& contorno) {

	cout << "Executando waterToWhite..." << endl;

	Mat sohAgua;
	Mat azulNaoAgua;

	Mat imgClone = img.clone();

	medianBlur(img, imgClone, 15);

	inRange(imgClone, Scalar(130, 0, 0), Scalar(255, 255, 255), sohAgua);
	inRange(imgClone, Scalar(115, 175, 115), Scalar(196, 246, 193), azulNaoAgua);

	cvtColor(sohAgua, sohAgua, COLOR_GRAY2BGR);
	cvtColor(azulNaoAgua, azulNaoAgua, COLOR_GRAY2BGR);

	bitwise_and(imgClone, sohAgua, sohAgua);
	bitwise_and(imgClone, azulNaoAgua, azulNaoAgua);

	dilate(sohAgua, sohAgua, Mat(), Point(-1, -1), 2);
	// Utiliza duas vezes porque como a imagem azulNaoAgua nao eh branco pode acontecer de ficar alguns 
	// pixels livres e nao ficar totalmente preto assim fazendo o cotorno errado para os pr�ximos passos
	sohAgua = sohAgua - azulNaoAgua;
	cvtColor(azulNaoAgua, azulNaoAgua, CV_BGR2GRAY);
	threshold(azulNaoAgua, azulNaoAgua, 110, 255, THRESH_BINARY);
	cvtColor(azulNaoAgua, azulNaoAgua, CV_GRAY2BGR);

	sohAgua = sohAgua - azulNaoAgua;
	cvtColor(sohAgua, sohAgua, CV_BGR2GRAY);
	vector<vector <Point> > contours;

	findContours(sohAgua, contours, CV_RETR_TREE, CV_CHAIN_APPROX_SIMPLE, Point(0, 0));

	Mat drawing = Mat::zeros(sohAgua.size(), CV_8UC3);

	for (int k = 0; k < contours.size(); k++) {
		if (contourArea(contours[k]) > 1000) {
			drawContours(drawing, contours, k, Scalar(255, 255, 255), 1, 8);
		}
	}

	for (int i = 0; i < contours.size(); i++) {
		if (cv::contourArea(contours[i]) > 1000) {
			bool naoAchouPonto = true;
			for (int y = 0; (y < drawing.rows && naoAchouPonto); y++) {
				for (int x = 0; (x < drawing.cols && naoAchouPonto); x++) {
					if (pointPolygonTest(contours[i], Point(x, y), false) > 0) {
						floodFill(drawing, Point(x, y), Scalar(255, 255, 255));
						//drawing.at<cv::Vec3b>(y, x)[1] = 255;
						naoAchouPonto = false;
					}
				}
			}
		}
	}

	preenchido = drawing;
	dilate(drawing, contorno, Mat(), Point(-1, -1), 2);
	contorno = contorno - drawing;
}

void CallBackFunc(int event, int xMouse, int yMouse, int flags, void* userdata) {

	if (event == EVENT_LBUTTONUP) {
		cout << "EVENT_LBUTTONUP" << endl;
		mouse_down = false;

		pt1 = points[0];
		pt2 = Point(xMouse, yMouse);

		points.push_back(pt2);

		line(img_copy, pt1, pt2, color, 2);

		polygons.push_back(points);
		
		imshow("Selecionar Rio", img_copy);
	}

	// Iniciou
	if (event == EVENT_LBUTTONDOWN) {
		cout << "EVENT_LBUTTONDOWN" << endl;
		mouse_down = true;

		// Primeiro ponto do poligono
		points.clear();
		points.push_back(Point(xMouse, yMouse));
	}

	// Adicionando pontos no poligono
	if (event == EVENT_MOUSEMOVE && mouse_down) {

		// Último ponto adicionado no poligono
		pt1 = points[points.size() - 1];

		pt2 = Point(xMouse, yMouse);

		dist = ((pt1.x - pt2.x)*(pt1.x - pt2.x)) + ((pt1.y - pt2.y)*(pt1.y - pt2.y));

		if (dist > 30) {
			
			line(img_copy, pt1, pt2, color, 2);
			
			imshow("Selecionar Rio", img_copy);

			if (dist > 80) {
				points.push_back(pt2);
			}

		}
	}

	// Removendo todos os pontos 
	if (event == EVENT_RBUTTONUP) {

		for (int i = 0; i < polygons.size(); i++) {
			polygons[i].clear();
		}
		
		img_copy = img.clone();

		imshow("Selecionar Rio", img_copy);
	}

}

void doMagic(Mat& img, Mat& img_fill, Mat& img_contours, Mat& img_polys) {

	cout << "Executando doMagic..." << endl;

	Mat river_contour, river_fill, river_app;
	Point pt;
	Vec3b color_px;

	river_contour = img_contours.clone();
	river_fill = img_fill.clone();

	int dilation_type = MORPH_ELLIPSE; //MORPH_RECT; //MORPH_ELLIPSE;
	int dilation_size = 18;

	Mat element = getStructuringElement(
		dilation_type,
		Size(2 * dilation_size + 1, 2 * dilation_size + 1),
		Point(dilation_size, dilation_size));

	// dilata a imagem contorno salvando em contornoDilatado, com os parametros de element
	dilate(river_contour, river_contour, element);

	// para ficar só com a parte de fora do contorno dilatado
	river_app = river_contour - river_fill;

	// Sobrepor na imagem original
	for (int y = 0; y < river_app.rows; y++) 
	{
		for (int x = 0; x < river_app.cols; x++) 
		{
			color_px = river_app.at<Vec3b>(Point(x, y));
			if (color_px.val[0] != 0) 
			{
				img.at<Vec3b>(y, x)[0] = saturate_cast<uchar>(53);
				img.at<Vec3b>(y, x)[1] = saturate_cast<uchar>(90);
				img.at<Vec3b>(y, x)[2] = saturate_cast<uchar>(40);
			}
		}
	}

	// Adicionar as nascentes capturadas previamente
	vector<Circle> circles = getCirculosCapturados("../config/NascentesReais.txt");

	for (int i = 0; i < circles.size(); i++)
	{
		// circle outline
		circle(img, circles[i].center, circles[i].radius, Scalar(53, 90, 40), -1, 8, 0);
		// circle center
		circle(img, circles[i].center, 3, Scalar(153, 0, 0), -1, 8, 0);
	}
	
}

Mat executeSelecionarApp() 
{
	string PATH = "../resources/rios/";//"C:/Users/joao_/Desktop/testes/";
	string img_name = PATH + "rio.png";//"teste_002.png";

	img = imread(img_name);

	if (!img.data) {
		cout << "Could not open or find the image" << endl;
		return img ;
	}
		
	img_copy = img.clone();

	// Transforma os locais com agua em branco
    waterToWhite(img, img_fill, img_contours);
                            
    doMagic(img, img_fill, img_contours, img_polys);

	return img;

}
