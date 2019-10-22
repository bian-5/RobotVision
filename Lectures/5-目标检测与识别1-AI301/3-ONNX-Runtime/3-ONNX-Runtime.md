# ONNX Runtime C# API

ONNX Runtime 为在.Net标准平台上运行ONNX模型的推理提供了一个C# .Net 绑定（binding）方法，并且基于.Net 1.1标准。

## NuGet包

Microsoft.ML.OnnxRuntime Nuget包包含了预编译的二进制文件，以及X64 CPU相关的Windows和Linux库。

### 实例代码

本单元测试包含加载模型的一些例子，测试了一些input/output节点格式和类型，并且创建了打分(scoring)用的张量(tensors):

- [InferenceTest.cs](https://github.com/microsoft/onnxruntime/blob/master/csharp/test/Microsoft.ML.OnnxRuntime.Tests/InferenceTest.cs#L54)

# API 简介

- 运行模型的例子，用于根据已有的ONNX模型针对输入数据进行推理，主要采用InferenceSession类打开一个会话(session)

```C#
//To start scoring using the model, open a session using the InferenceSession class, passing in the file path to the model as a parameter
var session = new InferenceSession("model.onnx");
```

产生会话后，采用InferenceSession类的run() 方法来执行请求。目前，只支持Tensor类型的输入和输出。最后的结果是 .Net Tensor 类的集合 (定义在 [System.Numerics.Tensor中](https://www.nuget.org/packages/System.Numerics.Tensors))。

```C#
//Once a session is created, you can execute queries using the Run method of the InferenceSession object. Currently, only Tensor type of input and outputs are supported. The results of the Run method are represented as a collection of .Net Tensor objects
Tensor<float> t1, t2;  // let's say data is fed into the Tensor objects
var inputs = new List<NamedOnnxValue>()
             {
                NamedOnnxValue.CreateFromTensor<float>("name1", t1),
                NamedOnnxValue.CreateFromTensor<float>("name2", t2)
             };
using (var results = session.Run(inputs))
{
    // manipulate the results
}
```

将输入数据从数组转换为Tensor objects：

```C#
//create the Tensor from arrays
float[] sourceData;  // assume your data is loaded into a flat float array
int[] dimensions;    // and the dimensions of the input is stored here
Tensor<float> t1 = new DenseTensor<float>(sourceData, dimensions);   
```

- 完整的例子：[预训练模型推理](https://github.com/microsoft/onnxruntime/blob/master/csharp/sample/Microsoft.ML.OnnxRuntime.InferenceSample)

## API 参考

### InferenceSession

```C#
//The runtime representation of an ONNX model
class InferenceSession: IDisposable
```
- 构造函数

```C#
InferenceSession(string modelPath);

InferenceSession(string modelPath, SesionOptions options);
```

- 属性

```C#
//Data types and shapes of the input nodes of the model.
//IReadOnlyDictionary OutputMetadata; Data types and shapes of the output nodes of the model.
IReadOnlyDictionary<NodeMetadata> InputMetadata;
```

- 方法

```C#
//Runs the model with the given input data to compute all the output nodes and returns the output node values. Both input and output are collection of NamedOnnxValue, which in turn is a name-value pair of string names and Tensor values. The outputs are IDisposable variant of NamedOnnxValue, since they wrap some unmanaged objects.
IDisposableReadOnlyCollection<DisposableNamedOnnxValue> Run(IReadOnlyCollection<NamedOnnxValue> inputs);

//Runs the model on given inputs for the given output nodes only.
IDisposableReadOnlyCollection<DisposableNamedOnnxValue> Run(IReadOnlyCollection<NamedOnnxValue> inputs, IReadOnlyCollection<string> desiredOutputNodes);
```

## System.Numerics.Tensor

### NamedOnnxValue
```C#
//Represents a name-value pair of string names and any type of value that ONNX runtime supports as input-output data. Currently, only Tensor objects are supported as input-output values.
class NamedOnnxValue;
```

- 构造函数

无

- 属性

```C#
string Name;   // read only
```

- 方法

```C#
//Creates a NamedOnnxValue from a name and a Tensor object
static NamedOnnxValue CreateFromTensor<T>(string name, Tensor<T>);

//Accesses the value as a Tensor
Tensor<T> AsTensor<T>();
```

- DisposableNamedOnnxValue

```C#
//This is a disposable variant of NamedOnnxValue, used for holding output values which contains objects allocated in unmanaged memory
class DisposableNamedOnnxValue: NamedOnnxValue, IDisposable;
```

- IDisposableReadOnlyCollection
```C#
//Collection interface to hold disposable values. Used for output of Run method
interface IDisposableReadOnlyCollection: IReadOnlyCollection, IDisposable
```

### SessionOptions

```C#
//A collection of properties to be set for configuring the OnnxRuntime session
class SessionOptions: IDisposable;
```

- 构造函数
```C#
SessionOptions();
```

- 属性
```C#
static SessionOptions Default;   //read-only
```

- 方法
```C#
SetSessionGraphOptimizationLevel(GraphOptimizationLevel graph_transformer_level);

SetSessionExecutionMode(ExecutionMode execution_mode);
```

### NodeMetadata
模型图节点的元数据容器，用于输入和输出节点的形状和类型的通信。

- 属性
  
```C#
//Read-only shape of the node, when the node is a Tensor. Undefined if the node is not a Tensor
int[] Dimensions;  
```

```C#
//Type of the elements of the node, when node is a Tensor. Undefined for non-Tensor nodes.
System.Type ElementType;
```

```C#
//Whether the node is a Tensor
bool IsTensor;
```

- 异常处理
```C#
//The type of Exception that is thrown in most of the error conditions related to Onnx Runtime
class OnnxRuntimeException: Exception;
```

