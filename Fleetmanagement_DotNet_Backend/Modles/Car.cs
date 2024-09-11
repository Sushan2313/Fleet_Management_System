using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FM.Modles
{
    [Table("Car")]
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Car_ID")]
        public long CarId { get; set; }

        [ForeignKey("CarType")]
        [Column("CarType_ID")]
        public long CarTypeId { get; set; }

        public virtual CarType CarType { get; set; }

        [Column("Car_Name")]
        public string CarName { get; set; }

        [Column("Number_Plate")]
        [Required]
        public string NumberPlate { get; set; }

        [Column("Status")]
        public string Status { get; set; }

        [Column("Capacity")]
        public long Capacity { get; set; }

        [Column("Mileage")]
        public double Mileage { get; set; }

        [ForeignKey("Hub")]
        [Column("Hub_ID")]
        public long HubId { get; set; }

        public virtual Hub Hub { get; set; }

        [Column("Is_Available", TypeName = "char(1)")]
        public AvailabilityStatus IsAvailable { get; set; }

        [Column("Maintenance_Due_Date")]
        public DateTime MaintenanceDueDate { get; set; }

        public enum AvailabilityStatus
        {
            Y,
            N
        }
    }
}
