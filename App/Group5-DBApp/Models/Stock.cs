using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_DBApp.Models
{
    [Table("Stock")]
    
    public class Stock
    {
        [Key] // Specify that this property is the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Specify that the value is auto-generated
        public decimal stock_id{ get; set; }

        public decimal prod_id { get; set; }

        public decimal warehouse_id { get; set; }

        public decimal quantity { get; set; } 

    }
    
}
