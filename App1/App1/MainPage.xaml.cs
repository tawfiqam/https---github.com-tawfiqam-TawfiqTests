using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Stop();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }

        DispatcherTimer dispatcherTimer;               //maybe we should try to get a public variable here so we can check it throughout

        int timesTicked = 1;

        int timesToTick = 3600;                       //This is the limit we will set for the use of the app, in this case, 1 hour

        int minutesToGo = 3600;                        //60 minutes

        int minuteDiff = 60;

       // static private DispatcherTimer dispatcherTimer;
        public static class Globals
        {
            public static DateTime StartTime { get; set; }
            public static DateTime EndTime { get; set; }
            public static int pauseCount { get; set; }
            public static int morecount { get; set; }
            public static int acc15 { get; set; }
            public static int acc30 { get; set; }
            public static DateTime Today { get; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void StartTimer()
        {
            dispatcherTimer.Start();
        }


        void dispatcherTimer_Tick(object sender, object e)
        {
            minuteDiff = (minutesToGo - timesTicked) / 60;
            TimerLeft.Text = minuteDiff.ToString();
            Seconds.Text = timesTicked.ToString();

            if (timesTicked > timesToTick)
            {

                dispatcherTimer.Stop();
            }

            timesTicked++;

        }
        

       
        private async void ladybug_Click(object sender, RoutedEventArgs e)
        {

            StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            Folder = await Folder.GetFolderAsync("Assets");
            StorageFile mediafile = await Folder.GetFileAsync("ladybug.wmv");
            media.SetSource(await mediafile.OpenAsync(FileAccessMode.Read), mediafile.ContentType);
            media.Play();
            StartTimer();
            if (dispatcherTimer.IsEnabled)
            { return; }
            dispatcherTimer.Start();
            WriteLog("Start ladybug ");
        }

        private async void fishes_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            Folder = await Folder.GetFolderAsync("Assets");
            StorageFile mediafile = await Folder.GetFileAsync("fishes.wmv");
            media.SetSource(await mediafile.OpenAsync(FileAccessMode.Read), mediafile.ContentType);
            media.Play();
            StartTimer();
            if (dispatcherTimer.IsEnabled)
                { return; }
            dispatcherTimer.Start();
            WriteLog("Start fishes " + Globals.Today.ToString());
        }

        private void btnplay_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
            WriteLog("Play video");
            dispatcherTimer.Start();
           
        }

        private void btnpause_Click(object sender, RoutedEventArgs e)
        {
            media.Pause();
            WriteLog("Pause");
            dispatcherTimer.Stop();
            
        }

        private async void WriteLog(string Msg)
        {
            // Create sample file; create new.
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile logfile = await storageFolder.CreateFileAsync("Log.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(logfile, Msg);

        }

      
    }

}
