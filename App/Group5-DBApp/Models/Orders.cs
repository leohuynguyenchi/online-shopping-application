using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_DBApp.Models
{
    [Table("Orders")]
    
    public class Orders
    {
        [Key] // Specify that this property is the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Specify that the value is auto-generated
        public decimal order_id{ get; set; }

        public decimal user_id { get; set; }

        public decimal prod_id { get; set; }

        public decimal quantity { get; set; }

        public decimal credit_card { get; set; }

        public string? status { get; set; }

        public string? delivery_type { get; set; }

        public decimal delivery_price { get; set; }

        public string? ship_date { get; set; }

        public string? delivery_date { get; set; } 

    }
    
}
