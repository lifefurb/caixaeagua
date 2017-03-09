#include "opencv2/imgproc/imgproc.hpp"
#include "opencv2/highgui/highgui.hpp"

//int MARGEM_IGUALDADE = 10;

struct Circle {
	cv::Point center;
	double radius;

	Circle() {

	}

	Circle(cv::Point centro, float raio) {
		center = centro;
		radius = raio;
	}

	// equality comparison. doesn't modify object. therefore const.
	bool operator==(const Circle& a) const {

		int z = 15;// MARGEM_IGUALDADE;
		int lsx = a.center.x + z;
		int lix = a.center.x - z;
		int lsy = a.center.y + z;
		int liy = a.center.y - z;

		if (center.x >= lix && center.x <= lsx && center.y >= liy && center.y <= lsy) {
			return true;
		} else {
			return false;
		}
	}

};
