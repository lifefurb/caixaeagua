#include "opencv2/imgproc/imgproc.hpp"
#include "opencv2/highgui/highgui.hpp"
#include <iostream>
#include <string>
#include <cmath>

#include "thinning.h"

#ifndef ENCONTRAR_CIRCULOS_H
#include "EncontrarCirculos.h"
#define ENCONTRAR_CIRCULOS_H
#endif // !ENCONTRAR_CIRCULOS_H

#ifndef CONVERSAO_ESCALAS_H
#include "ConversaoEscalas.h"
#define CONVERSAO_ESCALAS_H
#endif // !CONVERSAO_ESCALAS_H

using namespace std;
using namespace cv;

bool isInsidePoly(Point point, Mat& img_polys);

Rect findBbox(vector<Point> poly);

void drawLinesImg(Mat& img, vector<Point> points);

void waterToWhite(Mat& img, Mat& preenchido, Mat& contorno);

void CallBackFunc(int event, int xMouse, int yMouse, int flags, void* userdata);

void doMagic(Mat& img, Mat& img_fill, Mat& img_contours, Mat& img_polys);

Mat executeSelecionarApp();
