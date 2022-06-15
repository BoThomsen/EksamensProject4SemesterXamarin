using PlantProject.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PlantProject.Views
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