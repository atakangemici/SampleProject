﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sample.Model.Entities
{
    public class BaseEntity
    {
        [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("owner")]
        public int? Owner { get; set; }

        [Column("created_by")]
        public int? CreatedById { get; set; }

        [Column("updated_by")]
        public int? UpdatedById { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; }
    }
}
