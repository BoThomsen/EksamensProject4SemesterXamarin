using PlantProject.Models;
using PlantProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlantProject.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Plant plant { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}