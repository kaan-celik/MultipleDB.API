using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultipleDB.API.Business.Entities;
using MultipleDB.API.Business.Interfaces;
using MultipleDB.API.Database.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDB.API.Controllers
{
    
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IDBContext mongoAccessProvider;

        public TeamController(IDBContext _mongoAccessProvider)
        {
            DatabaseFactory databaseFactory = new PostgresFactory();
            mongoAccessProvider = databaseFactory.CreateDatabase(_mongoAccessProvider);
        }


        [HttpGet]
        [Route("api/Team/GetAllTeams")]
        public List<Teams> GetAllTeams()
        {
            try
            {
                return mongoAccessProvider.GetAll<Teams>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [Route("api/Team/GetTeam")]
        public Teams GetTeam(string id)
        {
            try
            {
                return mongoAccessProvider.GetSingle(id) as Teams;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpPost]
        [Route("api/Team/AddTeam")]
        public IActionResult AddTeam([FromBody] Teams team)
        {
            try
            {
                mongoAccessProvider.Add(team);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPost]
        [Route("api/Team/UpdateTeam")]
        public IActionResult UpdateTeam([FromBody] Teams team)
        {
            try
            {
                mongoAccessProvider.Update(team);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }


        [HttpDelete]
        [Route("api/Team/DeleteTeam")]
        public IActionResult DeleteTeam(string id)
        {
            try
            {
                mongoAccessProvider.DeleteByID(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
    }
}
