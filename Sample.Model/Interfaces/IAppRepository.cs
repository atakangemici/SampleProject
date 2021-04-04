using Sample.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Model.Interfaces
{
    public interface IAppRepository
    {
        Task<List<Products>> GetProducts();
        Task<Users> GetUser(string email, string password);
        Task<bool> AddProduct(Products product);
        Task<bool> DeleteProduct(int id);
        Task<Products> GetProduct(int id);
        Task<Products> UpdateProduct(Products product);
    }
}
