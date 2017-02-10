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

/// função para desenhar circulos em uma imagem
void drawCircles(vector<Circle> &circles, Mat &img);

/// função para retornar um rect que representa a borda da area de projeção
Rect getBorderOfTheBox();

/// função para retornar o incide da webcam que deve ser utilizada
int getIndexCamera();

/// função para retornar um vector de Mat com varias "fotos capturadas pelo Kinect"
vector<Mat> getImgsCamera(int qtd, int indexCamera);

/// função para retornar um vector com as posições dos circulos contidos na imagem
vector<Circle> getCircles(Mat img, int radius, int THRESHOLD_CANNY_DETECTION, int THRESHOLD_CENTER_DETECTION, int MIN_RADIUS, int MAX_RADIUS);

/// função para retornar um vector com os circulos capturados pelo kinect
vector<Circle> getCirculosCapturados(string fileName);

/// função para exibir e retornar os circulos em tempo real
vector<Circle> getCirclesRealTime();

/// função para retornar um vector contendo o total de circulos, sem repitir
vector<Circle> mergeCircles(vector<vector<Circle> > allCircles);

/// função para verificar se o circle está contido no vector (utiliza a MARGEM_IGUALDADE)
bool contains(vector<Circle>, Circle circle);
