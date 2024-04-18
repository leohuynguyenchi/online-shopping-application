using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group5_DBApp.Models
{
    [Table("CreditCards")]
    public class CreditCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardId { get; set; }

        public int UserId { get; set; }

        public string? CardNumber { get; set; }

        public string? ExpireDate { get; set; }
    }
}
