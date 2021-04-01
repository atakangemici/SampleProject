using Sample.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model.Interfaces
{
    public interface IAppRepository
    {
        Task<List<Products>> Products();
    }
}
