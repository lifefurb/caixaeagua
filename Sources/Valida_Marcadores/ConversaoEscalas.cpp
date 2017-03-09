#include "ConversaoEscalas.h"

cv::Point convertTo(Scale origin, Scale destiny, cv::Point point) {
	
	cv::Point converted_point;
	
	double width_origin, width_destiny;
	double height_origin, height_destiny;

	// Converter x
	width_origin = origin.upper_limit.x - origin.lower_limit.x;
	width_destiny = destiny.upper_limit.x - destiny.lower_limit.x;

	converted_point.x = (int) (width_destiny * (((point.x - origin.lower_limit.x) / width_origin)) + destiny.lower_limit.x);
	
	// Converter y
	height_origin = origin.upper_limit.y - origin.lower_limit.y;
	height_destiny = destiny.upper_limit.y - destiny.lower_limit.y;

	converted_point.y = (int) (height_destiny * (((point.y - origin.lower_limit.y) / height_origin)) + destiny.lower_limit.y);
	
	return converted_point;
}

cv::Point2f convertTof(Scale origin, Scale destiny, cv::Point2f point) {

	cv::Point2f converted_point;

	float width_origin, width_destiny;
	float height_origin, height_destiny;

	// Converter x
	width_origin = origin.upper_limit.x - origin.lower_limit.x;
	width_destiny = destiny.upper_limit.x - destiny.lower_limit.x;

	converted_point.x = (width_destiny * (((point.x - origin.lower_limit.x) / width_origin)) + destiny.lower_limit.x);

	// Converter y
	height_origin = origin.upper_limit.y - origin.lower_limit.y;
	height_destiny = destiny.upper_limit.y - destiny.lower_limit.y;

	converted_point.y = (height_destiny * (((point.y - origin.lower_limit.y) / height_origin)) + destiny.lower_limit.y);

	return converted_point;
}

int findQuadrant(cv::Mat& image, cv::Point point) {
    
    /// Encontrar o quadrante
    // Quadrante 1 ou 2
    if (point.y >= image.rows/2) {
        if (point.x >= image.cols/2){
            return 1;
        } else {
            return 2;
        }
    // quadrante 3 ou 4
    } else {
        if (point.x < image.cols/2) {
            return 3;
        } else {
            return 4;
        }
    }
}

