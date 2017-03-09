//#include "opencv2/imgcodecs.hpp"
#include "opencv2/imgproc/imgproc.hpp"
#include "opencv2/highgui/highgui.hpp"
#include <iostream>
#include <fstream>
#include <string>

using namespace std;
using namespace cv;

int main(int argc, char** argv) {

	Mat img = imread(argv[1], CV_LOAD_IMAGE_UNCHANGED);
	namedWindow("imagem", CV_WINDOW_NORMAL);
    cvSetWindowProperty("imagem", CV_WND_PROP_FULLSCREEN, CV_WINDOW_FULLSCREEN);
	imshow("imagem", img);

	waitKey(0);
	return 0;
	
}
