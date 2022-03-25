using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabbedMovie.Models;
using TabbedMovie.ViewModels;
using TabbedMovie.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedMovie.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void SwipeDelete_Invoked(object sender, EventArgs e)
        {
            var swipeitem = sender as SwipeItem;
            var context = swipeitem.BindingContext;
            var movie = context as Movie;
            _viewModel.DeleteCommand.Execute(movie);
        }
    }
}