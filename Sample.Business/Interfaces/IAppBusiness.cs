using Sample.Model.Entities;
using Sample.Model.Models;
using System.Threading.Tasks;
using System.Web;

namespace Sample.Business.Interfaces
{
    public interface IAppBusiness
    {
        Task<ValidModel> IsValidAdmin(Users User);
        Task<ValidModel> CreateProductDataGenerate(Products Product, int userId, string fileName);
        Task<ValidModel> UpdateProductDataGenerate(Products Product, Products currentProduct);
        Task<ValidModel> UploadImages(HttpPostedFileBase file);
    }
}
