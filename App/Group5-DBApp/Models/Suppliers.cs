using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_DBApp.Models
{
    [Table("Suppliers")]
    
    public class Suppliers
    {
        [Key] // Specify that this property is the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Specify that the value is auto-generated
        public decimal sup_id{ get; set; }

        public string? name { get; set; }

        public decimal prod_id { get; set; }

        public decimal price { get; set; }

        public string? address { get; set; }

    }
    
}
