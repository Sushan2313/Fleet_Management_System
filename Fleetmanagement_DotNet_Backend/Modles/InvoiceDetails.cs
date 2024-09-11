using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FM.Modles
{
    [Table("Invoice_detail")]
    public class InvoiceDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdetailId { get; set; }

        [Required]
        public long InvoiceId { get; set; }

        [Required]
        public long AddonId { get; set; }

        [Required]
        public long Amt { get; set; }

        // Navigation properties (if needed)
        // Uncomment if you want to use them
        // [ForeignKey("InvoiceId")]
        // public virtual Invoice Invoice { get; set; }

        // [ForeignKey("AddonId")]
        // public virtual AddOn Addon { get; set; }
    }
}
