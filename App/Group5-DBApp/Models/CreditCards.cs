using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_DBApp.Models
{
    [Table("CreditCards")]
    
    public class CreditCards
    {
        [Key] // Specify that this property is the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Specify that the value is auto-generated
        public decimal card_id{ get; set; }

        public decimal user_id { get; set; }

        public string? card_number { get; set; }

        public string? expire_date { get; set; }

    }
    
}
