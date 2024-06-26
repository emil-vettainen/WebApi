﻿namespace Business.Dtos.CoursesDtos;

public class GetCourseDto
{
    public string Id { get; set; } = null!;
    public string CourseTitle { get; set; } = null!;
    public string CourseIngress { get; set; } = null!;
    public string CourseDescription { get; set; } = null!;
    public string? CourseImageUrl { get; set; }
    public bool IsBestseller { get; set; } = false;
    public string CourseCategory {  get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime LastUpdated { get; set; }
    public RatingDto Rating { get; set; } = null!;
    public PriceDto Price { get; set; } = null!;
    public IncludedDto Included { get; set; } = null!;
    public AuthorDto Author { get; set; } = null!;
    public List<HighlightsDto> Highlights { get; set; } = [];
    public List<ProgramDetailsDto> Content { get; set; } = [];
}