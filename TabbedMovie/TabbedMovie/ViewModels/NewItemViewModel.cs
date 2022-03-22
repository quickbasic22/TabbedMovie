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
            return !String.IsNullOrWhiteSpace(title)
                && !String.IsNullOrWhiteSpace(imdb_id);
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
            var nextId = 0;
            try
            {
                var movie = App.DataStore.Movies.ToList();
                if (movie.Count > 0)
                {
                    var lastId = movie.LastOrDefault().Id;
                    nextId = lastId++;
                }
                else
                {
                    nextId = 1;
                }
               

                Movie newItem = new Movie()
                {
                    Id = nextId,
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
