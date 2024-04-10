using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_DBApp.Models
{
    [Table("Product")]
    
    public class Product
    {
        [Key] // Specify that this property is the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Specify that the value is auto-generated
        public decimal prod_id{ get; set; }

        public string? prod_name { get; set; }

        public decimal price { get; set; }
        
    }
    
}
