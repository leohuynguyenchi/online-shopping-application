using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_DBApp.Models
{
    [Table("Warehouse")]
    
    public class Warehouse
    {
        [Key] // Specify that this property is the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Specify that the value is auto-generated
        public decimal warehouse_id{ get; set; }

        public decimal? capacity { get; set; }

        public string? address { get; set; }
        
    }
    
}
