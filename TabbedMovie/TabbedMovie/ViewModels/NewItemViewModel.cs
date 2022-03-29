using System;
using System.Collections.Generic;
using TabbedMovie.Models;
using Xamarin.Forms;
using System.Linq;
using TabbedMovie.Data;
using QuickType1;
using System.ComponentModel.DataAnnotations;
using Xamarin.Forms.Xaml;
using TabbedMovie.Services;

namespace TabbedMovie.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class NewItemViewModel : BaseViewModel
    {
        Services.GetMovies movieService;
        List<QuickType1.MovieResult> movieList = null;
        private string movietitle;
        private int movieyear;
        private string movieimdb_id;
        private List<MovieResult> movieresults;
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public NewItemViewModel()
        {
            movieService = new Services.GetMovies();
            movieList = movieService.GetMovieList("Robots").Result;
            movieresults = movieList;
            Title = "Movie title";
            Year = 2022;
            ImdbId = "sddxfx999";
            movietitle = "Movie title";
            movieyear= 2022;
            movieimdb_id = "sddxfx999";
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        
        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(Title)
                && !String.IsNullOrWhiteSpace(ImdbId);
        }

        public List<MovieResult> MovieResult
        {
            get => movieresults;
            set => SetProperty(ref movieresults, value);
        }

        public new string Title
        {
            get => movietitle;
            set => SetProperty(ref movietitle, value);
        }

        public int Year 
        {
            get => movieyear;
            set => SetProperty(ref movieyear, value);
        }

        public string ImdbId
        {
            get => movieimdb_id;
            set => SetProperty(ref movieimdb_id, value);
        }


        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            
            var newMovie = new Movie();
            var movieList = await new GetMovies().GetMovieList("Robots");
            newMovie.Title = movieList[0].Title;
            newMovie.Year = (int)movieList[0].Year;
            newMovie.Imdb_Id = movieList[0].ImdbId;


            await DataStore.AddItemAsync(newMovie);
                      

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
