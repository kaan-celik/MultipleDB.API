using MultipleDB.API.Business.Interfaces;
using MultipleDB.API.Database.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDB.API.Business.Entities
{
    public class MongoFactory : DatabaseFactory
    {
        public override IDBContext CreateDatabase(Object context)
        {
            MongoDBContext _context = context as MongoDBContext;
            return new MongoDBConnection(_context);
        }
    }
}
