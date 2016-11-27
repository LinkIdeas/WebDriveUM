此项目内容为开发者使用的key项目，涉及开发者私人信息，项目中存储密钥信息的类将不进行托管。

## 步骤

* 移除DeveloperKeyInfo项目中的LocalKey —— 由于此文件不托管，故会显示感叹号。
* 添加名为LocalKey的类文件
* 将SampleKey中内容复制到LocalKey文件中，同时将类名修改为LocalKey
* 在Init方法内初始化Key中相应的属性
* 在调用Key之前添加LocalKey的Init调用，进行初始化。

> 注意，请勿在SampleKey或Key中添加个人开发密钥信息