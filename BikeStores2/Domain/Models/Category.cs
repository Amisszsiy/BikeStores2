using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeStores2.Domain.Models
{
    [Table("categories", Schema = "production")]
    public class Category
    {
        [Key]
        [Column("category_id")]
        public int Id { get; set; }
        [Column("category_name")]
        public required string Name { get; set; }
    }
}
