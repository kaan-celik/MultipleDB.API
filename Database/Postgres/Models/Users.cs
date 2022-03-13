using MultipleDB.API.Business.Utility.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDB.API.Database.Postgres.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public Groups Group { get; set; }
        public Roles Role { get; set; }

        public Users(){}

        public Users(int ID, string Name , DateTime CreatedDate, string Email, Groups Group, Roles Role)
        {
            this.ID = ID;
            this.Name = Name;
            this.CreatedDate = CreatedDate;
            this.Email = Email;
            this.Group = Group;
            this.Role = Role;
        }
    }
}
