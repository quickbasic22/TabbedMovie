using System;
using System.Collections.Generic;
using TabbedMovie.Models;
using Xamarin.Forms;
using System.Linq;
using TabbedMovie.Data;

namespace TabbedMovie.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string id;
        private string title;
        private int year;
        private string imdb_id;

        public NewItemViewModel()
        {
            id = "4";
            title = "Movie Title";
            year = 2022;
            imdb_id = "tt9847360";
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(MovieTitle)
                && !String.IsNullOrWhiteSpace(Imdb_Id);
        }

        public string Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string MovieTitle
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public int Year 
        {
            get => year;
            set => SetProperty(ref year, value);
        }

        public string Imdb_Id
        {
            get => imdb_id;
            set => SetProperty(ref imdb_id, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            
                Movie newItem = new Movie()
                {
                    Id = int.Parse(Id),
                    Title = MovieTitle,
                    Year = Year,
                    Imdb_Id = Imdb_Id
                };

            await DataStore.AddItemAsync(newItem);
                      

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
