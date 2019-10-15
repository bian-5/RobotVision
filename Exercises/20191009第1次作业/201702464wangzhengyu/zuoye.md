# 学习总结：
今天经过一上午的学习和实验 ：配置opencv和调试vs，各种图像的处理以及py的安装，
pip的安装配置 学习到了很多 也提高了动手能力 对vs的综合应用 其中在配置opencv环境
时出现了很多波折 
1. 下载Visual Studio Community 2019

    下载地址：*https://visualstudio.microsoft.com/*
2. 安装后打开，启动界面
  * 安装OpenCV4.1.1版本
    从所给资料中下载OpenCV411，并安装到某个给定目录下
  * 配置OpenCV环境变量
  1. 在我的电脑上右键“属性”，点击“高级系统环境”

  2. 在用户变量中，点击Path变量并编辑，添加dll所在路径
    
    确定后，并重启以使得环境变量生效
  * 在vs 2019 中新建项目
  1. 选择路径“File->New->Project”:
  2. 依次选择language为c++，Platform为Windows，Project type为desktop
  3. 选择Windows Desktop Wizard，并选择next
  4. 点击create,并在弹出的对话框中选择，Application type为console,选择empty project
  5. 在source files里添加test01.cpp源文件，右键test01 ，选择属性；
    选择VC++ 目录（VC++ Directories），在包含目录（Include Directories）中添加:
    D:\OpenCV\opencv\build\include
    D:\OpenCV\opencv\build\include\opencv2
  6. 库目录（Library Directories）中添加：
    D:\OpenCV\opencv\build\x64\vc15\lib

  7. 在链接器（linler）->输入（input）目录下，点击附加依赖项（Additional Dependencies）并添加opencv_world411d.lib静态库：
点击ok并确定退出。
  * 测试OpenCV代码
    在test01.cpp中添加显示的代码：
3. 在配置dubug|x64的链接器的输入目录时要添加
D:\Path\opencv\build\x64\vc15\lib\opencv_world411d.lib
在配置环境时其实很简单， 其他的按照步骤一一配置即可，但是配置时一定要找准opencv的安装位置及其目录下的文件，在vs中要配置的就三个地方：

 (1) C++目录中的包含目录

（2）VC++目录中的库目录

（3）链接器中的输入的附加依赖项

    #include <iostream>
    #include <opencv2/opencv.hpp>
    using namespace cv;
    }

    
图片位置一定要写对。

1. 学会配置py和pip和调试opencv2 运用power shell
2. 通过编写代码对图片进行各种处理。
3. 进行图片处理时，写出相应的代码,选取自己喜欢的图片（记住图片的位置）
   
   ![](media/1.jpg)