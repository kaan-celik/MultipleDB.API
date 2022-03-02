using MultipleDB.API.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDB.API.Business.Entities
{
    public class MongoDBConnection : IDBContext
    {
        public MongoDBConnection()
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
