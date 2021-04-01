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
        public static async Task<string> IsValidAdmin(Users User)
        {
            if (!User.HasAdminRights)
                return "Admin panele giriş için yetkiniz bulunmuyor.";


            return true;
        }

    }
}
