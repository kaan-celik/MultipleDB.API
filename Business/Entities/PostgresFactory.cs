using MultipleDB.API.Business.Interfaces;
using MultipleDB.API.Database.Postgres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDB.API.Business.Entities
{
    public class PostgresFactory : DatabaseFactory
    {
        public override IDBContext CreateDatabase(Object context)
        {
            PostgreSqlContext _context = context as PostgreSqlContext;
            return new PostgresConnection(_context);
        }
    }
}
