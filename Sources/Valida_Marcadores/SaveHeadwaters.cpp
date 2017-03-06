#include "SaveHeadwaters.h"

/// Salva as nascentes para exibicao no Sandbox
void saveHeadwaterToSandbox(vector<Circle> circles)
{
	Rect border = getBorderOfTheBox();
	vector<Point2f> boxLayout = readFileBoxLayout();

	stringstream sstm;

	// Definindo as escalas das imagens
	Scale origin(Point2f(0, 0), Point2f(border.width, border.height));
	Scale destiny(boxLayout[0], boxLayout[1]);
	
	// Convertendo os pontos da escala da imagem de entrada para o mundo do SARdbox
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
vector<Point2f> readFileBoxLayout()
{
	string line;
	ifstream fileBoxLayout;
	vector<float> points_x;
    vector<float> points_y;
	vector<Point2f> returnPoints;

    string numberRaw;
    char str_line[128];
    float x = 0.0f;
    float y = 0.0f;

	string file_name  = getenv("HOME");
	file_name.append("/src/SARndbox-1.6/etc/SARndbox-1.6/BoxLayout.txt");

	cout << "file_name: " << file_name << endl;

	fileBoxLayout.open(file_name.c_str());
	// ignorando a primeira linha
    getline(fileBoxLayout, line);

	while (!fileBoxLayout.eof())
	{
		getline(fileBoxLayout, line);
        if (line.compare("") != 0) {
            strcpy(str_line, line.c_str());
            numberRaw = strtok(str_line, ",");
            numberRaw.erase(remove(numberRaw.begin(), numberRaw.end(), ' '), numberRaw.end());
            numberRaw.erase(remove(numberRaw.begin(), numberRaw.end(), '('), numberRaw.end());
            x = atof(numberRaw.c_str());
            points_x.push_back(x);
            numberRaw = strtok(NULL, ",");
            numberRaw.erase(remove(numberRaw.begin(), numberRaw.end(), ' '), numberRaw.end());
            y = atof(numberRaw.c_str());
            points_y.push_back(y);
        }
	}

    float xMin = (points_x[0] + points_x[2])/2;
    float xMax = (points_x[1] + points_x[3])/2;
    float yMin = (points_y[0] + points_y[1])/2;
    float yMax = (points_y[2] + points_y[3])/2;

	returnPoints.push_back(Point2f(xMin, yMin));
	returnPoints.push_back(Point2f(xMax, yMax));
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
