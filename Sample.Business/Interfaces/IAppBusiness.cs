using Sample.App.Models;
using Sample.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Business.Interfaces
{
    public interface IAppBusiness
    {
        Task<AdminValidModels> IsValidAdmin(Users User);
    }
}
