namespace Infrastructure.Entities.CoursesEntities;

public class CourseEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CourseTitle { get; set; } = null!;
    public string CourseIngress { get; set; } = null!;
    public string CourseDescription { get; set; } = null!;
    public string? CourseImageUrl { get; set; }
    public bool IsBestseller { get; set; } = false;
    public string CourseCategory { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime LastUpdated { get; set; }
    public RatingEntity Rating { get; set; } = null!;
    public PriceEntity Price { get; set; } = null!;
    public IncludedEntity Included { get; set; } = null!;
    public AuthorEntity Author { get; set; } = null!;
    public List<HighlightsEntity> Highlights { get; set; } = [];
    public List<ProgramDetailsEntity> Content { get; set; } = [];
}