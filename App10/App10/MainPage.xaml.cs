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

namespace App10
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

        DispatcherTimer dispatcherTimer;

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



        void dispatcherTimer_Tick(object sender, object e)
        {

            TimerLog.Text = timesTicked.ToString();

            if (timesTicked > timesToTick)
            {

                TimerStatus.Text = "Calling dispatcherTimer.Stop()\n";

                dispatcherTimer.Stop();

                TimerStatus.Text = "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";

            }

            timesTicked++;

        }

        private void TimerStart_Click_1(object sender, RoutedEventArgs e)
        {

            TimerStatus.Text = "Calling dispatcherTimer.Start()\n";

            DispatcherTimerSetup();

        }



        private void TimerStop_Click_1(object sender, RoutedEventArgs e)
        {

            TimerStatus.Text = "Calling dispatcherTimer.Stop()\n";

            dispatcherTimer.Stop();

            TimerStatus.Text = "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";

        }

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            TimerStatus.Text = "dispatcherTimer.IsEnabled = False";
        }
    }
}
