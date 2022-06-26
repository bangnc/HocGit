using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace migration
{
    [Table("Customer")]
    public class Customer
    {       
        [Key]
        public int CustomerId { get; set; }
        [StringLength(1000)]
        public string Name { get; set; }
         public IList<Order> Orders { get; set; }
    }    
}