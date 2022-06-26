using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef
{   
    [Table("CategoryDetail")]
    public class CategoryDetail 
    {
        [Key]
        public int CategoryDetailId { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        [Column(TypeName ="ntext")]
        public DateTime  Date_Update { get; set; }
        public Category category {get;set;}
    }
    
}