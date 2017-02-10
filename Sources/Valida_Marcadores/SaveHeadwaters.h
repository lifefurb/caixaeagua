#include "opencv2/highgui/highgui.hpp"
#include "opencv2/imgproc/imgproc.hpp"
#include <iostream>
#include <fstream>
#include <string>
#include <stdio.h>

#ifndef CIRCLE_H
#include "Circle.h"
#define CIRCLE_H
#endif // !CIRCLE_H

#ifndef CONVERSAO_ESCALAS_H
#include "ConversaoEscalas.h"
#define CONVERSAO_ESCALAS_H
#endif // !CONVERSAO_ESCALAS_H

#ifndef ENCONTRAR_CIRCULOS_H
#include "EncontrarCirculos.h"
#define ENCONTRAR_CIRCULOS_H
#endif // !ENCONTRAR_CIRCULOS_H

using namespace std;
using namespace cv;

/// Salva as nascentes para exibiÁ„o no Sandbox
void saveHeadwaterToSandbox(vector<Circle> circles);

/// Salva as nascentes para exibicao no Selecionar APP
void saveHeadwaterToSelecionarAPP(vector<Circle> circles);

/// função para retornar um vector com os dados do arquivo lados.txt
vector<Point> readFileLados();

/// função para retornar um vector com os dados do arquivo myBoxLayout.txt
vector<Point2f> readFileMyBoxLayout();

/// função para escrever uma string em um arquivo
void writeInFile(string file_name, string data);
