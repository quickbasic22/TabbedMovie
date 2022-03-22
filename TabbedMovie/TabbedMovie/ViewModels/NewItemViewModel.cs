using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TabbedMovie.Models;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;

namespace TabbedMovie.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private int id;
        private string title;
        private int year;
        private string imdb_id;

        public NewItemViewModel()
        {
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

        public int Id
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
            var lastId = 0;
            try
            {
                var movie = App.DataStore.Movies.ToList();
                if (movie.Count > 0)
                {
                    lastId = movie.LastOrDefault().Id;
                }
                else
                {
                    lastId = 1;
                }
               

                Movie newItem = new Movie()
                {
                    Id = lastId,
                    Title = MovieTitle,
                    Year = Year,
                    Imdb_Id = Imdb_Id
                };
                newItem.Id = Id;
                await App.DataStore.Movies.AddAsync(newItem);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
