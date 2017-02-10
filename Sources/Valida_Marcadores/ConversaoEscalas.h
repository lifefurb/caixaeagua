#include "opencv2/imgcodecs.hpp"

struct Scale {
	cv::Point2f lower_limit;
	cv::Point2f upper_limit;

	Scale() {};

	Scale(cv::Point2f lowerLimit, cv::Point2f upperLimit) {
		lower_limit = lowerLimit;
		upper_limit = upperLimit;
	}

};

cv::Point convertTo(Scale origin, Scale destiny, cv::Point point);

cv::Point2f convertTof(Scale origin, Scale destiny, cv::Point2f point);

int findQuadrant(cv::Mat& image, cv::Point point);
