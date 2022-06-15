using PlantProject.Models;
using PlantProject.ViewModels;
using PlantProject.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlantProject.Views
{
    public partial class PlantsPage : ContentPage
    {
        PlantsViewModel _viewModel;

        public PlantsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new PlantsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}