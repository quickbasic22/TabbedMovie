using System.ComponentModel;
using TabbedMovie.ViewModels;
using Xamarin.Forms;

namespace TabbedMovie.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}