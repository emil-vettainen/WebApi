namespace Infrastructure.Entities.CoursesEntities;

public class AuthorEntity
{
    public string FullName { get; set; } = null!;
    public string Biography { get; set; } = null!;
    public string? ProfileImageUrl { get; set; }
    public SocialMediaEntity? SocialMedia { get; set; }
}
