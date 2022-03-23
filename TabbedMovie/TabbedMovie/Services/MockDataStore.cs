using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabbedMovie.Data;
using TabbedMovie.Models;

namespace TabbedMovie.Services
{
    public class MockDataStore : IDataStore<Movie>
    {
        private MovieContext movieContext;
        
        public MockDataStore()
        {
            movieContext = new MovieContext();
        }

        public async Task<bool> AddItemAsync(Movie item)
        {
            movieContext.Movies.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Movie item)
        {
            var oldItem = movieContext.Movies.Where((Movie arg) => arg.Id == item.Id).FirstOrDefault();
            movieContext.Movies.Remove(oldItem);
            movieContext.Movies.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = movieContext.Movies.Where((Movie arg) => arg.Id == id).FirstOrDefault();
            movieContext.Movies.RemoveRange(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Movie> GetItemAsync(int id)
        {
            return await Task.FromResult(movieContext.Movies.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Movie>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(movieContext.Movies);
        }
    }
}