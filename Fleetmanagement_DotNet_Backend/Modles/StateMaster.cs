using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FM.Modles
{
    [Table("State_Master")]
    public class State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long StateId { get; set; }

        [Required]
        [JsonPropertyName("stateName")]
        //[Index(IsUnique = true)] // Ensures stateName is unique
        public string StateName { get; set; }

        // Default constructor

        // Override ToString method (optional)
        public override string ToString()
        {
            return $"State [StateId={StateId}, StateName={StateName}]";
        }
    }
}
