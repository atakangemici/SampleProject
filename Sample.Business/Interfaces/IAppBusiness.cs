using Sample.App.Models;
using Sample.Model.Entities;
using System.Threading.Tasks;
using System.Web;

namespace Sample.Business.Interfaces
{
    public interface IAppBusiness
    {
        Task<AdminValidModel> IsValidAdmin(Users User);
        Task<Products> CreateProductDataGenerate(Products Product, int userId, string fileName);
        Task<Products> UpdateProductDataGenerate(Products Product, Products currentProduct);
        Task<string> UploadImages(HttpPostedFileBase file);

    }
}
