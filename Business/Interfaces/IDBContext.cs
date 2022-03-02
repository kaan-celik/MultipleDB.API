using MultipleDB.API.Database.Postgres.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDB.API.Business.Interfaces
{
    public interface IDBContext
    {
        void Add(Object data);
        void Update(Object data);
        void DeleteByID(int ID);
        Object GetSingle(int ID);
        List<T> GetAll<T>();
    }
}
