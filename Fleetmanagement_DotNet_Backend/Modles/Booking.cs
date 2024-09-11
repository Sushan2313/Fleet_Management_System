using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FM.Modles
{
    [Table("booking")]
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("booking_id")]
        public long BookingId { get; set; }

        [Column("booking_date")]
        public DateTime BookingDate { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("state")]
        public string State { get; set; }

        [Column("pin")]
        public string Pin { get; set; }

        [Column("daily_rate")]
        public decimal DailyRate { get; set; }

        [Column("weekly_rate")]
        public decimal WeeklyRate { get; set; }

        [Column("monthly_rate")]
        public decimal MonthlyRate { get; set; }

        [Column("Email_ID")]
        public string EmailId { get; set; }

        [Column("p_hubId")]
        public long PHubId { get; set; }

        [Column("r_hubId")]
        public long RHubId { get; set; }

        [ForeignKey("Customer")]
        [Column("cust_id")]
        public long CustomerId { get; set; }

        [ForeignKey("CarType")]
        [Column("cartype_id")]
        public long CarTypeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CarType CarType { get; set; }
    }
}
