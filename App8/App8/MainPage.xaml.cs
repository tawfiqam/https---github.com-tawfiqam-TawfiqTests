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
using Windows.Storage.Pickers;
using Windows.Storage;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App8
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

        private  async void b_Click_1(object sender, RoutedEventArgs e)
        {
            var openPicker = new FileOpenPicker();
            openPicker.SuggestedStartLocation = PickerLocationId.VideosLibrary;
            openPicker.FileTypeFilter.Add(".wmv");
            openPicker.FileTypeFilter.Add(".mp4");
            var file = await openPicker.PickSingleFileAsync();
            var stream = await file.OpenAsync(FileAccessMode.Read);
            media.SetSource(stream, file.ContentType);
            media.Play();
        }

        private void p_Click_1(object sender, RoutedEventArgs e)
        {
            media.Play();
        }

        private void pa_Click_1(object sender, RoutedEventArgs e)
        {
            media.Pause();
        }

        private void f_Click_1(object sender, RoutedEventArgs e)
        {
            media.DefaultPlaybackRate = 2.0;
            media.Play();
        }

        private void norm_Click_1(object sender, RoutedEventArgs e)
        {
            media.DefaultPlaybackRate = 0.5;
            media.Play();
        }
    }
}
