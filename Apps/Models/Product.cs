using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        [Column("Tensanpham",TypeName="ntext")]
        public string Name {get;set;}
        [StringLength(50)]
        [Column(TypeName="money")]
        public decimal Price { get; set; }

        public int CateId {get; set;}
        public virtual Category Category {get;set;}  // FK -> PK
        public void PrintInfo()
        {
            Console.WriteLine($" {ProductId} - {Name} - {Price}");
        }
    }
}
/*
 table
 key
 require
 stringlength
*/
