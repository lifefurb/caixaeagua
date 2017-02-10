#define M_PI 3.14159265358979323846  /* pi */
#define _USE_MATH_DEFINES
#include <math.h>
#include <limits>

#include "opencv2/imgcodecs.hpp"
#include "opencv2/imgproc/imgproc.hpp"
#include "opencv2/highgui/highgui.hpp"
#include <iostream>
#include <fstream>
#include <string>
#include <cmath>

#include "SelecionarApp.h"
#include "EncontrarCirculos.h"
#include "SaveHeadwaters.h"

using namespace std;
using namespace cv;

// http://answers.opencv.org/question/73016/how-to-overlay-an-png-image-with-alpha-channel-to-another-png/
// http://jepsonsblog.blogspot.com.br/2012/10/overlay-transparent-image-in-opencv.html
void overlayImage(Mat* src, Mat* overlay, const Point& location)
{
	for (int y = max(location.y, 0); y < src->rows; ++y)
	{
		int fY = y - location.y;

		if (fY >= overlay->rows)
			break;

		for (int x = max(location.x, 0); x < src->cols; ++x)
		{
			int fX = x - location.x;

			if (fX >= overlay->cols)
				break;

			double opacity = ((double)overlay->data[fY * overlay->step + fX * overlay->channels() + 3]) / 255;

			for (int c = 0; opacity > 0 && c < src->channels(); ++c)
			{
				unsigned char overlayPx = overlay->data[fY * overlay->step + fX * overlay->channels() + c];
				unsigned char srcPx = src->data[y * src->step + x * src->channels() + c];
				src->data[y * src->step + src->channels() * x + c] = srcPx * (1. - opacity) + overlayPx * opacity;
			}
		}
	}
}

double distanceBetween(Point &pontoA, Point &pontoB) {
	return sqrt(((pontoA.x - pontoB.x)*(pontoA.x - pontoB.x)) + ((pontoA.y - pontoB.y)*(pontoA.y - pontoB.y)));
}

bool estahNaApp(Mat& app, Circle& circulo, Rect& retangulo) {

	Point ponto;
	double distancia;

	for (int y = retangulo.y; y < retangulo.y + retangulo.height; y++) {
		for (int x = retangulo.x; x < retangulo.x + retangulo.width; x++) {

			if (app.at<Vec3b>(y, x)[0] == 53 && app.at<Vec3b>(y, x)[1] == 90 && app.at<Vec3b>(y, x)[2] == 40) {
				ponto.x = x;
				ponto.y = y;
				distancia = distanceBetween(circulo.center, ponto);
				if (distancia <= circulo.radius) {
					return true;
				}
			}
		}
	}
	return false;
}

int aula3() {

	vector<Circle> circles = getCirclesRealTime();

	// Gravar as nascentes em arquivos
	saveHeadwaterToSandbox(circles);
    saveHeadwaterToSelecionarAPP(circles);
    
	return 0;	

}

int aula4() {
	
	vector<Circle> circles = getCirclesRealTime();
	
	Mat img = executeSelecionarApp();
	
	if (!img.data) {
		cout << "Could not open or find the image" << endl;
		return -1 ;
	}	

	// ---------------------------------------------------------------------------------------
	// ## Melhorar (repete o mesmo processo da aula 5)... Validando os pontos de APP 
	Rect border = getBorderOfTheBox();

	// Definindo as escalas das imagens
	Scale origin(Point(0, 0), Point(border.width, border.height));
	Scale destiny(Point(0, 0), Point(1024, 768));

	// Convertendo os pontos da escala da imagem de entrada para a imagem da APP
	for (int i = 0; i < circles.size(); i++) {
		Point p = convertTo(origin, destiny, circles[i].center);
		circles[i].center = p;
		circles[i].radius = 15;
	}

	//drawCircles(circles, img);

	// Imagens para representar os locais certos e errados
	string PATH = "../resources/rios/";
	Mat correctImage = imread(PATH + "correct_image.png", CV_LOAD_IMAGE_UNCHANGED);
	Mat errorImage = imread(PATH + "error_image.png", CV_LOAD_IMAGE_UNCHANGED);
	
	int x, y;
	Rect rect;
	vector<Rect> rects;
	
	for (int i = 0; i < circles.size(); i++) {

		rect.x = (int)(circles[i].center.x - circles[i].radius);
		rect.y = (int)(circles[i].center.y - circles[i].radius);
		rect.width = (int)(2 * (circles[i].radius));
		rect.height = rect.width;

		rects.push_back(rect);
	}

	for (int i = 0; i < rects.size(); i++) {
		if (estahNaApp(img, circles[i], rects[i])) {
			x = circles[i].center.x - correctImage.size().width / 2;
			y = circles[i].center.y - correctImage.size().height / 2;
			overlayImage(&img, &correctImage, Point(x, y));
		} else {
			x = circles[i].center.x - errorImage.size().width / 2;
			y = circles[i].center.y - errorImage.size().height / 2;
			overlayImage(&img, &errorImage, Point(x, y));
		}
	}
	// ---------------------------------------------------------------------------------------

	namedWindow("Areas de APP", CV_WINDOW_NORMAL);
	setWindowProperty("Areas de APP", CV_WND_PROP_FULLSCREEN, CV_WINDOW_FULLSCREEN);
    imshow("Areas de APP", img);

	cout << "pressionou o ESC finalizando..." << endl;

	waitKey(0);

	return 0;
}

