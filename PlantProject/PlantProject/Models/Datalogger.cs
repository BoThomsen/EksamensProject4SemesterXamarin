using System;
using System.Collections.Generic;
using System.Text;

namespace PlantProject.Models
{
    public class Datalogger
    {
        public string PlantNo { get; set; }

        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public string SoilMoisture { get; set; }
        public DateTime Date { get; set; }

    }
}
