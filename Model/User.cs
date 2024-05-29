using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApplication.Model;


[Table("user", Schema = "application")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "bigint")]
    public long Cnh { get; set; }

    [Required]
    [Column(TypeName = "bigint")]
    public long Doc { get; set; }

    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public string ImageCnh { get; set; }
    public bool Admin { get; set; } = false;
    private DateTime createdDate;
    public DateTime CreatedDate
    {
        get => createdDate;
        set => createdDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    private DateTime? updateDate;
    public DateTime? UpdateDate
    {
        get => updateDate;
        set => updateDate = value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : value;
    }

    public string TypeCnh { get; set; }
    
}