int aula5() {

	string PATH = "../resources/rios/";
	string img_name = PATH + "app.png";

	Mat img_original;
	Mat img_median;
	Mat img_app;

	Rect rect;

	vector<Circle> circles_original;
	vector<Circle> circles_median;
	vector<Circle> circles;
	vector<Rect> rects;

	vector<vector <Circle> > all_circles;

	// Imagem da App gerada previamente
	img_app = executeSelecionarApp();

	cout << "Executou o selecionar a APP" << endl;

	// Lendo imagem capturada pela webcam do Kinect
	int index = getIndexCamera();
	img_original = getImgsCamera(1, index)[0];//imread(img_name, IMREAD_COLOR);

	if (!img_app.data) {
		cout << "nao foi possivel carregar a imagem da APP!" << endl;
		return -1;
	}

	if (!img_original.data) {
		cout << "nao foi possivel capturar os circulos!" << endl;
		return -1;
	}	
	
	// Criando um retangulo com os pontos da calibracao do mundo
	Rect border = getBorderOfTheBox(); //Rect(74, 97, 481 - 74, 392 - 97);

	// Desenha o retangulo na imagem de entrada (debug)
	//rectangle(src, borda, Scalar(0, 0, 255));

	// Redimensionando a imagem para o mesmo tamanho da imagem da APP (debug)
	//resize(src, src, Size(1024, 768));

	// limitando a imagem apenas a area de projecao
	img_original = img_original(border);

	medianBlur(img_original, img_median, 5);
	
	// Encontrando os circulos das imagens
	circles_original = getCircles(img_original, 24, 100, 42, 10, 35);
	circles_median = getCircles(img_median, 24, 100, 42, 10, 35);

	all_circles.push_back(circles_original);
	all_circles.push_back(circles_median);

	circles = mergeCircles(all_circles);

	// Desenhando os circulos encontrados na imagem de entrada
	drawCircles(circles_original, img_original);

	// Desenhando os circulos encontrados na imagem de entrada com mediana
	drawCircles(circles_median, img_median);

	// Definindo as escalas das imagens
	Scale origin(Point(0, 0), Point(border.width, border.height));
	Scale destiny(Point(0, 0), Point(1024, 768));

	// Convertendo os pontos da escala da imagem de entrada para a imagem da APP
	for (int i = 0; i < circles.size(); i++) {
		Point p = convertTo(origin, destiny, circles[i].center);
		circles[i].center = p;
		circles[i].radius = 25;
	}

	// Imagens para representar os locais certos e errados
	Mat correctImage = imread(PATH + "correct_image.png", CV_LOAD_IMAGE_UNCHANGED);
	Mat errorImage = imread(PATH + "error_image.png", CV_LOAD_IMAGE_UNCHANGED);
	
	int x, y;

	for (int i = 0; i < circles.size(); i++) {

		rect.x = (int)(circles[i].center.x - circles[i].radius);
		rect.y = (int)(circles[i].center.y - circles[i].radius);
		rect.width = (int)(2 * (circles[i].radius));
		rect.height = rect.width;

		rects.push_back(rect);
	}

	for (int i = 0; i < rects.size(); i++) {
		if (!(estahNaApp(img_app, circles[i], rects[i]))) {
			x = circles[i].center.x - correctImage.size().width / 2;
			y = circles[i].center.y - correctImage.size().height / 2;
			overlayImage(&img_app, &correctImage, Point(x, y));
		} else {
			x = circles[i].center.x - errorImage.size().width / 2;
			y = circles[i].center.y - errorImage.size().height / 2;
			overlayImage(&img_app, &errorImage, Point(x, y));
		}
	}
	
	// Apenas para debug
	imshow("Entrada", img_original);
	imshow("Entrada com mediana", img_median);

	namedWindow("Resultado", CV_WINDOW_NORMAL);
	setWindowProperty("Resultado", CV_WND_PROP_FULLSCREEN, CV_WINDOW_FULLSCREEN);
	imshow("Resultado", img_app);

	char key = waitKey(0);
		
	while (key != 27 && key != -1) {
		cout << "Pressionou a tecla: " << key << endl;
		key = waitKey(0);
	}
	cout << "pressionou o ESC finalizando..." << endl;
	return 0;
}

int main(int argc, char** argv) {

	string acao = argv[1];
	
	// Caso esteja aberto, é preciso liberar a camera do Kinect
	waitKey(1000);
	system("killall SARndbox");

	// Para poder capturar a foto com um fundo preto
	Mat img_fullscreen = imread("../resources/fundo_preto.png", 1);
	namedWindow("imagem_fullscreeen", CV_WINDOW_NORMAL);
	setWindowProperty("imagem_fullscreeen", CV_WND_PROP_FULLSCREEN, CV_WINDOW_FULLSCREEN);
	imshow("imagem_fullscreeen", img_fullscreen);
	
	// Aguardar para liberar a camera e exibir a imagem preta de fundo
	waitKey(1000);
	
	if (acao == "aula5") {	
		return aula5();
	} else if (acao == "aula4") {
		return aula4();
	} else if (acao == "aula3") {
		return aula3();
	}
	
}
