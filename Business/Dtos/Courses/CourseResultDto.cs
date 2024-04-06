using Business.Dtos.CoursesDtos;


namespace Business.Dtos.Courses
{
    public class CourseResultDto
    {
        public bool Succeeded { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<GetCourseDto>? Courses { get; set; }
    }
}
