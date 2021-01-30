# WebDriveUM

* 一些网盘的统一管理工具
    * 开源项目只考虑官方提供API的网盘
* 数据备份——数据迁移、备份


## 开发者注意

> 由于项目中会涉及开发者的密钥，故为避免密钥在托管项目中出现，请参见项目DeveloperKeyInfo文件夹下的ReadMe描述

## 最新情况

本项目开始重新开发

计划使用开发框架及第三方dll：

* MVVMLight
* MEF —— IOC框架

## 基础架构


<table cellspacing="2" cellpadding="2" border="1" style="width:100%" >
<tr><td align="center">WPF</td><td align="center">WebAPI??</td></tr>
<tr><td colspan="2" align="center">File Manager</td></tr>
<tr><td colspan="2" align="center">Web Drive Adapter</td></tr>
<tr><td colspan="2" align="center">Web Drive Provider ---- Dropbox,Google Drive...</td></tr>
</table>


## 当前准备工作

添加阿里云oss管理功能，将相关的配置项保存成配置文件


## 公共API

百度网盘：https://pan.baidu.com/union
DropBox：https://www.dropbox.com/developers
OneDrive：https://docs.microsoft.com/zh-cn/onedrive/developer/
Box：https://developer.box.com/