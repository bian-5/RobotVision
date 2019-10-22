## 今日作业
今天学习MNIST手写字
# 1. 首先是配置环境
（1）Windows 10（版本1809或更高版本）
（2）Windows 10 SDK（内部版本17763或更高版本）
（3）Visual Studio 2019（或Visual Studio 2017 15.7.4版或更高版本）
（4）适用于Visual Studio 2019或2017的 Windows Machine Learning Code Generator扩展
（5）一些基本的UWP和C＃知识
# 2. 在创建的MNIST文件中配置
1.InkCanvas绘制数字。 用于解释数字并清除画布的按钮。帮助程序将InkCanvas输出转换VideoFrame的例程。 在解决方案资源管理器内部，该项目具有三个主要代码文件：
2.MainPage.xaml-我们所有的XAML代码都为InkCanvas，按钮和标签创建UI 。
3.MainPage.xaml.cs-我们的应用程序代码所在的位置。
4.Helper.cs-裁剪和转换图像格式的帮助程序例程。
![](.\media\94.jpg)
# 3.构建并运行项目
在Visual Studio工具栏中，将解决方案平台更改为x64，以在您的设备为64位时在本地计算机上运行该项目，如果设备为32位，则在x86上运行。（您可以在Windows设置应用中检入：“ 系统”>“关于”>“设备规格”>“系统类型”。）

要运行项目，请单击工具栏上的“ 开始调试”按钮，或按F5键。该应用程序应该显示一个InkCanvas，用户可以在其中写一个数字，一个Recognize按钮来解释该数字，一个空标签字段，其中解释后的数字将以文本形式显示，以及一个Clear Digit按钮来清除InkCanvas
![](.\media\93.jpg)
# 4.添加模型
右键单击解决方案资源管理器中的Assets文件夹，然后选择“ 添加” >“ 现有项”。将文件选择器指向ONNX模型的位置，然后单击添加。
该项目现在应该有两个新文件： mnist.onnx-训练的模型。 mnist.cs -Windows ML生成的代码
![](.\media\92.jpg)
为了确保在编译应用程序时能够构建模型，请右键单击mnist.onnx文件，然后选择Properties。对于Build Action，选择Content。

现在，让我们看一下mnist.cs文件中新生成的代码。我们分为三类：

mnistModel创建机器学习模型表示，在系统默认设备上创建会话，将特定的输入和输出绑定到模型，并异步评估模型。 mnistInput初始化模型期望的输入类型。在这种情况下，输入需要一个ImageFeatureValue。 mnistOutput初始化模型将输出的类型。在这种情况下，输出将是TensorFloat类型的名为Plus214_Output_0的列表。

现在，将使用这些类在项目中加载，绑定和评估模型。
# 5.导入代码并运行程序
我运行的程序如下
![](.\media\91.jpg)
![](.\media\90.jpg)
![](.\media\99.jpg)
![](.\media\100.jpg)
# 今日学习体会：
今天遇到了很多问题，一开始是发现ONNX文件没有更改属性导致文件报错，但是更改之后继续报错，之后发现MainPage.xaml.cs中new Uri($"ms-appx:///Assets/Mnist.onnx"这行代码没有将Mnist改为MnistModel所以程序报错，最后将程序名字改为Mnist_Demo程序就能完美运行了，还是发现了很多细节问题。同时也学会了这个程序的基本构造和代码理解。

