using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApplication.Model;

[Table("subscriber", Schema = "application")]
public class Subscriber
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public string Plan { get; set; }

    public int Year { get; set; }
    public float Value { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }

    public ICollection<Location> Locations { get; set; }
}