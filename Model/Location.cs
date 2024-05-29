using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApplication.Model;


[Table("location", Schema = "application")]
public class Location
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int UserId { get; set; }
    public int SubscriberId { get; set; }
    public int VehicleId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public DateTime? FinishDate { get; set; }
    public DateTime? ForecastDate { get; set; }
    public bool Active { get; set; } = false;

    [ForeignKey("UserId")]
    public User User { get; set; }

    [ForeignKey("SubscriberId")]
    public Subscriber Subscriber { get; set; }
    [ForeignKey("VehicleId")]
    public Vehicle Vehicle { get; set; }
    public ICollection<Order> Orders { get; set; }
}
