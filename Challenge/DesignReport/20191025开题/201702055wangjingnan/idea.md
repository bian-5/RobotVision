### idea
## 一丶初步想法:
   在课堂中我们练习过看图识熊，使用的也是ONNXMODEL将熊的识别在VS2017中实现，在微软开源的OnnxRuntime库提供了NuGet包，可以很方便的集成到Visual Studio项目。所以我想用OnnxRuntime的方法进行看图识猫，类别有橘猫，黑猫，加菲猫和英短。
## 二丶设计思路:
      设计思路主要如下：
      1.首先在VS2017中建立一个项目(使用的是Windows窗体应用)，给这个项目起名ClassifyCat
      2.在将模型文件添加到项目中，模型文件是CatModel.onnx。
      3.添加OnnxRuntime库中的NuGet包。
      4.添加代码并测试。
## 三丶预期结果:
       将网络上的猫的图片的地址URL输入应该能识别如下五个标识（orange cat，black cat，garfield， english short和negative）。    