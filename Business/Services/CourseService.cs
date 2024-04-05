using AutoMapper;
using Business.Dtos.CoursesDtos;
using Business.Factories;
using Business.Helper.Responses;
using Infrastructure.Repositories.CoursesRepositories;

namespace Business.Services
{
    public class CourseService
    {
        private readonly CourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(CourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }


        public async Task<ResponseResult> CreateAsync(CreateCourseDto dto)
        {
            try
            {
                if (await _courseRepository.ExistsAsync(x => x.CourseTitle == dto.CourseTitle))
                {
                    return ResponseFactory.Exists();
                }
                var result = await _courseRepository.CreateAsync(CourseFactory.CreateFromDto(dto));
                return result != null ? ResponseFactory.Ok() : ResponseFactory.Error();
            }
            catch (Exception)
            {
                //logger
                return ResponseFactory.Error();
            }
        }

        public async Task<ResponseResult> GetAllAsync(string? category, string? searchQuery)
        {
            try
            {
                var courses = await _courseRepository.QueryAsync(category, searchQuery);
                return courses.Any() ? ResponseFactory.Ok(courses, "Success") : ResponseFactory.NotFound();
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
                return course != null ? ResponseFactory.Ok(course) : ResponseFactory.NotFound();
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

                var existingEntity = await _courseRepository.GetOneAsync(x => x.Id == id);
                if (existingEntity == null)
                {
                    return ResponseFactory.NotFound();
                }
                _mapper.Map(dto, existingEntity);

                //var result = await _courseRepository.TestUpdate(existingEntity);


                var result = await _courseRepository.UpdateAsync(x => x.Id == id, existingEntity);
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