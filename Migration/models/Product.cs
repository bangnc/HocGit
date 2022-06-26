using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace migration
{
    [Table("Product")]
    public class Product
    {      
        [Key]
        public int ProductId { get; set; }
        [StringLength(1000)]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public IList<Order> Orders { get; set; }
    }
}