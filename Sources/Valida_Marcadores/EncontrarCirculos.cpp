#include "EncontrarCirculos.h"

using namespace cv;
using namespace std;

/// função para verificar se o circle está contido no vector (utiliza a MARGEM_IGUALDADE)
bool contains(vector<Circle> circles, Circle circle) {

	for (size_t i = 0; i < circles.size(); i++) {
		if (circles[i] == circle) return true;
	}

	return false;
}

/// função para desenhar circulos em uma imagem
void drawCircles(vector<Circle> &circles, Mat &img) {
	
	for (size_t i = 0; i < circles.size(); i++) {
		// circle center
		circle(img, circles[i].center, 3, Scalar(0, 255, 0), -1, 8, 0);
		// circle outline
		circle(img, circles[i].center, circles[i].radius, Scalar(0, 0, 255), 3, 8, 0);
	}
}

/// função para retornar um rect que representa a borda da area de projeção
Rect getBorderOfTheBox()
{
	string line;
	ifstream file;
	char * number;
	char str_line[128];
	float x = 0.0f;
	float y = 0.0f;
	vector<float> points;
	
	string file_name = "../config/lados.txt";//"C:/Users/joao_/Desktop/testes/config/lados.txt";

	file.open(file_name.c_str());
	while (!file.eof())
	{
		getline(file, line);

		if (line.compare("") != 0) {
			strcpy(str_line, line.c_str());
			number = strtok(str_line, ",");
			x = atof(number);
			number = strtok(NULL, ",");
			y = atof(number);
			points.push_back(x);
			points.push_back(y);
		}
	}

	return Rect(points[0], points[1], points[2] - points[0], points[3] - points[1]);
}

/// função para retornar o incide da webcam que deve ser utilizada
int getIndexCamera() {
	
	int index = 0;
	string line;
	char str_line[64];
	ifstream infile;
	infile.open("../config/indexCamera.txt");
	
	getline(infile, line);
	strcpy(str_line, line.c_str());
	index = atoi(str_line);

	infile.close();
	return index;
}

/// função para retornar um vector de Mat com varias "fotos capturadas pelo Kinect"
vector<Mat> getImgsCamera(int qtd, int indexCamera) {

	VideoCapture cap;
	vector<Mat> images(qtd);
	Mat frame;
	
	/*
	if (!cap.open(indexCamera)) {
		cout << "Erro, não foi possível localizar a câmera" << endl;
		return images;
	}
	*/
	int i = 0;
	while (!cap.open(indexCamera) && i <= 3) {
		i++;
		cout << "Erro, não foi possível localizar a câmera" << endl;
		cout << "Tentando novamente" << endl;
		waitKey(1000);
	}
		if (i >= 1) return images;
	
	for (int i = 0; i < qtd; i++) {
		cap >> frame;
		if (frame.empty()) {
			break; // end of video stream
		} else {
			images[i] = frame;
		}
	}
	return images;
}

/// função para retornar um vector com as posições dos circulos contidos na imagem
vector<Circle> getCircles(Mat img, int radius, int THRESHOLD_CANNY_DETECTION, int THRESHOLD_CENTER_DETECTION, int MIN_RADIUS, int MAX_RADIUS) {
	Mat img_gray;
	Circle myCircle;
	vector<Vec3f> possibles_circles;
	vector<Circle> effective_circles;

	/// Convert it to gray
	cvtColor(img, img_gray, CV_BGR2GRAY);
	
	int MIN_DIST_CENTERS = img_gray.rows / 8;

	/// Apply the Hough Transform to find the circles
	//http://docs.opencv.org/2.4/doc/tutorials/imgproc/imgtrans/hough_circle/hough_circle.html
	//HoughCircles(img_gray, possibles_circles, CV_HOUGH_GRADIENT, 1, img_gray.rows / 8, 100, 40, 0, 0);
	HoughCircles(img_gray, possibles_circles, CV_HOUGH_GRADIENT, 1, MIN_DIST_CENTERS, THRESHOLD_CANNY_DETECTION, THRESHOLD_CENTER_DETECTION, MIN_RADIUS, MAX_RADIUS);

	/// Draw the circles detected
	for (size_t i = 0; i < possibles_circles.size(); i++) {	
		// [0] == x
		// [1] == y
		// [2] == radius
		Point center(cvRound(possibles_circles[i][0]), cvRound(possibles_circles[i][1]));
		int radius = cvRound(possibles_circles[i][2]);

		myCircle.center = center;
		myCircle.radius = radius;
		// Adicionando ao vector
		effective_circles.push_back(myCircle);
	}
	return effective_circles;
}

