using System;
using System.Collections.Generic;
using System.Text;

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PlantProject.Models
{
    public class Plant
    {
       
        public string PlantNo { get; set; }
 
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public string SoilMoisture { get; set; }
        public DateTime Date { get; set; }


    }
}
