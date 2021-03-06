using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TabbedMovie.Models;
using TabbedMovie.Views;
using Xamarin.Forms;

namespace TabbedMovie.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Movie _selectedItem;
        public Command DeleteCommand { get; }
        public ObservableCollection<Movie> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Movie> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Movie>();
            LoadItemsCommand = new Command(() => ExecuteLoadItemsCommand());
            DeleteCommand = new Command(OnDeleteMovie);
            ItemTapped = new Command<Movie>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
        }

        private void OnDeleteMovie(object obj)
        {
            var movie = obj as Movie;

            DataStore.DeleteItemAsync(movie.Id);
            Items.Remove(movie);

        }

        async void ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync();

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Movie SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Movie item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}