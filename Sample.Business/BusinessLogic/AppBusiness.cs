using Sample.Business.Interfaces;
using Sample.Model.Entities;
using Sample.Model.Models;
using System;
using System.Threading.Tasks;
using System.Web;

namespace Sample.Business.BusinessLogic
{
    public class AppBusiness : IAppBusiness
    {

        public async Task<ValidModel> IsValidAdmin(Users User)
        {
            ValidModel validData = new ValidModel();

            try
            {
                if (!User.HasAdminRights)
                {
                    validData.Status = false;
                    validData.Message = "Giriş için yetkiniz bulunmuyor.";
                }
                else
                {
                    validData.Status = true;
                    validData.Message = "Giriş başarılı.";
                }

                return validData;
            }

            catch (Exception ex)
            {

                validData.Status = false;
                validData.Message = "Admin yetki kontrolü sırasında hata alındı.";

                return validData;
            }

        }

        public async Task<ValidModel> CreateProductDataGenerate(Products Product, int userId, string fileName)
        {
            ValidModel validData = new ValidModel();

            try
            {
                Product.Pictures = fileName;
                Product.Owner = userId;
                Product.CreatedAt = DateTime.Now;

                validData.Product = Product;
                validData.Status = true;

                return validData;
            }
            catch (Exception ex)
            {
                validData.Status = false;
                validData.Message = "Ürün ekleme verisi hazırlanırken hata alındı.";

                return validData;
            }

        }

        public async Task<ValidModel> UpdateProductDataGenerate(Products Product, Products currentProduct)
        {
            ValidModel validData = new ValidModel();

            try
            {
                Product.Name = currentProduct.Name;
                Product.Barcode = currentProduct.Barcode;
                Product.Price = currentProduct.Price;
                Product.Quantity = currentProduct.Quantity;
                Product.Description = currentProduct.Description;
                Product.Deleted = currentProduct.Deleted;

                validData.Product = Product;
                validData.Status = true;

                return validData;
            }

            catch (Exception ex)
            {
                validData.Status = false;
                validData.Message = "Ürün güncelleme verisi hazırlanırken hata alındı.";

                return validData;
            }
        }

        public async Task<ValidModel> UploadImages(HttpPostedFileBase file)
        {
            ValidModel validData = new ValidModel();

            try
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

                validData.ImageName = imageName;
                validData.Status = true;

                return validData;
            }
            catch (Exception ex)
            {
                validData.Status = false;
                validData.Message = "Ürün fotoğrafı ekleme sırasında hata alındı.";

                return validData;
            }
        }
    }
}
