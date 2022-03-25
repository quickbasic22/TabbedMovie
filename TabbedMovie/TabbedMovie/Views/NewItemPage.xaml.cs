using System;
using System.Collections.Generic;
using System.ComponentModel;
using TabbedMovie.Models;
using TabbedMovie.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace TabbedMovie.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Movie Item { get; set; }
        public NewItemViewModel _viewModel;

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new NewItemViewModel();
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var movieService = new Services.GetMovies();
            var movieList = await movieService.GetMovieList(e.NewTextValue);

            CollectionViewMovieList.ItemsSource = movieList;
            _viewModel.MovieResult = movieList;
        }
    }
}