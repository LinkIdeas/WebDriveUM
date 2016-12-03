using DeveloperKeyInfo;
using DriveAPI.Core;
using DropBoxManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace WebDriveUM
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
      

        public App()
        {
            LocalKey.Init();

        }
    }
}
