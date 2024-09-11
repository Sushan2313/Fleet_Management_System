using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FM.Modles
{
    [Table("Car_Type")]
    public class CarType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CarTypeId { get; set; }

        [Column("CarType_Name")]
        public string CarTypeName { get; set; }

        [Column("Daily_Rate")]
        public double DailyRate { get; set; }

        [Column("Weekly_Rate")]
        public double WeeklyRate { get; set; }

        [Column("Monthly_Rate")]
        public double MonthlyRate { get; set; }

        [Column("Image_Path")]
        public string ImagePath { get; set; }

        // Constructors

    }
}
