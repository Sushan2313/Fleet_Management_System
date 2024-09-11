using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FM.Modles
{
    public class Hub
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long HubId { get; set; }

        [Required]
        public string HubName { get; set; }

        [Column("Hub_Address_and_Details", TypeName = "TEXT")]
        public string HubAddressAndDetails { get; set; }

        [Required]
        [Column("contactNumber")]
        //[Index(IsUnique = true)] // Unique constraint on contactNumber
        public long? ContactNumber { get; set; }

        // Foreign key properties
        public long? CityId { get; set; }
        public long? StateId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [ForeignKey("StateId")]
        public virtual State State { get; set; }

        // Constructors

        // Getters and setters (Auto-implemented properties are used)

        public override string ToString()
        {
            return $"Hub{{hubId={HubId}, hubName='{HubName}', hubAddressAndDetails='{HubAddressAndDetails}', contactNumber={ContactNumber}, city={City}, state={State}}}";
        }
    }

}
