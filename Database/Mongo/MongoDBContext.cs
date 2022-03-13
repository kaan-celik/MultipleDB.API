using MongoDB.Driver;
using MultipleDB.API.Database.Mongo.Models;
using MultipleDB.API.Settings.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDB.API.Database.Mongo
{
    public class MongoDBContext
    {
        public readonly IMongoCollection<Teams> mongoCollection;

        public MongoDBContext(IDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            mongoCollection = database.GetCollection<Teams>(settings.CollectionName);
        }
    }
}
