using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApplication.Model;

[Table("order", Schema = "application")]
public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public float Value { get; set; }
    public string Situation { get; set; }
    public int LocationId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public DateTime? FinishDate { get; set; }
    public bool Active { get; set; } = false;

    [ForeignKey("LocationId")]
    public Location Location { get; set; }
}