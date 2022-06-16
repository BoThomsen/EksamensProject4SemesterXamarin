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
 
        public string Name { get; set; }
        public double Price { get; set; }
        public string Certificate { get; set; }


    }
}
