#include "opencv2/highgui/highgui.hpp"
#include "opencv2/imgproc/imgproc.hpp"
#include <iostream>
#include <fstream>
#include <stdio.h>
#include <string>
#include <stdlib.h>

#ifndef CIRCLE_H
#include "Circle.h"
#define CIRCLE_H
#endif // !CIRCLE_H

using namespace cv;
using namespace std;

/// fun��o para desenhar circulos em uma imagem
void drawCircles(vector<Circle> &circles, Mat &img);

/// fun��o para retornar um rect que representa a borda da area de proje��o
Rect getBorderOfTheBox();

/// fun��o para retornar o incide da webcam que deve ser utilizada
int getIndexCamera();

/// fun��o para retornar um vector de Mat com varias "fotos capturadas pelo Kinect"
vector<Mat> getImgsCamera(int qtd, int indexCamera);

/// fun��o para retornar um vector com as posi��es dos circulos contidos na imagem
vector<Circle> getCircles(Mat img, int radius, int THRESHOLD_CANNY_DETECTION, int THRESHOLD_CENTER_DETECTION, int MIN_RADIUS, int MAX_RADIUS);

/// fun��o para retornar um vector com os circulos capturados pelo kinect
vector<Circle> getCirculosCapturados(string fileName);

/// fun��o para exibir e retornar os circulos em tempo real
vector<Circle> getCirclesRealTime();

/// fun��o para retornar um vector contendo o total de circulos, sem repitir
vector<Circle> mergeCircles(vector<vector<Circle> > allCircles);

/// fun��o para verificar se o circle est� contido no vector (utiliza a MARGEM_IGUALDADE)
bool contains(vector<Circle>, Circle circle);
