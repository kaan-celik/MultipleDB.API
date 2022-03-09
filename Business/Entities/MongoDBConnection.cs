using MultipleDB.API.Business.Interfaces;
using MultipleDB.API.Database.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDB.API.Business.Entities
{
    public class MongoDBConnection : IDBContext
    {
        public MongoDBConnection(MongoDBContext context)
        {

        }

        public void Add(object data)
        {
            throw new NotImplementedException();
        }

        public void DeleteByID(int ID)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public object GetSingle(int ID)
        {
            throw new NotImplementedException();
        }

        public void Update(object data)
        {
            throw new NotImplementedException();
        }
    }
}
