#include "opencv2/highgui/highgui.hpp"
#include "opencv2/imgproc/imgproc.hpp"
#include <iostream>
#include <fstream>

using namespace std;
using namespace cv;

Mat img;
Mat copia;
Rect retangulo;

int xInicial = 0;
int yInicial = 0;
int xFinal = 0;
int yFinal = 0;
int width = 0;
int height = 0;

bool calibrado = false;

int getIndexCamera() {
	
	int index = 0;
	string line;
	char str_line[64];
	ifstream infile;
	infile.open("../config/indexCamera.txt");
	
	getline(infile, line);
	cout << "Leu:" << line << "\n";
	strcpy(str_line, line.c_str());
	index = atoi(str_line);

	infile.close();
	return index;
}

int atualizarBoxLayout() {
	string line;
	ifstream infile;
	string numAtual;
	ofstream myfile;
	vector<float> valores;
	int i = 1;

	// Problemas aqui
	myfile.open("../config/myBoxLayout.txt");
	infile.open("../config/BoxLayout.txt");

	getline(infile, line); //Descartando a primeira linha com a equção do plano.

	while (!infile.eof()) {
	
		getline(infile, line);
	
		while (i < line.size()) {

			if (line[i] == ' ') {
				i++;
				continue;
			}
			if ((line[i] != ',') && (line[i] != '(') && (line[i] != ')')) {
				numAtual += line[i];
			}
			else {
				//myfile << numAtual << "\n";
				float media = atof(numAtual.c_str());
				valores.push_back(media);
				numAtual = "";
			}
			i++;
		} // fim while (i < line.size())
		i = 1;
	} // fim while (!infile.eof())

	myfile << (valores[0] + valores[6])/2 << "\n";
	myfile << (valores[3] + valores[9])/2 << "\n";

	myfile << (valores[1] + valores[4]) / 2 << "\n";
	myfile << (valores[7] + valores[10]) / 2 << "\n";

	infile.close();
	myfile.close();

	return 0;
}


int gravarLados(int xMin, int yMin, int xMax, int yMax) {
	ofstream myfile;
	myfile.open("../config/lados.txt");

	myfile << xMin << ",";
	myfile << yMin;
	myfile << "\n";
	myfile << xMax << ",";
	myfile << yMax;
	myfile << "\n";
	myfile.close();
	return 0;
}

void CallBackFunc(int event, int xMouse, int yMouse, int flags, void* userdata) {
	
	// Acabou
	if (event == EVENT_LBUTTONDOWN && width != 0) {
		cout << "X Final: " << xMouse << " Y Final: " << yMouse << endl;
		cout << "Calibrado" << endl;
		calibrado = true;
		// gravar no arquivo
		gravarLados(xInicial, yInicial, xFinal, yFinal);
		// atualizar informacoes boxLayout
		atualizarBoxLayout();
			
	}

	// Iniciou
	if (event == EVENT_LBUTTONDOWN) {

		xInicial = xMouse;
		yInicial = yMouse;

		cout << "X inicial: " << xMouse << " Y Inicial: "<< yMouse << endl;

	} else if (event == EVENT_MOUSEMOVE && xInicial > 0 && !calibrado) {
		
		xFinal = xMouse;
		yFinal = yMouse;

		width  = xFinal - xInicial;
		height = yFinal - yInicial;

		copia = img.clone();
		retangulo = Rect(xInicial, yInicial, width, height);
		rectangle(copia, retangulo, Scalar(0, 255, 0));
		imshow("Calibracao Mundo", copia);
	}
	
}

int main(int argc, char** argv) {

	int indice = getIndexCamera();

	VideoCapture capWebcam(indice);

	if (capWebcam.isOpened() == false) {
		cout << "error: capWebcam not accessed successfully\n\n";
		return(0);
	}

	capWebcam.read(img);

	//Create a window
	namedWindow("Calibracao Mundo", 1);

	//set the callback function for any mouse event
	setMouseCallback("Calibracao Mundo", CallBackFunc, NULL);

	//show the image
	imshow("Calibracao Mundo", img);

	// Wait until user press some key
	waitKey(0);

	return 0;

}
