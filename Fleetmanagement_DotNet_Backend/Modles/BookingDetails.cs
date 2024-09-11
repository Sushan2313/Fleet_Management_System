using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FM.Modles
{
    [Table("booking_detail")]
    public class BookingDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("booking_detail_id")]
        public long BookingDetailId { get; set; }

        [ForeignKey("Booking")]
        [Column("booking_id")]
        public long BookingId { get; set; }

        public virtual Booking Booking { get; set; }

        [Column("addon_id")]
        public long AddonId { get; set; }

        [Column("addon_rate")]
        public decimal AddonRate { get; set; }

        // Constructors
    }
}
