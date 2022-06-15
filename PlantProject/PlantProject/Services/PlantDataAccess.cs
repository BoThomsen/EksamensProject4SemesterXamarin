using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using PlantProject.Models;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
//using MongoDataAccess.Models;

namespace PlantProject.Services
{
    public class PlantDataAccess
    {
        private const string ConnectionString = "mongodb://0.0.0.0:27017/";
        private const string DatabaseName = "PlantDatabase";
        private const string PlantCollection = "plants";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

         public async Task<List<Plant>> GetAllPlants()
         {
        var plantcollection = ConnectToMongo<Plant>(PlantCollection);
         var results = await plantcollection.FindAsync(_ => true);
           return results.ToList();
         }




    }



}

