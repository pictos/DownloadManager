using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace DownloadApp
{
    public partial class MainPage : ContentPage
    {
        readonly Progress<double> progress = new Progress<double>();
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            progress.ProgressChanged += Progress_ProgressChanged;
            await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            progress.ProgressChanged -= Progress_ProgressChanged;
        }
        private void Progress_ProgressChanged(object sender, double e)
        {
            proglbl.Text = e.ToString();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            var path = await DownloadManager.DownloadManager.DownloadAsync("teste.jpg", "https://upload.wikimedia.org/wikipedia/commons/2/2d/Snake_River_%285mb%29.jpg", progress);

            file.Text = path;
            img.Source = path;
        }
    }
}
