using BusinessBackendApi.Model;

namespace BusinessBackendApi.Infra.Interfaces
{
    public interface IRestaurantRepository<TRestaurant> : IBaseCrud<TRestaurant> where TRestaurant : Restaurant
    {
        
    }
}
