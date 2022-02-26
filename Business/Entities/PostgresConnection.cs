using MultipleDB.API.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDB.API.Business.Entities
{
    public class PostgresConnection : IDBContext
    {
        public PostgresConnection()
        {

        }

        public void Connect() { }
    }
}
