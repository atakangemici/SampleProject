using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model.DbModel
{
    public class Users : BaseEntity
    {
        public string Name { get; set; }

        public string SureName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool HasAdminRights { get; set; }
    }
}
