using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeStores2.Domain.Models
{
    [Table("brands", Schema = "production")]
    public class Brand
    {
        [Key]
        [Column("brand_id")]
        public int Id { get; set; }
        [Column("brand_name")]
        public required string Name { get; set; }
    }
}
