using Sample.Model.Entities;
using System.Collections.Generic;

namespace Sample.Model.Models
{
    public class ValidModel
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public string ImageName { get; set; }
        public List<Products> Products { get; set; }
        public List<Users> Users { get; set; }
        public Products Product { get; set; }
        public Users User { get; set; }

    }
}