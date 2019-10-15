# 第一次作业  
&emsp;第一次课主要配置了Visual Studio下的Opencv环境，分为以下几个步骤:
>1. 下载VS到电脑上
>2. 下载opencv
>3. 在用户变量及系统变量中添加D:\opencv\opencv\build\x64\vc15\bin
>>![](002.png)
>4. 新建VS项目并添加源文件
>5. 在项目属性中加入opencv的相关路径
>>![](003.png)
>>![](004.png)
>6. 运行测试程序

运行测试程序得到如下结果：  
>![](001.png)

&emsp;心得体会：在配置Visual Studio下的Opencv环境时，我遇到了这样的问题:
>![](005.png)

后来经过搜索，发现将以下三个文件从D:\opencv\opencv\build\x64\vc15\bin中加到C:\Windows\System32中，并将Debug模式改为release模式可以成功运行测试程序![](006.png)
bug的原因仍待深入研究。


