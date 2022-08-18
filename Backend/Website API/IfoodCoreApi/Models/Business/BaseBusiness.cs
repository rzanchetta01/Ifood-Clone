using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfoodCoreApi.Models.Business
{
    public abstract class BaseBusiness
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public short Rating { get; set; }
        public int Id_Category { get; set; }
        public int Id_ServiceAvgValue { get; set; }

        protected BaseBusiness(string name,
            string adress,
            short rating,
            int category,
            int serviceAvgValue)
        {
            Id = 0;
            Name = name;
            Adress = adress;
            Rating = rating;
            Id_Category = category;
            Id_ServiceAvgValue = serviceAvgValue;
        }

        public BaseBusiness()
        {

        }
    }
}
