using System;
using TabbedMovie.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedMovie
{
    public partial class App : Application
    {
        public static TabbedMovie.Data.MovieContext DataStore;
        public App()
        {
            InitializeComponent();
            DataStore = new Data.MovieContext();
            
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
