# OpenMV机器人视觉
基于OpenMV，学习机器人视觉

## Basics
- main.py让LED亮起来

## Drawing 画图

- flood_fill洪水填充
- text_drawing绘制文字

## Image-Filters 图像滤波

- Histogram_Equalization 直方图均衡
- blur_filter模糊滤波
- kernel_filter核滤波
- cartoon_filter卡通化滤波
- color_bilateral_filter彩图双边滤波
- grayscale_bilateral_filter灰度双边滤波
- color_light_removal彩图光线去除
- grayscale_bilateral_filter灰度图双边滤波
- advanced_frame_differencing高级帧间差分
- basic_frame_differencing简单帧间差分
- color_binary_filter分割图像
- edge_filter边缘滤波
- gamma_correction gamma矫正
- edge_detection边缘检测
- linear_polar线性极坐标映射
- log_polar对数极坐标映射
- erode_and_dilate腐蚀膨胀
- grayscale_binary_filter灰度二值化
- lens_correction畸变校正
- line_filter直线滤波
- mean_filter均值滤波
- mean_adaptive_threshold_filter平均自适应阈值滤波
- median_adaptive_threshold_filter中值自适应阈值滤波
- median_filter中值滤波
- median_filter中点滤波
- midpoint_adaptive_threshold_filter中点自适应阈值滤波
- mode_filter众数滤波
- mode_adaptive_threshold_filter众数自适应阈值滤波
- negative 像素值反转
- rotation_correction旋转校正
- sharpen_filter图像锐化
- unsharp_filter消除锐化
- vflip_hmirror_transpose 垂直水平镜像转置图像

## Snapshot 拍摄 && Video-Recording 视频录制

- snapshot保存图片
- time_lapse_photos延时拍照
- gif录制动图
- mjpeg保存视频
  
## Face-Detection 人脸检测

- face_detection人脸识别
- face_recognition人脸分辨
- face_tracking人脸追踪
- face_eye_detection人眼追踪
- iris_detection瞳孔识别

## Feature-Detection 特征检测

- edges快速边缘检测
- find_circles识别圆
- find_line_segments识别线段
- lines识别直线
- find_rects识别矩形
- Feature-Detection->hog特征
- keypoints特征点检测
- lbp特征点
- inear_regression_fast 快速线性回归（巡线）
- linear_regression_robust 鲁棒线性回归
- template_matching模板匹配

## Color-Tracking 颜色追踪
- automatic_grayscale_color_tracking自动灰度颜色追踪
- automatic_rgb565_color_tracking自动RGB565颜色跟踪
- line_flowing机器人巡线
- image_histogram_info图像直方图信息
- image_statistics_info图像统计信息
- multi_color_blob_tracking多颜色跟踪
- multi_color_code_tracking多颜色组合识别
- single_color_code_tracking单颜色组合识别
- single_color_grayscale_blob_tracking单色灰度色块跟踪
- blob_detection颜色识别

## Machine-Learning 机器学习
- nn_cifar10神经网络例程
- nn_cifar10_search_just_center神经网络区域中心识别
- nn_cifar10神经网络整幅图像识别
- nn_haar_smile_detection笑脸识别
- LetNet数字识别
- nn_lenet_search_whole_window整幅图形数字识别例程



