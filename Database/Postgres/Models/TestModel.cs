using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDB.API.Database.Mongo.Models
{
    public class TestModel
    {
        private int ID { get; set; }
        private string Value { get; set; }

        public TestModel()
        {

        }

        public int getID()
        {
            return this.ID;
        }

        public string getValue()
        {
            return this.Value;
        }

        public void setID(int ID)
        {
            this.ID = ID;
        }

        public void setValue(string Value)
        {
           this.Value = Value;
        }
    }
}
