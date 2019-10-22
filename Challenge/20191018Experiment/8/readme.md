## 2019/10/18

**201702048（武宇飞）**

**201702072（程世茂）**

**201702051（卢剑宇）**
***
# Windows.ML
***


## 一、界面设计

### （1）创建Windows窗体应用(.NET Framework)项目，命名ClassifyBear；

### （2）在解决方案资源管理器中找到Form1.cs，双击，打开界面设计器。向Form中依次拖入控件并调整，效果如下图所示：

![](media\1.jpg)

#### 左侧从上下到依次是：

#### Label控件，将内容改为“输入要识别的图片地址：”

#### TextBox控件，可以将控件拉长一些，方便输入URL

####  Button控件，将内容改为“识别”

**（注：Lable控件，将label的内容清空，用来显示识别后的结果。因为label也没有边框，所以在界面看不出来。可以**

**将此控件内字体调大一些，能更清楚的显示推理结果。）**

#### 右侧的控件是一个PictureBox，用来预览输入的图片同时将控件中取出对应的图片数据，传给我们的模型推理类库去推理。

**（注：控件属性的SizeMode更改为StretchImage，并将控件长和宽设置为同样的值，为正方形。当前图片大小为224*224。）**

## 二、项目设计

### （1）添加模型文件到项目

 打开解决方案资源管理器,点右键->添加->现有项，在弹出的对话框中，将文件类型过滤器改为
 
 所有文件，然后导航到模型所在目录，选择模型文件(BearModel.onnx)并添加。在模型文件
 
 上点右键，属性，然后在属性面板上，将生成操作属性改为内容，将复制到输出目录属性改为
 
 如果较新则复制。

### （2）按钮的事件响应

在XAML文件中给按钮添加事件，这里在MainPage.xaml.cs中完成对应的实现，从输入框中读入

图片的URL，然后让图片控件加载该URL对应的图片：

     private void TbRun_Tapped(object sender, TappedRoutedEventArgs e){
    tbBearType.Text = string.Empty;

    Uri imageUri = null;
    try
    {
        imageUri = new Uri(tbImageUrl.Text);
    }
    catch (Exception)
    {
        tbBearType.Text = "URL不合法";
        return;
    }

    tbBearType.Text = "加载图片...";

    imgBear.Source = new BitmapImage(imageUri);}


### （3）添加图片控件的事件响应

XAML文件中给图片控件添加了两个事件：图片加载完成的事件和加载

失败的事件，这里在MainPage.xaml.cs中完成对应的实现：

    private void ImgBear_ImageOpened(object sender, RoutedEventArgs e)
    {
    RecognizeBear();
    }
    private void ImgBear_ImageFailed(object sender, ExceptionRoutedEventArgs e)
    {
    tbBearType.Text = "图片加载失败";
    }

处理模型的输入  

    public sealed class BearModelInput
    {
    public ImageFeatureValue data; // BitmapPixelFormat: Bgra8, BitmapAlphaMode: Premultiplied, width: 227, height: 227
    }

处理图片格式

### （4）加载模型并推理

动生成的模型封装文件BearModel.cs中已经封装了加载模型的方法和推理的方法，直接调用就

可以：

    private async void RecognizeBear()
    {
    // 加载模型
    StorageFile modelFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/BearModel.onnx"));
    BearModelModel model = await BearModelModel.CreateFromStreamAsync(modelFile);

    // 构建输入数据
    BearModelInput bearModelInput = await GetInputData();

    // 推理
    BearModelOutput output = await model.EvaluateAsync(bearModelInput);

    tbBearType.Text = output.classLabel.GetAsVectorView().ToList().FirstOrDefault();
    }

### （5）编译运行

在网上找一张熊的图片，把地址填到输入框内，然后点击识别按钮，就可以看到识别的结果了。

注意，这个URL应该是图片的URL，而不是包含该图片的网页的URL。

## 三、实验效果
![](media\c2.jpg)
![](media\c3.jpg)
![](media\c4.jpg)
## 四、实验总结
经过本次实验，主要是Windows.ML应用，对界面设计来说，和之前做的类型差不多，只是不同的方案对应的要求不同，同时让我们应该试着去改变，对自己的能力，对自己所学的有正确的认识，并且能在以后的学习中不断提高和完善自己有很大的作用。实验中，我们3人分工不同，但是通过我们互相合作，最后达到了我们想要的实验效果 。总之，团体项目离不开队友的配合，只有相互配合，通过交流协助，很快的完成了实验。
