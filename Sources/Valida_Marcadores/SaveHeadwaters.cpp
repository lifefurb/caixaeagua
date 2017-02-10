#include "SaveHeadwaters.h"

/// Salva as nascentes para exibicao no Sandbox
void saveHeadwaterToSandbox(vector<Circle> circles)
{
	Rect border = getBorderOfTheBox();
	vector<Point2f> myBoxLayout = readFileMyBoxLayout();

	stringstream sstm;

	// Definindo as escalas das imagens
	Scale origin(Point2f(0, 0), Point2f(border.width, border.height));
	Scale destiny(myBoxLayout[0], myBoxLayout[1]);
	
	// Convertendo os pontos da escala da imagem de entrada para a imagem da APP
	for (int i = 0; i < circles.size(); i++) {
		Point2f p = convertTof(origin, destiny, circles[i].center);
        sstm << p.x << "," << p.y << "\n";
	}
    
    writeInFile("../config/Nascentes.txt", sstm.str());
}

/// Salva as nascentes para exibicao no Selecionar APP
void saveHeadwaterToSelecionarAPP(vector<Circle> circles)
{
    Rect border = getBorderOfTheBox();
    
    stringstream sstm;
    
    // Definindo as escalas das imagens
    Scale origin(Point(0, 0), Point(border.width, border.height));
    Scale destiny(Point(0,0), Point(1024, 768));
    
    sstm << "25\n";
    
    // Convertendo os pontos da escala da imagem de entrada para a imagem da APP
    for (int i = 0; i < circles.size(); i++) 
	{
        Point p = convertTo(origin, destiny, circles[i].center);
        circles[i].center = p;
        sstm << p.x << "," << p.y << "\n";
    }
    
    writeInFile("../config/NascentesReais.txt", sstm.str());
}

/// função para retornar um vector com os dados do arquivo lados.txt
vector<Point> readFileLados() 
{
	string line;
	ifstream file;
	char * number;
	char str_line[128];
	float x = 0.0f;
	float y = 0.0f;
	vector<float> points;
	vector<Point> returnPoints;

	string file_name = "../config/lados.txt";

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

	returnPoints.push_back(Point(points[0], points[1]));
	returnPoints.push_back(Point(points[2], points[3]));
	return returnPoints;
}

/// função para retornar um vector com os dados do arquivo myBoxLayout.txt
vector<Point2f> readFileMyBoxLayout()
{
	string line;
	ifstream fileMyBoxLayout;
	vector<float> points;
	vector<Point2f> returnPoints;

	string file_name = "../config/myBoxLayout.txt";
	
	fileMyBoxLayout.open(file_name.c_str());
	while (!fileMyBoxLayout.eof())
	{
		getline(fileMyBoxLayout, line);
		if (line.compare("") != 0)
		{
			points.push_back(atof(line.c_str()));
		}
	}

	returnPoints.push_back(Point2f(points[0], points[2]));
	returnPoints.push_back(Point2f(points[1], points[3]));
	return returnPoints;
}

/// função para escrever uma string em um arquivo
void writeInFile(string file_name, string data)
{
	ofstream file;
	file.open(file_name.c_str());
    file << data;
	file.close();
}
