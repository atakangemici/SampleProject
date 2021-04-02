using Sample.Model.Entities;
using Sample.Model.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Model.Repositories
{
    public class AppRepository : IAppRepository
    {
        SampleDbContext dbContext = new SampleDbContext();
        public async Task<List<Products>> GetProducts()
        {
            var products = await dbContext.Products.Where(x => !x.Deleted).ToListAsync();

            return products;
        }

        public async Task<Users> GetUser(string email, string password)
        {
            var user = await dbContext.Users.Where(x => !x.Deleted && x.Email == email && x.Password == password).FirstOrDefaultAsync();

            return user;
        }
    }
}
