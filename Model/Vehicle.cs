using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApplication.Model;

[Table("vehicle", Schema = "application")]
public class Vehicle
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int Year { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }

    [Required] public string Type { get; set; }

    private DateTime createdDate;
    public DateTime CreatedDate
    {
        get => createdDate;
        set => createdDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }    private DateTime? updateDate;
    public DateTime? UpdateDate
    {
        get => updateDate;
        set => updateDate = value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : value;
    }
}