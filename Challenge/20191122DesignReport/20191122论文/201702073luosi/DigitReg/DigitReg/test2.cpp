////#include "stdafx.h"
//#include "cv.h"
//#include "highgui.h"
//#include "cxcore.h"
//
//
//using namespace std;
//int main(int argc, char* argv[])
//{
//	IplImage* imgSrc = cvLoadImage("D:\\t.jpg", CV_LOAD_IMAGE_COLOR);
//	IplImage* img_gray = cvCreateImage(cvGetSize(imgSrc), IPL_DEPTH_8U, 1);
//	cvCvtColor(imgSrc, img_gray, CV_BGR2GRAY);
//	//cvThreshold(img_gray, img_gray, 100, 255, CV_THRESH_BINARY);// CV_THRESH_BINARY_INV使得背景为黑色，字符为白色，这样找到的最外层才是字符的最外层
//	cvThreshold(img_gray, img_gray, 100, 255, CV_THRESH_BINARY_INV);
//	
//	cvShowImage("ThresholdImg", img_gray);
//	CvSeq* contours = NULL;
//	CvMemStorage* storage = cvCreateMemStorage(0);
//
//	int count = cvFindContours(img_gray, storage, &contours, sizeof(CvContour), CV_RETR_EXTERNAL, CV_CHAIN_APPROX_NONE, cvPoint(0, 0));
//	printf("轮廓个数：%d", count);
//	int idx = 0;
//	//char szName[56] = { 0 };
//	string name;
//	int tempCount = 0;
//	stringstream ss;
//	string s1;
//	vector<CvRect> resultRect;
//	for (CvSeq* c = contours; c != NULL; c = c->h_next)
//	{
//		resultRect.push_back(cvBoundingRect(c, 0));
//	}
//	int length = resultRect.size();
//
//	for(int i = 0; i<length-1; i++)
//	{
//		for (int j = length - 2; j>=i; j--)
//		{
//			if (resultRect[j].x > resultRect[j+1].x)
//			{
//				CvRect rc = resultRect[j];
//				resultRect[j] = resultRect[j+1];
//				resultRect[j+1] = rc;
//			}
//		}
//	}
//
//	for (int i = 0 ; i<length;i++)
//	{
//		CvRect rc = resultRect[i];
//
//		cvDrawRect(imgSrc, cvPoint(rc.x, rc.y), cvPoint(rc.x + rc.width, rc.y + rc.height), CV_RGB(255, 0, 0));
//		IplImage* imgNo = cvCreateImage(cvSize(rc.width, rc.height), IPL_DEPTH_8U, 3);
//		cvSetImageROI(imgSrc, rc);
//		cvCopyImage(imgSrc, imgNo);
//		cvResetImageROI(imgSrc);
//		
//		/*stringstream ss;*/
//		ss << idx++;
//		 s1 = "wnd"+ss.str();
//	//	sprintf(name, "wnd_%d", idx++);
//	//	cvNamedWindow(name);
//		 cvNamedWindow(s1.c_str());
//
//		 cvShowImage(s1.c_str(), imgNo);
//		//string name;
//		 string tt = "D:\\" + s1 + ".jpg";
//		cvSaveImage(tt.c_str(), imgNo);//保存图片
//		cvReleaseImage(&imgNo);
//	}
//	cvNamedWindow("src");
//	cvShowImage("src", imgSrc);
//	cvWaitKey(0);
//	cvReleaseMemStorage(&storage);
//	cvReleaseImage(&imgSrc);
//	cvReleaseImage(&img_gray);
//	cvDestroyAllWindows();
//	return 0;
//}