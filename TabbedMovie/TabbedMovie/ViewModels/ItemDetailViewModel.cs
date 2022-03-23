using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TabbedMovie.Models;
using Xamarin.Forms;
using System.Linq;

namespace TabbedMovie.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
       
        private int itemId;
        private int id;
        private string title;
        private int year;
        private string imdb_id;

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

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            var detailMovie = await DataStore.GetItemAsync(itemId);
            try
            {
                Id = detailMovie.Id;
                MovieTitle = detailMovie.Title;
                Year = detailMovie.Year;
                Imdb_Id = detailMovie.Imdb_Id;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
