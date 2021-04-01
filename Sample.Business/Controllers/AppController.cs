using Sample.App.Models;
using Sample.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Business.Controllers
{
    public class AppController
    {
        public static async Task<AdminValidModels> IsValidAdmin(Users User)
        {
            AdminValidModels adminValid = new AdminValidModels();

            if (!User.HasAdminRights)
            {
                adminValid.Status = false;
                adminValid.Message = "Admin panele giriş için yetkiniz bulunmuyor.";

            }
            else
            {
                adminValid.Status = true;
                adminValid.Message = "Admin panele giriş başarılı.";
            }

            return adminValid;

        }

    }
}
