#include "cv.h"
#include "highgui.h"
#include "cxcore.h"
using namespace std;
using namespace cv;

int getColSum(Mat src,int col)
{
	int sum = 0;
	int height = src.rows;
	int width = src.cols;
	for (int i = 0; i < height; i++)
	{
		sum = sum + src.at <uchar>(i, col);
	}
	return sum;
}

int getRowSum(Mat src, int row)
{
	int sum = 0;
	int height = src.rows;
	int width = src.cols;
	for (int i = 0; i < width; i++)
	{
		sum += src.at <uchar>(row, i);
	}
	return sum;
}


void cutTop(Mat& src, Mat& dstImg)//上下切割
{
	int top, bottom;
	top = 0;
	bottom = src.rows;

	int i;
	for (i = 0; i < src.rows; i++)
	{
		int colValue = getRowSum(src, i);
		//cout <<i<<" th "<< colValue << endl;
		if (colValue>0)
		{
			top = i;
			break;
		}
	}
	for (; i < src.rows; i++)
	{
		int colValue = getRowSum(src, i);
		//cout << i << " th " << colValue << endl;
		if (colValue == 0)
		{
			bottom = i;
			break;
		}
	}

	int height = bottom - top;
	Rect rect(0, top, src.cols, height);
	dstImg = src(rect).clone();
}

int cutLeft(Mat& src, Mat& leftImg, Mat& rightImg)//左右切割
{
	int left, right;
	left = 0;
	right = src.cols;

	int i;
	for (i = 0; i < src.cols; i++)
	{
		int colValue = getColSum(src, i);
		//cout <<i<<" th "<< colValue << endl;
		if (colValue>0)
		{
			left = i;
			break;
		}
	}
	if (left == 0)
	{
		return 1;
	}


	for (; i < src.cols; i++)
	{
		int colValue = getColSum(src, i);
		//cout << i << " th " << colValue << endl;
		if (colValue == 0)
		{
			right = i;
			break;
		}
	}
	int width = right - left;
	Rect rect(left, 0, width, src.rows);
	leftImg = src(rect).clone();
	Rect rectRight(right, 0, src.cols - right, src.rows);
	rightImg = src(rectRight).clone();
	cutTop(leftImg, leftImg);
	return 0;
}


void getPXSum(Mat &src, int &a)//获取所有像素点和
{ 
	threshold(src, src, 100, 255, CV_THRESH_BINARY);
	  a = 0;
	for (int i = 0; i < src.rows;i++)
	{
		for (int j = 0; j < src.cols; j++)
		{
			a += src.at <uchar>(i, j);
		}
	}
}

int  getSubtract(Mat &src, int TemplateNum) //两张图片相减
{
	Mat img_result;
	int min = 1000000;
	int serieNum = 0;
	for (int i = 0; i < TemplateNum; i++){
		char name[20];
		sprintf_s(name, "D:\\%dLeft.jpg", i);
		Mat Template = imread(name, CV_LOAD_IMAGE_GRAYSCALE);
		threshold(Template, Template, 100, 255, CV_THRESH_BINARY);
		threshold(src, src, 100, 255, CV_THRESH_BINARY);
		resize(src, src, Size(32, 48), 0, 0, CV_INTER_LINEAR);
		resize(Template, Template, Size(32, 48), 0, 0, CV_INTER_LINEAR);
		//imshow(name, Template);
		absdiff(Template, src, img_result);
		int diff = 0;
		getPXSum(img_result, diff);
		if (diff < min)
		{
			min = diff;
			serieNum = i;
		}
	}
	printf("最小距离是%d ", min);
	printf("匹配到第%d个模板匹配的数字是%d\n", serieNum,serieNum);
	return serieNum;
}




	

int main()
{
	Mat src = imread("D:\\bb.png", CV_LOAD_IMAGE_GRAYSCALE);
	threshold(src, src, 100 , 255, CV_THRESH_BINARY);
	imshow("origin", src);

	Mat leftImg,rightImg;
	int res = cutLeft(src, leftImg, rightImg);	
	int i = 0; 
	while (res == 0)
	{ 		
		char nameLeft[10];
		sprintf(nameLeft, "%dLeft", i);
		char nameRight[10];
		sprintf(nameRight, "%dRight", i);
		i++;
		imshow(nameLeft, leftImg);
		stringstream ss;
		ss << nameLeft;
		imwrite("D:\\" + ss.str() + ".jpg", leftImg);
		ss >> nameLeft;
		Mat srcTmp = rightImg;
	//	getSubtract(leftImg, 10);
		res = cutLeft(srcTmp, leftImg, rightImg);	
	}
	
	waitKey(0);
	return 0;
}

