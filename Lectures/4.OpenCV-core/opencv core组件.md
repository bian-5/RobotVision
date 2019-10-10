# OpenCV core 组件

## 图像像素访问

图像矩阵大小取决于所用的颜色模型，即通道数。若图像是灰度的，则矩阵如下：

![](./Images/001.png)

对于多通道的图像而言，矩阵列会包含与通道数相同数目的子列：

![](./Images/002.png)

注意：OpenCV子列中通道数顺序是反过来的，即BGR而非RGB。

![](./Images/003.png)

## 访问像素的方法

- 指针访问：C操作符[ ]

- 迭代器iterator

- 动态地址计算

参考教材相关内容

## ROI区域

ROI (Region of Interest): 感兴趣区域，有两种定义方式：

- 矩形区域Rect
```C++
//定义一个Mat类型并给其设定ROI区域
Mat imageROI;
imageROI = image(Rect(500, 250, logo.cols, logo.rows));
```

- 行列范围Range

```C++
//定义一个Mat类型并给其设定ROI区域
Mat imageROI;
imageROI = image(Range(250, 250+logoImage.rows), Range(250, 250+logoImage.cols));
```
- 代码示例
```C++
//ROI_AddImage()函数
// 利用感兴趣区域ROI实现图像叠加
bool ROI_AddImage()
{
    //读入图像
    Mat srcImage1 = imread("dota_pa.jpg");
    Mat logoImage = imread("dota_logo.jpg");
    
    Mat imageROI = srcImage1(Rect(200, 250, logoImage.cols, logoImage.rows));

    Mat mask = imread("dota_logo.jpg", 0);

    logoImage.copyTo(imageROI, mask);

    namedWindow("利用ROI实现图像叠加");

    imshow("image add", srcImage1);

    return 1;

}
```

## 线性混合

线性混合操作是一种典型的二元像素操作
$$
g(x) = (1-a)f_a(x)+af_3(x)
$$
- addWeighted()函数
  - 函数原型
```C++
addWeighted(InputArray src1, double alpha, InputArray src2, double beta, double gamma, OutputArray dst, int dtype= -1);
```

- 代码实例
```C++
//利用cv::addWeighted()函数实现图像线性混合
bool LinearBlending()
{
    double alphaValue = 0.5;
    double betaValue;

    Mat srcImage2, srcImage3, dstImage;

    srcImage2 = imread("mogu.jpg");
    srcImage3 = imread("rain.jpg");

    betaValue = 1- alphaValue;
    addWeighted(srcImage2, alphaValue, srcImage3, betaValue, 0.0, dstImage);

    namedWindow("image", 1);
    imshow("image", srcImage2);

    namedWindow("image", 1);
    imshow("image", dstImage);

    return 1;
}
```

## 分离颜色通道、多通道图像混合

- 通道分离：split()函数
```C++
void split(const Mat& src, Mat *mvbegin);
void split(InputArray m, OutputArrayOfArrays mv);
```

- 通道合并：merge()函数
```C++
void merge(const Mat*&* src, size_tcount, OutputArray dst);
void merge(InputArrayOfArrays mv, OutputArray dst);
```

- 实例程序：多通道图像混合
参考教材P127页


## 图像对比度、亮度值调整
图像处理是一个算子，接收一个或多个输入图像，产生输出图像：
$$
g(x) = h(f(x)) 或者 g(x) = h(f_0(x), ..., f_n(x))
$$

- 点操作
  - 亮度：bright
  - 对比度：contrast
  - 颜色校正：colorcorrection
  - 变换：transformations

最常见的点操作是乘上一个常数（对比度调整）并加上一个常数（亮度值调整）
$$
g(x) = a*f(x)+b
$$
其中，a为增益，b为偏置。

- 实例程序：见教材132页

## 离散傅立叶变换

在频域里，对于一幅图像，高频部分代表了图像的细节、纹理信息；低频部分代表了图像的轮廓信息。
- 低通滤波器：只剩下轮廓信息

傅立叶变换可以做到图像增强与图像去噪、图像分割之边缘检测、图像特征提取、图像压缩等。

- dft()函数
```C++
void dft(InputArray src, OutputArray dst, int flag=0, int nonzeroRows=0);
```

- 实例程序：离散傅立叶变换 见书139页
- 




