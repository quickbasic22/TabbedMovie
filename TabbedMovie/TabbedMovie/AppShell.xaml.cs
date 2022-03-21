using System;
using System.Collections.Generic;
using TabbedMovie.ViewModels;
using TabbedMovie.Views;
using Xamarin.Forms;

namespace TabbedMovie
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
