using Newtonsoft.Json;

namespace Infrastructure.Entities.CoursesEntities;

public class CourseEntity
{
    [JsonProperty("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [JsonProperty("courseTitle")]
    public string CourseTitle { get; set; } = null!;

    [JsonProperty("courseDescription")]
    public string CourseDescription { get; set; } = null!;

    [JsonProperty("isBestseller")]
    public bool IsBestseller { get; set; } = false;

    [JsonProperty("rating")]
    public RatingEntity Rating { get; set; } = null!;

    [JsonProperty("price")]
    public PriceEntity Price { get; set; } = null!;

    [JsonProperty("included")]
    public IncludedEntity Included { get; set; } = null!;

    [JsonProperty("author")]
    public AuthorEntity Author { get; set; } = null!;

    [JsonProperty("content")]
    public List<ContentEntity> Content { get; set; } = [];
}


public class RatingEntity
{
    [JsonProperty("inNumbers")]
    public string InNumbers { get; set; } = null!;

    [JsonProperty("inProcent")]
    public string InProcent { get; set; } = null!;
}


public class PriceEntity
{
    [JsonProperty("orginialPrice")]
    public string OriginalPrice { get; set; } = null!;

    [JsonProperty("discountPrice")]
    public string? DiscountPrice { get; set; }
}

public class IncludedEntity
{
    [JsonProperty("hoursOfVideo")]
    public int HoursOfVideo { get; set; }

    [JsonProperty("articles")]
    public int Articles { get; set; }

    [JsonProperty("resourses")]
    public int Resourses { get; set; }

    [JsonProperty("lifetimeAccess")]
    public bool LifetimeAccess {  get; set; } = false;

    [JsonProperty("certificate")]
    public bool Certificate { get; set; } = false;
}

public class AuthorEntity
{
    [JsonProperty("fullName")]
    public string FullName { get; set; } = null!;

    [JsonProperty("biography")]
    public string Biography { get; set; } = null!;

    [JsonProperty("profileImageUrl")]
    public string? ProfileImageUrl { get; set; }

    [JsonProperty("socialMedia")]
    public SocialMediaEntity SocialMedia { get; set; } = null!;
}

public class SocialMediaEntity
{
    [JsonProperty("youtubeUrl")]
    public string YouTubeUrl { get; set; } = null!;

    [JsonProperty("subscribers")]
    public string Subscribers { get; set; } = null!;

    [JsonProperty("facebookUrl")]
    public string FacebookUrl { get; set; } = null!;

    [JsonProperty("followers")]
    public string Followers { get; set; } = null!;
}

public class ContentEntity
{
    [JsonProperty("title")]
    public string Title { get; set; } = null!;

    [JsonProperty("description")]
    public string Description { get; set; } = null!;
}