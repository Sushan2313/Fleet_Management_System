using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FM.Modles
{
    [Table("City_Master")]
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CityId { get; set; }
        
        public string CityName { get; set; }

        
        public long State_ID { get; set; }
        [ForeignKey("State_ID")]
        public virtual State State { get; set; }

        // Default constructor (needed by EF Core)

        // ToString method
        public override string ToString()
        {
            return $"City [CityId={CityId}, CityName={CityName}, State={State}]";
        }
    }
}