/// função para exibir e retornar os circulos em tempo real 
vector<Circle> getCirclesRealTime() {

	Mat img_original;
	Mat img_median;

	Rect rect;

	vector<Circle> circles_original;
	vector<Circle> circles_median;
	vector<Circle> circles;
	vector<Rect> rects;

	vector<vector <Circle> > all_circles;

	// Lendo imagem capturada pela webcam do Kinect
	int index = getIndexCamera();
	// Criando um retangulo com os pontos da calibracao do mundo
	Rect border = getBorderOfTheBox();
	
	VideoCapture cap(index);
	Mat frame;

	char key = waitKey(1);

	while(key != 27) {
		circles_original.clear();
		circles_median.clear();
		all_circles.clear();
		circles.clear();
		
		for (;;)
		{
			cap >> frame;
			if (frame.empty()) break; // end of video stream

			img_original = frame;

			// limitando a imagem apenas a area de projecao
			img_original = img_original(border);
	
			// Criando uma nova imagem com a mediana, para melhorar a precisão
			medianBlur(img_original, img_median, 5);
	
			// Encontrando os circulos das imagens
			circles_original = getCircles(img_original, 20, 300, 20, 4, 10);
			circles_median = getCircles(img_median, 20, 300, 20, 4, 10);

			// Desenhando os circulos encontrados na imagem de entrada
			// drawCircles(circles_original, img_original);

			// Desenhando os circulos encontrados na imagem de entrada com mediana
			drawCircles(circles_median, img_median);

			// imshow("Entrada", img_original);
			imshow("Entrada", img_median);
		
			char key = waitKey(1);
			if (key == 27) break; // stop capturing by pressing ESC 
		}	
	
		all_circles.push_back(circles_original);
		all_circles.push_back(circles_median);

		circles = mergeCircles(all_circles);

		// Desenhando todos os circulos encontrados na imagem de entrada
		drawCircles(circles, img_original);	

		imshow("Entrada", img_original);
	
		cout << "Total de circulos: " << circles.size() << endl;	
	
		key = waitKey(0);
	}

	return circles;

}

/// função para retornar um vector com os circulos capturados pelo kinect
vector<Circle> getCirculosCapturados(string fileName) 
{
	string line;
	ifstream infile;
	char * num;
	char str_line[1024];
	float x = 0.0f;
	float y = 0.0f;
	float raio = 0.0f;
	Circle circulo;
	vector<Circle> circulos;

	infile.open(fileName.c_str());

	getline(infile, line);
	strcpy(str_line, line.c_str());
	raio = cvRound(atof(str_line));

	while (!infile.eof())
	{
		getline(infile, line);
		if (line.compare("") != 0) 
		{
			strcpy(str_line, line.c_str());
			num = strtok(str_line, ",");

			x = cvRound(atof(num));
			y = cvRound(atof(strtok(NULL, ",")));

			circulo.center = Point2d(x, y);
			circulo.radius = raio;

			circulos.push_back(circulo);
		}
	}

	infile.close();
	return circulos;
}

/// função para retornar um vector contendo o total de circulos, sem repitir
vector<Circle> mergeCircles(vector<vector <Circle> > allCircles) {

	vector<Circle> circles;
	Circle atual;
	for (int i = 0; i < allCircles.size(); i++) 
	{
		for (int j = 0; j < allCircles[i].size(); j++) 
		{
			atual = allCircles[i][j];
			if (!contains(circles, atual))
			{
				circles.push_back(atual);
			}
		}
	}

	return circles;
}
