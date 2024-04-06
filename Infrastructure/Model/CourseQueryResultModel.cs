using Infrastructure.Entities.CoursesEntities;

namespace Infrastructure.Model;

public class CourseQueryResultModel
{
    public IEnumerable<CourseEntity> Courses { get; set; } = [];
    public int TotalItems { get; set; }
}