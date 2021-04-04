using Sample.App.Models;
using Sample.Business.Interfaces;
using Sample.Model.Entities;
using System;
using System.Threading.Tasks;
using System.Web;


namespace Sample.Business.BusinessLogic
{
    public class AppBusiness : IAppBusiness
    {

        public async Task<AdminValidModel> IsValidAdmin(Users User)
        {
            AdminValidModel adminValid = new AdminValidModel();

            if (!User.HasAdminRights)
            {
                adminValid.Status = false;
                adminValid.Message = "Giriş için yetkiniz bulunmuyor.";
            }
            else
            {
                adminValid.Status = true;
                adminValid.Message = "Giriş başarılı.";
            }

            return adminValid;
        }

        public async Task<Products> CreateProductDataGenerate(Products Product, int userId, string fileName)
        {
            Product.Pictures = fileName;
            Product.Owner = userId;
            Product.CreatedAt = DateTime.Now;

            return Product;
        }

        public async Task<Products> UpdateProductDataGenerate(Products Product, Products currentProduct)
        {
            Product.Name = currentProduct.Name;
            Product.Barcode = currentProduct.Barcode;
            Product.Price = currentProduct.Price;
            Product.Quantity = currentProduct.Quantity;
            Product.Description = currentProduct.Description;
            Product.Deleted = currentProduct.Deleted;

            return Product;
        }

        public async Task<string> UploadImages(HttpPostedFileBase file)
        {
            var imageName = "";

            string fileName = Guid.NewGuid().ToString().Replace("-", "");
            var httpPostedFileBase = file;
            if (httpPostedFileBase != null)
            {
                string extension = System.IO.Path.GetExtension(httpPostedFileBase.FileName);
                string url = "~/assets/images/" + fileName + extension;
                httpPostedFileBase.SaveAs(System.Web.HttpContext.Current.Server.MapPath(url));

                imageName = fileName + extension;

            }

            return imageName;
        }
    }
}
