using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities.ContactFormsEntities;

public class ContactRequestEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    [Required]
    public string FullName { get; set; } = null!;
    
    [Required]
    public string Email { get; set; } = null!;

    public int? ServiceId { get; set; }
    public ServiceEntity? Service { get; set; }

    [Required]
    public string Message { get; set; } = null!;

    [Column(TypeName = "datetime2")]
    public DateTime Created { get; set; } = DateTime.Now;
}