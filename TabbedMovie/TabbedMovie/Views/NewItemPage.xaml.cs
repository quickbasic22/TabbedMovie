using System;
using System.Collections.Generic;
using System.ComponentModel;
using TabbedMovie.Models;
using TabbedMovie.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TabbedMovie.Views
{
    public partial class NewItemPage : ContentPage
    {
        
        public Movie Item { get; set; }
        public NewItemViewModel _viewModel;
        Services.GetMovies movieService;
        List<QuickType1.MovieResult> movieList = null;

        public NewItemPage()
        {
            InitializeComponent();
            movieService = new Services.GetMovies();
            movieList = movieService.GetMovieList("Robots").Result;
            BindingContext = _viewModel = new NewItemViewModel();
        }
        
       
        private async void MovieSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            movieList = await movieService.GetMovieList(e.NewTextValue);

            CollectionViewMovieList.ItemsSource = movieList;
            _viewModel.MovieResult = movieList;
        }
    }
}