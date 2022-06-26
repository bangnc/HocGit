using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace migration
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [StringLength(1000)]
        public DateTime UpdateDate { get; set; }
        // khoa ngoai
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}