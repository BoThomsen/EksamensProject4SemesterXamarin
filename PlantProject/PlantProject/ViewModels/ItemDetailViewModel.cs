using PlantProject.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using PlantProject.Services;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microcharts.Forms;
using Microcharts;
using PlantProject.Views;
using System.Collections.ObjectModel;
using SkiaSharp;

namespace PlantProject.ViewModels
{
    //used for passing parameter from plantsviewmodel
    [QueryProperty(nameof(PlantNo), nameof(PlantNo))]

    public class ItemDetailViewModel : BaseViewModel
    {
        public List<Datalogger> Measurements { get; set; }

        public List<ChartEntry> Datalist { get; set; }
        private string plantNo;
        public string Id { get; set; }

        private Chart tempChart;
        public Chart TempChart
        {
            get { return tempChart; }
            set { tempChart = value; OnPropertyChanged(); }
        }
        public string PlantNo
        {
            get
            {
                return plantNo;
            }
            set
            {
                plantNo = value;
                OnPropertyChanged();
                LoadPlantChartData(value);
            }
        }

        public ItemDetailViewModel()
        {
           
            Measurements = new List<Datalogger>();

            Datalist = new List<ChartEntry>();


        }

        public async void LoadPlantChartData(string plantNo) {

            Measurements.Clear();
    
            try
            {

                //gets all datalogged data
                var httpResponse = await ConMiddleware.GetDatalogger();
                string responsePayload = await httpResponse.Content.ReadAsStringAsync();

                //json to list 
                var dataloggerData = JsonConvert.DeserializeObject<List<Datalogger>>(responsePayload);

                

                //binding all measurements to the right plant
                foreach (var Mes in dataloggerData)
                {
                    if ( plantNo == Mes.PlantNo)
                    {
                        Datalogger dat = new Datalogger();

                        dat.PlantNo = Mes.PlantNo;
                        dat.Temperature = Mes.Temperature;
                        dat.Humidity = Mes.Humidity;
                        dat.SoilMoisture = Mes.SoilMoisture;
                        dat.Date = Mes.Date;
  
                        Measurements.Add(dat);
                        

                    }
                }

                DrawChart();


            } catch (NullReferenceException e)
            {
                Debug.WriteLine("failed to load chart" + e);
            }


        }

        public void DrawChart()
        {

            
            //clearing our data before adding new data
            Datalist.Clear();


            //adding all measurements from the selected plant
            foreach (var Mes in Measurements)
            {

                float temp = Convert.ToSingle(Mes.Temperature);
                string stTemp = Convert.ToString(temp);
                string stDate = Convert.ToString(Mes.Date);

                Datalist.Add(new ChartEntry(temp)
                {
                    Label = stDate,
                    ValueLabel = stTemp + "°",
                    

                });

            }

            

            //makes the chart based on datalists data

            TempChart = new LineChart() { Entries = Datalist, ValueLabelOrientation = Orientation.Horizontal, LabelTextSize = 30 };

        }



    }
}
