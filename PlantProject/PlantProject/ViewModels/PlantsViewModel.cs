using PlantProject.Models;
using PlantProject.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using PlantProject.Services;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlantProject.ViewModels
{
    public class PlantsViewModel : BaseViewModel
    {
        private Plant _selectedPlant;

        public ObservableCollection<Plant> Plants { get; }
        public Command LoadPlantsCommand { get; }
        public Command AddPlantsCommand { get; }
        public Command<Plant> PlantTapped { get; }


        public PlantsViewModel()
        {
            Title = "Plants";
            Plants = new ObservableCollection<Plant>();

            //  LoadPlantsCommand = new Command(async () => await ExecuteLoadPlantCommand());

            LoadPlantsCommand = new Command(async () => await ExecuteLoadPlantCommand());
            PlantTapped = new Command<Plant>(OnPlantSelected);

            AddPlantsCommand = new Command(OnAddPlant);



        }
/*
        public void getAllPlants()
        {
            Plants.Clear();

            Plant pl = new Plant
            {
                PlantNo = "3",
                Humidity = 44.5,
                Temperature = 22.4,
                SoilMoisture = "Dry",
                Date = DateTime.Now
            };



            Plants.Add(pl);
        }
*/

        async Task ExecuteLoadPlantCommand()
        {
            IsBusy = true;
            try
            {
                Plants.Clear();
                //getting plants 

                    var httpResponse = await ConMiddleware.GetPlants();
                    Console.WriteLine(httpResponse);
                    string responsePayload = await httpResponse.Content.ReadAsStringAsync();

                //json to list 
                var allPlants = JsonConvert.DeserializeObject<List<Plant>>(responsePayload);

                Console.WriteLine(allPlants.Capacity);

                foreach (var plant in allPlants)
               {
                    Plant pl = new Plant();
                    Console.WriteLine("hallo " + plant.PlantNo);
                    pl.PlantNo = plant.PlantNo;
                    pl.Temperature = plant.Temperature;
                    pl.Humidity = plant.Humidity;
                    pl.SoilMoisture = plant.SoilMoisture;
                    pl.Date = plant.Date;

                    Plants.Add(plant);
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
            SelectedPlant = null;
        }

        public Plant SelectedPlant
        {
            get => _selectedPlant;
            set
            {
                SetProperty(ref _selectedPlant, value);
                OnPlantSelected(value);
            }
        }

        private async void OnAddPlant(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnPlantSelected(Plant plant)
        {
            if (plant == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.PlantId)}={Plant.Id}");
        }
    }
}