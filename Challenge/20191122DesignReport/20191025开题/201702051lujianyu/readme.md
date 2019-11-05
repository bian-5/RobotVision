## 初步想法
通过之前的YOLO推理环境感知，继续稍加改进，形成一个更成熟，更美观的Windows APP



## 设计思路
* 修改程序的GUI设计，看起来高大上即可
* 修改程序内的设计。将原本的算法设别调用**CPU**算力转为通过CUDA调用**GPU**实现算法以得到更好的效果
* 将原本的帧率限制，使其固定在一个基本的帧数波动不要太大即可，初始想法为**60FPS**
  



## 预期结果
<div align="center">
<img src="https://pjreddie.com/media/image/Screen_Shot_2016-09-07_at_10.56.09_PM.png" height="300px" >
<img src="https://pjreddie.com/media/image/Screen_Shot_2016-09-07_at_11.00.34_PM.png" height="300px"  >
</div>

希望能把界面做漂亮，让程序能够更加稳定，识别率更高  
**图片均来自官方网站**
[YOLO](https://pjreddie.com/darknet/yolo/)