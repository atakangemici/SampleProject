using Sample.Model.DbModel;
using Sample.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model.Repositories
{
    public class AppRepository : IAppRepository
    {
        SampleDbContext dbContext = new SampleDbContext();
        public async Task<List<Products>> Products()
        {
            var products = await dbContext.Products.Where(x => !x.Deleted).ToListAsync();

            return products;
        }
    }
}
