using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Windows;
using Windows.UI.Popups;
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

        int timesToTick = 120;                          //This is the limit we will set for the use of the app, in this case, 1 hour

        int timesp15 = 60;                              //Add 15 minutes

        int timesp30 = 90;                              //Add 30 minutes 

        int minuteDiff = 60;

        int TimeDiff = 0;

        int MediaTime = 0;

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
            minuteDiff = (timesToTick - timesTicked) / 60;
            TimerLeft.Text = minuteDiff.ToString();
            Seconds.Text = timesTicked.ToString();

            if (timesTicked > timesToTick)
            {

                dispatcherTimer.Stop();
            }

            timesTicked++;
            follow_time_15();
            follow_time();
//            follow_time_ext_15();
//            follow_time_ext_30()
        }

       
        public async void follow_time_15()
        {
            if (timesTicked == 100)
            {
                CheckFirst_15();
            }
        }

        public async void follow_time()
        {
            if (timesTicked == timesToTick)
            {
                CheckFirst();
            }
        }

        public async void CheckFirst_15()
        {

            var dialog = new Windows.UI.Popups.MessageDialog("You have 15 minutes");

            UICommand FBtn = new UICommand("Leave Now");
            FBtn.Invoked = FBtnClick;
            dialog.Commands.Add(FBtn);

            UICommand p15Btn = new UICommand("Continue");
            p15Btn.Invoked = p15BtnClick;
            dialog.Commands.Add(p15Btn);

            media.Stop();
            dispatcherTimer.Stop();
            await dialog.ShowAsync();
            
        }

        public async void CheckFirst()
        {

            var dialog = new Windows.UI.Popups.MessageDialog("Time is up today, see you tomorrow");

            UICommand FBtn = new UICommand("OK");
            FBtn.Invoked = FBtnClick;
            dialog.Commands.Add(FBtn);

            await dialog.ShowAsync();
        }
        public void CloseApp()
        {
            Application.Current.Exit();
        }

        public void FBtnClick(IUICommand command)
        {
            CloseApp();
        }

        public void p15BtnClick(IUICommand command)
        {
            media.Play();
            dispatcherTimer.Start();
        }

        public void pcontClick (IUICommand command)
        {
            return;
        }

        private async void BigVid()
        {
            var dialog = new Windows.UI.Popups.MessageDialog("Video Longer than remaining time");
            UICommand FBtn = new UICommand("I want to Stop Watching this video");
            FBtn.Invoked = FBtnClick;
            dialog.Commands.Add(FBtn);

            UICommand pcont = new UICommand("Continue");
            pcont.Invoked = pcontClick;
            dialog.Commands.Add(pcont);
            media.Stop();
            dispatcherTimer.Stop();
            await dialog.ShowAsync();
        }
        private async void ladybug_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
            TimeDiff = timesToTick - timesTicked;
            MediaTime = (int)media.NaturalDuration.TimeSpan.TotalSeconds;
            if (TimeDiff < MediaTime)
            {
                BigVid();
            }
            StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            Folder = await Folder.GetFolderAsync("Assets");
            StorageFile mediafile = await Folder.GetFileAsync("ladybug.wmv");
            media.SetSource(await mediafile.OpenAsync(FileAccessMode.Read), mediafile.ContentType);
            media.Play();
            StartTimer();
            if (dispatcherTimer.IsEnabled)
            { return; }
            dispatcherTimer.Start();
            Debug.WriteLine("Start ladybug ");
        }

        private async void fishes_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
            TimeDiff = timesToTick - timesTicked;
            MediaTime = (int)media.NaturalDuration.TimeSpan.TotalSeconds;
            if (TimeDiff < MediaTime)
            {
                BigVid();
            }
            StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            Folder = await Folder.GetFolderAsync("Assets");
            StorageFile mediafile = await Folder.GetFileAsync("fishes.wmv");
            media.SetSource(await mediafile.OpenAsync(FileAccessMode.Read), mediafile.ContentType);
            media.Play();
            StartTimer();
            if (dispatcherTimer.IsEnabled)
                { return; }
            dispatcherTimer.Start();
            Debug.WriteLine("Start fishes ");
        }

        private void btnplay_Click(object sender, RoutedEventArgs e)
        {
            TimeDiff = timesToTick - timesTicked;
            MediaTime = (int)media.NaturalDuration.TimeSpan.TotalSeconds;
            if (TimeDiff < MediaTime)
            {
                BigVid();
            }
            media.Play();
            Debug.WriteLine("Play video");
            dispatcherTimer.Start();
           
        }

        private void btnpause_Click(object sender, RoutedEventArgs e)
        {
            media.Pause();
            Debug.WriteLine("Pause");
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
