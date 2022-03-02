using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultipleDB.API.Business.Entities;
using MultipleDB.API.Business.Interfaces;
using MultipleDB.API.Database.Postgres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDB.API.Controllers
{
    
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IDBContext _dataAccessProvider;

        public UserController(IDBContext dataAccessProvider)
        {
            DatabaseFactory databaseFactory = new PostgresFactory();
            _dataAccessProvider = databaseFactory.CreateDatabase(dataAccessProvider);
        }



        [Route("api/User/GetUsers")]
        public List<Users> GetUsers()
        {           
            return _dataAccessProvider.GetAll<Users>();
        }

    }
}
