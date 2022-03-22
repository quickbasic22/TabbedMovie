using System;
using TabbedMovie.Services;
using TabbedMovie.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedMovie
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<TabbedMovie.Data.MovieContext>();
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
