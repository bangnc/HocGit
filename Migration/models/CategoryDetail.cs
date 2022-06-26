using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace migration
{
    [Table("CategoryDetail")]
    public class CategoryDetail
    {
        [Key]
        public int CategoryDetailId { get; set; }
        [StringLength(1000)]
        public string Detail { get; set; }

        public Category Category {get;set;}
        public int CategoryId {get;set;}

    }    
}