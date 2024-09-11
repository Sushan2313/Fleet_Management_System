using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FM.Modles;
    [Table("AddOn")]
    public class AddOn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AddonId { get; set; }

        [Required]
        [StringLength(255)]
        public string AddonName { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal AddonDailyRate { get; set; }

        public DateTime RateValidUntil { get; set; }

        public override string ToString()
        {
            return $"AddOn{{AddonId={AddonId}, AddonName='{AddonName}', AddonDailyRate={AddonDailyRate}, RateValidUntil={RateValidUntil}}}";
        }
    }

