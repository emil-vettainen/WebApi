namespace Business.Dtos.ContactRequests;

public class GetContactRequestDto
{
    public string Id { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Service { get; set; }
    public string Message { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}