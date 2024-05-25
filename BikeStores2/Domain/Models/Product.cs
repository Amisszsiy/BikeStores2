using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeStores2.Domain.Models
{
    [Table("products", Schema = "production")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int product_id { get; set; }
        [Column("product_name")]
        public required string product_name { get; set; }
        [Column("brand_id")]
        public required int brand_id { get; set; }
        [Column("category_id")]
        public required int category_id { get; set; }
        [Column("model_year")]
        public required Int16 model_year { get; set; }
        [Column("list_price")]
        public required decimal list_price { get; set; }
    }
}
