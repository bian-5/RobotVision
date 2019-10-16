今日成果及收获总结
今天在vs中进行opencv的配置和测试
1.首先下载Visual Studio2019或者Visual Studio2017，两者差别不大。环境配置选择C++控制台，然后在path值中加入bin文件下路径。
2.在VC++Directories，在Include Directories中添加include和opencv2这两个文件下的目录
3.在Linker->Input目录下，点击Additional Dependencies并添加opencv_world411d.lib静态库
4.测试Opencv代码 代码如下 
		#include <iostream>
		#include <opencv2/opencv.hpp>

		using namespace cv;

		int main()
		{
			Mat img = imread("D:\\Works\\Data\\Bear\\001.jpg");

			imshow("test01", img);

			waitKey(0);
		}
5.紧接着做图像腐蚀，图像模糊，边缘检测这三项测试代码如下
6.颜色空间转换：cvtColor（）函数原型
 C++：void cvtColor（InputArray src，OutputArray dst，int code，int dstCn=0）
OpenCV2版本为
cvtColor（srcImage，dstImage，CV_GRAY2BGR）;
![](.\media\timg.jpg)![](.\media\2.jpg)
![](.\media\10.jpg)
![](.\media\11.jpg)
今日收获是知道了VS怎么配置环境 在VS环境下需要不断重复测试
王景楠  计算机172 201702055