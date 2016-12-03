using DriveAPI.Core;
using DropBoxManager;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows.Input;

namespace WebDriveUM.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private CompositionContainer _container;

        [Import("DropBox", typeof(IBaseDriveService))]
        IBaseDriveService Dropbox { get; set; }

        public UserInfo User { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>

        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            AddConnectionBoxCommand = new RelayCommand(AddConnectionBox);




            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(App).Assembly));
            //catalog.Catalogs.Add(new DirectoryCatalog(@"E:\MyDownloads\Simple Calculator MEF Application\C#\SimpleCalculator3\Extensions"));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IBaseDriveService).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(DropBoxManagement).Assembly));

            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        public ICommand AddConnectionBoxCommand { get; set; }

        void AddConnectionBox()
        {
            var uri = Dropbox.GetAuthPageAddress();
            Messenger.Default.Send<NotificationMessageWithCallback>(new NotificationMessageWithCallback(uri.ToString(), new Action<string>(async (string uri1) =>
            {
                Dropbox.SetAccessToken(new Uri(uri1));

                User = await Dropbox.GetUserInfoAsync();
                RaisePropertyChanged(() => User);
            })), "GetAuth");
        }
    }
}