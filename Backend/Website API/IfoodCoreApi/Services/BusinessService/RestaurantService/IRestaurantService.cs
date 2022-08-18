using IfoodCoreApi.Infra.Repository;
using IfoodCoreApi.Models.Business.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfoodCoreApi.Services.BusinessService.RestaurantService
{
    public interface IRestaurantService : IBusinessService<Restaurant>
    {
        Task<Restaurant> GetByName(string name);
        Task<IEnumerable<Restaurant>> GetByCategory(int category);
    }
}
