using Newtonsoft.Json.Linq;

namespace Business.Dtos.CoursesDtos;

public class CreateCourseDto
{
    public string CourseTitle { get; set; } = null!;
    public string CourseDescription { get; set; } = null!;
    public bool IsBestseller { get; set; } = false;
    public RatingDto Rating { get; set; } = null!;
    public PriceDto Price { get; set; } = null!;
    public IncludedDto Included { get; set; } = null!;
    public AuthorDto Author { get; set; } = null!;
    public List<ContentDto> Content { get; set; } = [];
}


public class RatingDto
{
    public string InNumbers { get; set; } = null!;
    public string InProcent { get; set; } = null!;
}


public class PriceDto
{
    public string OriginalPrice { get; set; } = null!;
    public string? DiscountPrice { get; set; }
}

public class IncludedDto
{
    public int HoursOfVideo { get; set; }
    public int Articles { get; set; }
    public int Resourses { get; set; }
    public bool LifetimeAccess { get; set; } = false;
    public bool Certificate { get; set; } = false;
}

public class AuthorDto 
{  
    public string FullName { get; set; } = null!;
    public string Biography { get; set; } = null!;
    public string? ProfileImageUrl { get; set; }
    public SocialMediaDto SocialMedia { get; set; } = null!;
}

public class SocialMediaDto
{
    public string YouTubeUrl { get; set; } = null!;
    public string Subscribers { get; set; } = null!;
    public string FacebookUrl { get; set; } = null!;
    public string Followers { get; set; } = null!;
}

public class ContentDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}