using Business.Dtos.CoursesDtos;
using Business.Factories;
using Business.Helper.Responses;
using Infrastructure.Repositories.CoursesRepositories;

namespace Business.Services
{
    public class CourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }


        public async Task<ResponseResult> CreateAsync(CreateCourseDto dto)
        {
            try
            {
                if (await _courseRepository.ExistsAsync(x => x.CourseTitle == dto.CourseTitle))
                {
                    return ResponseFactory.Exists();
                }
                var result = await _courseRepository.CreateAsync(CourseFactory.FromDto(dto));
                return result != null ? ResponseFactory.Ok() : ResponseFactory.Error();
            }
            catch (Exception)
            {
                //logger
                return ResponseFactory.Error();
            }
        }

        public async Task<ResponseResult> GetAllAsync()
        {
            try
            {
                var courses = await _courseRepository.GetAllAsync();
                return courses.Any() ? ResponseFactory.Ok(courses.Select(course => CourseFactory.ToDto(course)).ToList()) : ResponseFactory.NotFound();
            }
            catch (Exception)
            {
                //logger
                return ResponseFactory.Error();
            }
        }

        public async Task<ResponseResult> GetOneAsync(string id)
        {
            try
            {
                var course = await _courseRepository.GetOneAsync(x => x.Id == id);
                return course != null ? ResponseFactory.Ok(CourseFactory.ToDto(course)) : ResponseFactory.NotFound();
            }
            catch (Exception)
            {
                //logger
                return ResponseFactory.Error();
            }
        }

        public async Task<ResponseResult> UpdateAsync(string id, CreateCourseDto dto)
        {
            try
            {
                var result = await _courseRepository.UpdateAsync(x => x.Id == id, CourseFactory.FromDto(id, dto));
                return result != null ? ResponseFactory.Ok(CourseFactory.ToDto(result)) : ResponseFactory.NotFound();
                
            }
            catch (Exception)
            {
                //logger
                return ResponseFactory.Error();
            }
        }



        public async Task<ResponseResult> DeleteAsync(string id)
        {
            try
            {
                if (!await _courseRepository.ExistsAsync(x => x.Id == id))
                {
                    return ResponseFactory.NotFound();
                }

                var result = await _courseRepository.DeleteAsync(x => x.Id == id);
                return result ? ResponseFactory.Ok() : ResponseFactory.Error();
            }
            catch (Exception)
            {
                //logger
                return ResponseFactory.Error();
            }
        }

    }
}