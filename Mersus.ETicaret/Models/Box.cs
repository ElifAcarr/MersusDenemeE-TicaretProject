using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mersus.ETicaret.Models
{
    public class Box
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }

        //[ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
    }
}
