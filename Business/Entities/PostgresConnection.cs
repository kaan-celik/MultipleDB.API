using MultipleDB.API.Business.Interfaces;
using MultipleDB.API.Database.Postgres;
using MultipleDB.API.Database.Postgres.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDB.API.Business.Entities
{
    public class PostgresConnection : IDBContext
    {
        private readonly PostgreSqlContext _context;
        public PostgresConnection(PostgreSqlContext context)
        {
            _context = context;
        }

        public void Add(object data)
        {
            Users user = data as Users;
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public void DeleteByID(int ID)
        {
            var selectedUser = _context.User.FirstOrDefault(t => t.GetID() == ID);
            _context.User.Remove(selectedUser);
            _context.SaveChanges();
        }


        public List<Users> GetAll<Users>()
        {
            return _context.User as List<Users>;             
        }

        public object GetSingle(int ID)
        {            
            return _context.User.FirstOrDefault(t => t.GetID() == ID);
        }

        public void Update(object data)
        {
            Users user = data as Users;
            _context.User.Update(user);
            _context.SaveChanges();
        }
    }
}
