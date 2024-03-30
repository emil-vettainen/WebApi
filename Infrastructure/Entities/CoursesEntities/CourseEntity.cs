namespace Infrastructure.Entities.CoursesEntities;

public class CourseEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CourseTitle { get; set; } = null!;
    public string CourseIngress { get; set; } = null!;
    public string CourseDescription { get; set; } = null!;
    public string? CourseImageUrl { get; set; }
    public bool IsBestseller { get; set; } = false;
    public string? Category { get; set; }
    public RatingEntity Rating { get; set; } = null!;
    public PriceEntity Price { get; set; } = null!;
    public IncludedEntity Included { get; set; } = null!;
    public AuthorEntity Author { get; set; } = null!;
    public List<ProgramDetailsEntity> Content { get; set; } = [];
}

public class CategoryEntity
{
    public string CategoryName { get; set; } = null!;
}


public class RatingEntity
{
    public decimal InNumbers { get; set; }
    public decimal InProcent { get; set; }
}


public class PriceEntity
{
    public decimal OriginalPrice { get; set; }
    public decimal? DiscountPrice { get; set; }
}

public class IncludedEntity
{
    public int HoursOfVideo { get; set; }
    public int Articles { get; set; }
    public int Resourses { get; set; }
    public bool LifetimeAccess {  get; set; } = false;
    public bool Certificate { get; set; } = false;
}

public class AuthorEntity
{
    public string FullName { get; set; } = null!;
    public string Biography { get; set; } = null!;
    public string? ProfileImageUrl { get; set; }
    public SocialMediaEntity? SocialMedia { get; set; }
}

public class SocialMediaEntity
{
    public string? YouTubeUrl { get; set; }
    public string? Subscribers { get; set; }
    public string? FacebookUrl { get; set; }
    public string? Followers { get; set; }
}

public class ProgramDetailsEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}