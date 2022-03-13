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

        private readonly IDBContext postgressAccessProvider;

        public UserController(IDBContext _postgressAccessProvider)
        {
            DatabaseFactory databaseFactory = new PostgresFactory();
            postgressAccessProvider = databaseFactory.CreateDatabase(_postgressAccessProvider);
        }


        [HttpGet]
        [Route("api/User/GetAllUsers")]
        public List<Users> GetAllUsers()
        {
            try
            {
                return postgressAccessProvider.GetAll<Users>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        [HttpGet]
        [Route("api/User/GetUser")]
        public Users GetUsers(int id)
        {
            try
            {
                return postgressAccessProvider.GetSingle(id) as Users;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }


        [HttpPost]
        [Route("api/User/AddUser")]
        public IActionResult AddUser([FromBody] Users user)
        {
            try
            {
                postgressAccessProvider.Add(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPost]
        [Route("api/User/UpdateUser")]
        public IActionResult UpdateUser([FromBody] Users user)
        {
            try
            {
                postgressAccessProvider.Update(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }


        [HttpDelete]
        [Route("api/User/DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                postgressAccessProvider.DeleteByID(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }



    }
}
