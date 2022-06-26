using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace migration
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public virtual IList<Product> Products {get;set;}
        public CategoryDetail CategoryDetail {get;set;}
    }    
}