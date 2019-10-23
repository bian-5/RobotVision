## 武宇飞201702048
***
# 实验名称：MNIST手写字
***

# 一、环境要求

## Windows 10（版本1809或更高版本）

## Windows 10 SDK（内部版本17763或更高版本）

## Visual Studio 2019（或Visual Studio 2017 15.7.4版或更高版本）

## 适用于Visual Studio 2019或2017的 Windows Machine Learning Code Generator扩展

# 二、项目设计

## （1）启动UWP

从GitHub下载项目后，启动Visual Studio并打开MNIST_Demo.sln文件.如果解决方案显示为

不可用，则需要在解决方案资源管理器中重新选择Reload Project。

## （2）构建并运行项目

配置环境，然后运行项目，请单击工具栏上的“ 开始调试”按钮，会显示一个InkCanvas，用户

可以在其中写一个数字，一个Recognize按钮来解释该数字，一个空标签字段，其中解释后的数

字将以文本形式显示，以及一个Clear Digit按钮来清除InkCanvas。

## （3）添加模型

选择“ 添加” >“ 现有项”。将文件选择器指向ONNX模型的位置，然后单击添加。该项目现在应

该有两个新文件： mnist.onnx-训练的模型。 mnist.cs -Windows ML生成的代码。改变属

性，使用这些类在项目中加载，绑定和评估模型。

## （4）加载，绑定和评估模型

对于Windows ML应用程序，遵循的模式：“加载”>“绑定”>“求值”。加载机器学习模型。 使用

mnist.cs中生成的接口代码来加载，绑定和评估应用程序中的模型。首先，在

MainPage.xaml.cs中，我们实例化模型，输入和输出。将以下成员变量添加到

MainPage类：

    private mnistModel ModelGen;
    private mnistInput ModelInput = new mnistInput();
    private mnistOutput ModelOutput;

然后，在LoadModelAsync中，加载模型。MainPage的加载事件，加载模型，我们要调用

CreateFromStreamAsync方法，并传入ONNX文件作为参数。

    private async Task LoadModelAsync()
    {
    // Load a machine learning model
    StorageFile modelFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/mnist.onnx"));
    ModelGen = await mnistModel.CreateFromStreamAsync(modelFile as IRandomAccessStreamReference);
    }

接下来，我们要将输入和输出绑定到模型。要初始化模型的输入对象，调用mnistInput类构造

函数，传入您的应用程序数据，并确保输入数据与模型期望的输入类型匹配。

    private async void recognizeButton_Click(object sender, RoutedEventArgs e)
    {
    // Bind model input with contents from InkCanvas
    VideoFrame vf = await helper.GetHandWrittenImage(inkGrid);
    ModelInput.Input3 = ImageFeatureValue.CreateFromVideoFrame(vf);
    }

对于输出，调用EvaluateAsync。输入初始化后，调用模型的EvaluateAsync方法以根据输入数

据评估模型，显示该数字。

    private async void recognizeButton_Click(object sender, RoutedEventArgs e)
    {
    // Bind model input with contents from InkCanvas
    VideoFrame vf = await helper.GetHandWrittenImage(inkGrid);
    ModelInput.Input3 = ImageFeatureValue.CreateFromVideoFrame(vf);

    // Evaluate the model
    ModelOutput = await ModelGen.EvaluateAsync(ModelInput);

    // Convert output to datatype
    IReadOnlyList<float> vectorImage = ModelOutput.Plus214_Output_0.GetAsVectorView();
    IList<float> imageList = vectorImage.ToList();

    // Query to check for highest probability digit
    var maxIndex = imageList.IndexOf(imageList.Max());

    // Display the results
    numberLabel.Text = maxIndex.ToString();
    }

最后，我们要清除InkCanvas，即可绘制另一个数字

    private void clearButton_Click(object sender, RoutedEventArgs e)
    {
    inkCanvas.InkPresenter.StrokeContainer.Clear();
    numberLabel.Text = "";
    }

## （5）启动应用程序

识别在InkCanvas上绘制的数字。

# 三、实验效果

# 四、总结

实验过程中的确有许多困难，有外部因素，也有内部因素，长时间下载不了文件，实验中有许多

问题，但是经过和同学间的沟通解决了一部分问题。也具体细微的了解了一部分代码。有的代码

虽然不会写，但是看懂以后，对以后写类似的东西也有所帮助。所谓实践出真知。