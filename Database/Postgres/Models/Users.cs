using MultipleDB.API.Business.Utility.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDB.API.Database.Postgres.Models
{
    public class Users
    {
        private int ID { get; set; }
        private string Name { get; set; }
        private DateTime CreatedDate { get; set; }
        private string Email { get; set; }
        private Groups Group { get; set; }
        private Roles Role { get; set; }

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

        public int GetID()
        {
            return this.ID;
        }
        public string GetName()
        {
            return this.Name;
        }
        public DateTime GetCreatedDate()
        {
            return this.CreatedDate;
        }
        public string GetEmail()
        {
            return this.Email;
        }

        public Groups GetGroups()
        {
            return this.Group;
        }

        public Roles GetRoles()
        {
            return this.Role;
        }

        public void SetID(int ID)
        {
            this.ID = ID;
        }
        public void SetName(string Name)
        {
            this.Name = Name;
        }
        public void SetCreatedDate(DateTime CreatedDate)
        {
            this.CreatedDate = CreatedDate;
        }
        public void SetEmail(string Email)
        {
            this.Email = Email;
        }

        public void SetGroup(Groups Group)
        {
            this.Group = Group;
        }

        public void SetRole(Roles Role)
        {
            this.Role = Role;
        }


    }
}
