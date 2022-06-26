using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef
{   
    [Table("Category")]
    public class Category 
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName ="ntext")]
        public string  Description { get; set; }

        // collect Navigation: Dieu huong tap hop: Khong tao ra tren sql
        public virtual List<Product> Products {get;set;}
        public CategoryDetail categoryDetail {get;set;}
    }
    
}