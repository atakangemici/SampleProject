using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model.DbModel
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public int? Owner { get; set; }

        public int? CreatedById { get; set; }

        public int? UpdatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool Deleted { get; set; }
    }
}
