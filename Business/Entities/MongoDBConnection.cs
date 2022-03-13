using MongoDB.Bson;
using MongoDB.Driver;
using MultipleDB.API.Business.Interfaces;
using MultipleDB.API.Database.Mongo;
using MultipleDB.API.Database.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDB.API.Business.Entities
{
    public class MongoDBConnection : IDBContext
    {
        private MongoDBContext context;
        public MongoDBConnection(MongoDBContext _context)
        {
            context = _context;
        }


        #region CRUD
        public void Add(object data)
        {
            Teams team = data as Teams;
            context.mongoCollection.InsertOne(team);
        }

        public void DeleteByID(Object ID)
        {
            string objectID = ID.ToString();
            context.mongoCollection.DeleteOne(m => m.ID == objectID);
        }

        public List<Teams> GetAll<Teams>()
        {
            return context.mongoCollection.Find(new BsonDocument()).ToList() as List<Teams>;
        }

        public object GetSingle(Object ID)
        {
            string objectID = ID.ToString();
            return context.mongoCollection.Find<Teams>(m => m.ID == objectID).FirstOrDefault();
        }

        public void Update(object data)
        {
            Teams team = data as Teams;
            var filter = Builders<Teams>.Filter.Eq(g => g.ID, team.ID);
            context.mongoCollection.ReplaceOne(filter, team);
        }
        #endregion

    }
}
