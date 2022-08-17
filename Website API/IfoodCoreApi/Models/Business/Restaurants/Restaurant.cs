using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfoodCoreApi.Models.Business.Restaurants
{
    [Table("tbRestaurants")]
    public class Restaurant : BaseBusiness
    {
        public Restaurant() : base ()
        {

        }

        public Restaurant(
            string name, string adress, short rating, short serviceAvgValue, short category) : base (name, adress, rating,
            category, serviceAvgValue)
        {

        }
    }
}
