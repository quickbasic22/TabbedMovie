using System;
using System.Collections.Generic;
using System.ComponentModel;
using TabbedMovie.Models;
using TabbedMovie.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedMovie.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Movie Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}