using Sample.Model.Entities;
using Sample.Model.Interfaces;
using Sample.Model.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Model.Repositories
{
    public class AppRepository : IAppRepository
    {
        SampleDbContext dbContext = new SampleDbContext();
        public async Task<ValidModel> GetProducts(bool hasAdminRights = false)
        {
            ValidModel validData = new ValidModel();

            try
            {
                if (hasAdminRights)
                    validData.Products = await dbContext.Products.ToListAsync();
                else
                    validData.Products = await dbContext.Products.Where(x => !x.Deleted).ToListAsync();

                validData.Status = true;

                return validData;
            }
            catch (Exception ex)
            {
                validData.Status = false;
                validData.Message = "Ürünlerin listelenmesi işleminde hata alındı.";

                return validData;
            }
        }

        public async Task<ValidModel> GetUser(string email, string password)
        {
            ValidModel validData = new ValidModel();

            try
            {
                var user = await dbContext.Users.Where(x => !x.Deleted && x.Email == email && x.Password == password).FirstOrDefaultAsync();

                validData.User = user;
                validData.Status = false;

                return validData;

            }
            catch (Exception ex)
            {
                validData.Status = false;
                validData.Message = "Kullanıcı getirme işleminde hata alındı.";

                return validData;
            }
        }

        public async Task<ValidModel> AddProduct(Products product)
        {
            ValidModel validData = new ValidModel();

            try
            {
                dbContext.Products.Add(product);
                await dbContext.SaveChangesAsync();

                validData.Status = true;

                return validData;
            }
            catch (Exception ex)
            {
                validData.Status = false;
                validData.Message = "Ürünlerin eklenmesi işleminde hata alındı.";

                return validData;
            }
        }

        public async Task<ValidModel> DeleteProduct(int id)
        {

            ValidModel validData = new ValidModel();

            try
            {
                dbContext.Products.Remove(dbContext.Products.Find(id));

                await dbContext.SaveChangesAsync();

                validData.Status = true;

                return validData;
            }
            catch (Exception ex)
            {
                validData.Status = false;
                validData.Message = "Ürünlerin silinmesi işleminde hata alındı.";

                return validData;
            }
        }

        public async Task<ValidModel> GetProduct(int id)
        {

            ValidModel validData = new ValidModel();

            try
            {
                var product = await dbContext.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

                validData.Product = product;
                validData.Status = true;

                return validData;
            }
            catch (Exception ex)
            {

                validData.Status = false;
                validData.Message = "Ürün getirme işleminde hata alındı.";

                return validData;
            }
        }

        public async Task<ValidModel> UpdateProduct(Products product)
        {
            ValidModel validData = new ValidModel();

            try
            {
                await dbContext.SaveChangesAsync();

                validData.Product = product;
                validData.Status = true;

                return validData;
            }
            catch (Exception ex)
            {
                validData.Status = false;
                validData.Message = "Ürün güncelleme işleminde hata alındı.";

                return validData;
            }
        }
    }
}
