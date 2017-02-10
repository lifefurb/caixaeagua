#include <opencv2/opencv.hpp>

/**

* Perform one thinning iteration.

* Normally you wouldn't call this function directly from your code.

*

* Parameters:

* 		im    Binary image with range = [0,1]

* 		iter  0=even, 1=odd

*/
void thinningIteration(cv::Mat& img, int iter);

/**

* Function for thinning the given binary image

*

* Parameters:

* 		src  The source image, binary with range = [0,255]

* 		dst  The destination image

*/
void thinning(const cv::Mat& src, cv::Mat& dst);