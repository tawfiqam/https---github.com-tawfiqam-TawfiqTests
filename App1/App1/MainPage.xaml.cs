using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Storage.Pickers;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public static class Globals
        {
            public static DateTime StartTime { get; set; }
            public static DateTime EndTime { get; set; }
            public static int pauseCount { get; set; }
            public static int morecount { get; set; }
            public static int acc15 { get; set; }
            public static int acc30 { get; set; }
            public static DateTime Today { get; }
            public static DispatcherTimer ds { get; set; }

        }

        private void SetUpTimer()
        {
            Globals.ds.Interval = new TimeSpan(0, 1, 0);
            Globals.ds.Tick += ds_Tick;
        }

        private async void ladybug_Click(object sender, RoutedEventArgs e)
        {

            StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            Folder = await Folder.GetFolderAsync("Assets");
            StorageFile mediafile = await Folder.GetFileAsync("ladybug.wmv");
            media.SetSource(await mediafile.OpenAsync(FileAccessMode.Read), mediafile.ContentType);
            media.Play();
            WriteLog("Start ladybug "); 
        }

        private async void fishes_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            Folder = await Folder.GetFolderAsync("Assets");
            StorageFile mediafile = await Folder.GetFileAsync("fishes.wmv");
            media.SetSource(await mediafile.OpenAsync(FileAccessMode.Read), mediafile.ContentType);
            media.Play();
            WriteLog("Start fishes " + Globals.Today.ToString());
        }

        private void btnplay_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
            WriteLog("Play video " + Globals.Today.ToString());
        }

        private void btnpause_Click(object sender, RoutedEventArgs e)
        {
            media.Pause();
            WriteLog("Pause " + Globals.Today.ToString());
        }

        private async void WriteLog(string Msg)
        {
            // Create sample file; create new.
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile logfile = await storageFolder.CreateFileAsync("Log.txt", Windows.Storage.CreationCollisionOption.GenerateUniqueName);
            await Windows.Storage.FileIO.WriteTextAsync(logfile, Msg);
        }

        
    }
}
