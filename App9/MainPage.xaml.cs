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



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App9
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

        public DispatcherTimer dispatcherTimer;
        int timesTicked = 1;
        int timesToTick = 50;

        public void DispatcherTimerSetup()
        {

            dispatcherTimer = new DispatcherTimer();

            dispatcherTimer.Tick += dispatcherTimer_Tick;

            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            dispatcherTimer.Start();

            TimerStatus.Text = "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";

        }

        public static class Globals
        {
            public static DateTime StartTime { get; set; }  //need global variables to write to csv file
            public static int pausecount { get; set; }  //counter for the number of times they pause
            public static int morecount { get; set; }   //counter for the number of time they ask parents for more time
            public static int acc15 { get; set;} //number of times parents accept 15
            public static int acc30 { get; set;} //number of times parents accept 30

            //public static DispatcherTimer timer { get; set;} //set the timer here in order to stop it if pause button is pressed etc. 
                                                             //I had to use the DispatchTimer class because Timer does not run under 
                                                             //the .Net Framework for Windows Application
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Globals.StartTime = DateTime.Now;               //get the start time
            //Globals.timer.Tick+=timer_Tick;
            //Globals.timer.Tick += timer_Tick;
            //Globals.timer.Start();
            //if Globals.timer.Equals()

             
        }

        private void ProgressBar_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }
    }
}
