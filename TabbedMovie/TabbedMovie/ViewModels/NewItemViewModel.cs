using System;
using System.Collections.Generic;
using TabbedMovie.Models;
using Xamarin.Forms;
using System.Linq;
using TabbedMovie.Data;
using QuickType1;
using System.ComponentModel.DataAnnotations;

namespace TabbedMovie.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string movietitle;
        private int movieyear;
        private string movieimdb_id;
        private List<MovieResult> movieresults;
        public Command SaveCommand { get; }
        //public Command CancelCommand { get; }

        public NewItemViewModel()
        {
            movietitle = "Movie title";
            movieyear = 2022;
            movieimdb_id = "sddxfx999";
            SaveCommand = new Command(OnSave, ValidateSave);
            //CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        
        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(movietitle)
                && !String.IsNullOrWhiteSpace(movieimdb_id);
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

        
        //private async void OnCancel()
        //{
        //    // This will pop the current page off the navigation stack
        //    await Shell.Current.GoToAsync("..");
        //}

        private async void OnSave()
        {
            var movie = new QuickType1.MovieResult();
            var newMovie = new Movie();
            var movieList = MovieResult.ToList();
            newMovie.Title = movieList[0].Title;
            newMovie.Year = (int)movieList[0].Year;
            newMovie.Imdb_Id = movieList[0].ImdbId;


            await DataStore.AddItemAsync(newMovie);
                      

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
