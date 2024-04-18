using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_DBApp.Models
{
    [Table("Users")]
    
    public class Users
    {
        [Key] // Specify that this property is the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Specify that the value is auto-generated
        public decimal user_id{ get; set; }

        public string? user_type { get; set; }

        public string? username { get; set; }

        public decimal? salary { get; set; }
             
        public string? job_title { get; set; }

        public string? home_address { get; set; }

        public string? delivery_address { get; set; }

        public string? payment_address { get; set; }

    }
    
}
