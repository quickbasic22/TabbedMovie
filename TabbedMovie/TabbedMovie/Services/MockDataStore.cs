using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabbedMovie.Models;

namespace TabbedMovie.Services
{
    public class MockDataStore : IDataStore<Movie>
    {
        readonly List<Movie> items;

        public MockDataStore()
        {
            items = new List<Movie>()
            {
                new Movie { Title = "First item", Year=DateTime.Now.AddYears(-7).Year, Imdb_Id = "dxdbdbsb20" },
                new Movie { Title = "Second item", Year=DateTime.Now.AddYears(-7).Year, Imdb_Id = "dbsdsbsdb23" },
                new Movie { Title = "Third item", Year=DateTime.Now.AddYears(-7).Year, Imdb_Id = "dbsdw2sdbsd"},
                new Movie { Title = "Fourth item", Year=DateTime.Now.AddYears(-7).Year, Imdb_Id = "dasbsdfsddfe"},
                new Movie { Title = "Fifth item", Year=DateTime.Now.AddYears(-7).Year, Imdb_Id = "dabdisdvsdddsb"},
                new Movie { Title = "Sixth item", Year=DateTime.Now.AddYears(-7).Year,  Imdb_Id = "dbsdfidsbsfdsffs"}
            };
        }

        public async Task<bool> AddItemAsync(Movie item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Movie item)
        {
            var oldItem = items.Where((Movie arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Movie arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Movie> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Movie>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}