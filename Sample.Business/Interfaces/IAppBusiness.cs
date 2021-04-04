using Sample.App.Models;
using Sample.Model.Entities;
using System.Threading.Tasks;

namespace Sample.Business.Interfaces
{
    public interface IAppBusiness
    {
        Task<AdminValidModel> IsValidAdmin(Users User);
        Task<Products> CreateProductDataGenerate(Products Product, int userId);
        Task<Products> UpdateProductDataGenerate(Products Product, Products currentProduct);
    }
}
