using DeveloperKeyInfo;
using DriveAPI.Core;
using DropBoxManager;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using WebDriveUM.ViewModel;

namespace WebDriveUM
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        private CompositionContainer _container;

        public App()
        {
            LocalKey.Init();


        }


        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);


            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(App).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IBaseDriveService).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(DropBoxManagement).Assembly));

            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {

                this._container.ComposeParts(ServiceLocator.Current.GetInstance<MainViewModel>());
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }
    }
}
