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

        public Users(){}

        public Users(int ID, string Name , DateTime CreatedDate)
        {
            this.ID = ID;
            this.Name = Name;
            this.CreatedDate = CreatedDate;
        }

        public int getID()
        {
            return this.ID;
        }
        public string getName()
        {
            return this.Name;
        }
        public DateTime getCreatedDate()
        {
            return this.CreatedDate;
        }
        public void setID(int ID)
        {
            this.ID = ID;
        }
        public void setName(string Name)
        {
            this.Name = Name;
        }
        public void setCreatedDate(DateTime CreatedDate)
        {
            this.CreatedDate = CreatedDate;
        }
        

    }
}
