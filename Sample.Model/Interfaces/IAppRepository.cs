using Sample.Model.Entities;
using Sample.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Model.Interfaces
{
    public interface IAppRepository
    {
        Task<ValidModel> GetProducts(bool hasAdminRights = false);
        Task<ValidModel> GetUser(string email, string password);
        Task<ValidModel> AddProduct(Products product);
        Task<ValidModel> DeleteProduct(int id);
        Task<ValidModel> GetProduct(int id);
        Task<ValidModel> UpdateProduct(Products product);
    }
}
