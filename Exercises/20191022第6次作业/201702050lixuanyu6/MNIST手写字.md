# MNIST手写数字实验总结
## 实验内容
   本次课的主要内容是利用Visual Studio尝试实现MNIST手写数字识别功能。
## 实验要求的环境
+ Windows 10（版本1809或更高版本）
+ Windows 10 SDK（内部版本17763或更高版本）
+ Visual Studio 2019（或Visual Studio 2017 15.7.4版或更高版本）
+ 适用于Visual Studio 2019或2017的 Windows Machine Learning Code Generator扩展
## 实验步骤
  ### 1.启动UWP
    从GitHub下载项目后，启动Visual Studio并打开MNIST_Demo.sln文件。此时如果解决方案显示为不可用，则需要在解决方案资源管理器中右键单击该项目，然后选择Reload Project。
  ### 2.构建并运行项目
    在Visual Studio工具栏中，将解决方案平台更改为x64，以在您的设备为64位时在本地计算机上运行该项目，如果设备为32位，则在x86上运行。点击开始调试按钮进行调试程序，此过程中会安装较多组件，耗时较长，需要耐心等待。
  ### 3.添加模型
    右键单击解决方案资源管理器中的Assets文件夹，然后选择“ 添加” >“ 现有项”。将文件选择器指向ONNX模型的位置，然后单击添加。为了确保在编译应用程序时能够构建模型，请右键单击mnist.onnx文件，然后选择Properties。对于Build Action，选择Content。
  ### 4.加载，绑定和评估模型
    加载机器学习模型。 将输入和输出绑定到模型。 评估模型并查看结果。 我们将使用mnist.cs中生成的接口代码来加载，绑定和评估应用程序中的模型。
    首先，在MainPage.xaml.cs中，我们实例化模型，输入和输出。将ModelGen，mnistInput，ModelOutput成员变量添加到MainPage类。然后，在LoadModelAsync中，加载模型。接下来，将输入和输出绑定到模型。生成的代码还包括mnistInput和mnistOutput包装器类。所述mnistInput类表示该模型的预期输入，并且mnistOutput类表示该模型的预期的输出。要初始化模型的输入对象，请调用mnistInput类构造函数，传入您的应用程序数据，并确保输入数据与模型期望的输入类型匹配。该mnistInput类期待一个ImageFeatureValue，所以使用一个辅助方法获取ImageFeatureValue为输入。使用helper.cs中包含的帮助函数，我们将复制InkCanvas的内容，将其转换为ImageFeatureValue类型，然后将其绑定到我们的模型。输入后，利用模型的EvaluateAsync方法进行评估模型，然后将输入和暑促和绑定倒模型对象，并在输入上评估模型。最后实现识别之后可以使用"清除"功能进行第二次操作。
  ### 5.调试启动程序
    构建程序后启动调试。
![](media\0.png)
    并多次尝试手写识别分别如下：
![](media\1.png)
![](media\2.png)
![](media\3.png)
![](media\4.png)
![](media\5.png)
## 实验总结与心得
   **本次课时我们做了MNIST手写数字识别实验，使我初步了解到模型识别。MNIST是一个入门级的计算机视觉数据集，MNIST来自美国国家标准与几术后研究所，由250个不同人手写的数字构成，是一套很庞大的手写数字识别数据集，对我们来说它可以让我们尝试学习模型识别方法。本次课利用老师给出的代码进行改动调试，最终基本可以实现0~9数字的识别，总体来说还是比较成功的。首先我电脑的windows SDK版本落后，MNIST要求使用版本较新的Windos SDK，进行了升级；编写修改众多构造函数时遇到类型不匹配的问题；识别成功但是无法现实结果的问题……经历了很多波折之后终于成功完成实验。本次课时是非常有趣的一次课，我第一次接触了模型识别，感受到了学习智能化的乐趣，这次课对我以后的学习奠定了基础，加深了我对智能化的本质的理解。**

