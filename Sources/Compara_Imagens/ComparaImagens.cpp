//ComparaImagens.cpp
/*Classe que recebe duas imagens como parêmtro para 
comparar e depois fazer a sobreposição com a difrença
na segunda imagem*/

#include "opencv2/imgproc/imgproc.hpp"
#include "opencv2/highgui/highgui.hpp"
#include <iostream>
#include <string>

using namespace std;
using namespace cv;

int main(int argc, char** argv) {

	string comum = argv[1];

	string o = argv[1];

	string d = argv[2];
	
	Mat origin = imread(o, 1);
	Mat destino = imread(d, 1);

	if (!origin.data || !destino.data) return -1;

	Mat dstMedianOrigin;
	Mat dstMedianDestino;

	Mat result;

	//Apply median filters
	medianBlur(origin, dstMedianOrigin, 41);
	//imshow("Display Image", dstMedianOrigin);
	medianBlur(destino, dstMedianDestino, 41);
	//imshow("Captura", dstMedianDestino);

	//subtract images 
	//pode ser feito pela função ou pelos operadores
	//optou-se pelos operadores
	//subtract(dstMedianOrigin, dstMedianDestino, result);

	// A primeira subtração identifica os tons claros
	// A segunda  subtração identifica os tons escuros
	result = (dstMedianOrigin - dstMedianDestino) + (dstMedianDestino - dstMedianOrigin);
	
	// corrige contraste/brilho
	result = result + Scalar(-50, -50, -50);
	
	Mat element = getStructuringElement(MORPH_RECT, Size(4,4), Point(-1,-1));

	erode(result, result, element, Point(-1,-1), 2);
	
	medianBlur(result, result, 5);

	//imshow("Subtracao", result);

	Mat newImage = Mat::zeros(result.size(), result.type());

	long total = result.rows * result.cols;

	double diferente = 0;

	for (int y = 0; y < result.rows; y++)
	{
		for (int x = 0; x < result.cols; x++) {
			if ((result.at<Vec3b>(y, x)[0] != 0) || (result.at<Vec3b>(y, x)[1] != 0) || (result.at<Vec3b>(y, x)[2] != 0)) {
				//cout <<  (int)result.at<Vec3b>(y, x)[0] << " "<< (int)result.at<Vec3b>(y, x)[1] << " " << (int)result.at<Vec3b>(y, x)[2] << endl;
				result.at<Vec3b>(y, x)[0] = saturate_cast<uchar>(2.2*(result.at<Vec3b>(y, x)[0]) + 50);
				result.at<Vec3b>(y, x)[1] = saturate_cast<uchar>(2.2*(result.at<Vec3b>(y, x)[1]) + 50);
				result.at<Vec3b>(y, x)[2] = saturate_cast<uchar>(2.2*(result.at<Vec3b>(y, x)[2]) + 50);

				newImage.at<Vec3b>(y, x)[0] = saturate_cast<uchar>(151);
				newImage.at<Vec3b>(y, x)[1] = saturate_cast<uchar>(50);
				newImage.at<Vec3b>(y, x)[2] = saturate_cast<uchar>(170);
				diferente++;
			}
			else {
				newImage.at<Vec3b>(y, x)[0] = saturate_cast<uchar>(destino.at<Vec3b>(y, x)[0]);
				newImage.at<Vec3b>(y, x)[1] = saturate_cast<uchar>(destino.at<Vec3b>(y, x)[1]);
				newImage.at<Vec3b>(y, x)[2] = saturate_cast<uchar>(destino.at<Vec3b>(y, x)[2]);
			}
		}

	}
	
	//write subtract images in disk
	//imwrite("images/Subtract.jpg", result);

	//write newImage images in disk Documentos/Repositorios/furb-arsandbox/Qt/Imgs_Sandbox/resultado/
	cout << imwrite("../resources/comparacoes/diferenca.png", newImage) << endl;
	
	int retorno = 100 - ((diferente/total)*100);
	cout <<" Percentual: "<< retorno <<"%" << endl;

	waitKey(0);

	return retorno;
}
