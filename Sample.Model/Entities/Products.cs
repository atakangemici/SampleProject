using System.ComponentModel.DataAnnotations.Schema;


namespace Sample.Model.Entities
{
    public class Products : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("barcode")]
        public string Barcode { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("pictures")]
        public string Pictures { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

    }
}
