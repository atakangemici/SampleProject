using Sample.App.Models;
using Sample.Business.Interfaces;
using Sample.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Business.BusinessLogic
{
    public class AppBusiness : IAppBusiness
    {

        public async Task<AdminValidModels> IsValidAdmin(Users User)
        {
            AdminValidModels adminValid = new AdminValidModels();

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
    }


}
