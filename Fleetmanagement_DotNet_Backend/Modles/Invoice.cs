using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FM.Modles
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long InvoiceId { get; set; }

        [Required]
        [StringLength(100)] // Adjust length as needed
        public string EmpName { get; set; }

        [Required]
        [StringLength(100)] // Adjust length as needed
        public string CName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)] // Adjust length as needed
        public string CEmailId { get; set; }

        [Required]
        [Phone]
        [StringLength(15)] // Adjust length as needed
        public string CMobileNo { get; set; }

        [Required]
        [StringLength(20)] // Adjust length as needed
        public string CAadharNo { get; set; }

        [Required]
        [StringLength(20)] // Adjust length as needed
        public string CPassNo { get; set; }

        public double RentalAmount { get; set; }

        public double TotalAmount { get; set; }

        public double TotalAddonAmount { get; set; }

        public double Rate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime HandoverDate { get; set; }

        public DateTime EndDate { get; set; }

        public long BookId { get; set; }

        public long CarId { get; set; }

        public long CustomerId { get; set; }

        public long PHubId { get; set; }

        public long RHubId { get; set; }

        [Column("isReturned")]
        public ReturnStatus IsReturned { get; set; }

        public enum ReturnStatus
        {
            Y, N
        }

        // Navigation properties (if needed)
        // Uncomment if you want to use them
        // [ForeignKey("BookingId")]
        // public virtual Booking Booking { get; set; }
        
        // [ForeignKey("CarId")]
        // public virtual Car Car { get; set; }

        // [ForeignKey("CustomerId")]
        // public virtual Customer Customer { get; set; }
    }
}
