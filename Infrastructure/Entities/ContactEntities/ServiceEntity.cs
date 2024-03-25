namespace Infrastructure.Entities.ContactFormsEntities;

public class ServiceEntity
{
    public int Id { get; set; }
    public string ServiceName { get; set; } = null!;
    public ICollection<ContactRequestEntity> ContactRequests { get; set; } = [];
}