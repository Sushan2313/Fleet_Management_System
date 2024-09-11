using FM.Modles;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Airport
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long AirportId { get; set; }

    [Required]
    [StringLength(10)]
    [Column(TypeName = "varchar(10)")]
    public string AirportCode { get; set; }

    [Required]
    [StringLength(255)]
    public string AirportName { get; set; }

    // Foreign key properties
    public long CityId { get; set; }
    public long StateId { get; set; }
    public long HubId { get; set; }

    [ForeignKey("CityId")]
    public virtual City City { get; set; }

    [ForeignKey("StateId")]
    public virtual State State { get; set; }

    [ForeignKey("HubId")]
    public virtual Hub Hub { get; set; }
}
