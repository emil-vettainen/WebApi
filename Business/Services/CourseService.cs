using AutoMapper;
using Business.Dtos.Courses;
using Business.Dtos.CoursesDtos;
using Business.Factories;
using Business.Helper.Responses;
using Infrastructure.Repositories.CoursesRepositories;
using System.Diagnostics;


namespace Business.Services
{
    public class CourseService(CourseRepository courseRepository, IMapper mapper)
    {
        private readonly CourseRepository _courseRepository = courseRepository;
        private readonly IMapper _mapper = mapper;

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
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return ResponseFactory.ServerError();
            }
        }

        public async Task<ResponseResult> GetAllAsync(string? category, string? searchQuery, int pageNumber, int pageSize)
        {
            try
            {
                var result = await _courseRepository.QueryAsync(category, searchQuery, pageNumber, pageSize);
                if (result.Courses.Any())
                {
                    var response = new CourseResultDto
                    {
                        Succeeded = true,
                        TotalItems = result.TotalItems,
                        Courses = _mapper.Map<IEnumerable<GetCourseDto>>(result.Courses),
                    };
                    response.TotalPages = (int)Math.Ceiling(response.TotalItems / (double)pageSize);
                    return ResponseFactory.Ok(response);
                }
                return ResponseFactory.NotFound();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return ResponseFactory.ServerError();
            }
        }

     
        public async Task<ResponseResult> GetOneAsync(string id)
        {
            try
            {
                var course = await _courseRepository.GetOneAsync(x => x.Id == id);
                return course != null ? ResponseFactory.Ok(_mapper.Map<GetCourseDto>(course)) : ResponseFactory.NotFound();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return ResponseFactory.ServerError();
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
                var result = await _courseRepository.UpdateAsync(x => x.Id == id, existingEntity);
                return result != null ? ResponseFactory.Ok(CourseFactory.ToDto(result)) : ResponseFactory.NotFound();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return ResponseFactory.ServerError();
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return ResponseFactory.ServerError();
            }
        }


        public async Task<ResponseResult> GetCategoriesAsync()
        {
            try
            {
                var result = await _courseRepository.GetCategoriesAsync();
                return result != null ? ResponseFactory.Ok(result) : ResponseFactory.NotFound();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return ResponseFactory.ServerError();
            }
        }


        public async Task<ResponseResult> GetCoursesByIdsAsync(List<string> courseIds)
        {
            try
            {
                var result = await _courseRepository.GetCoursesByIdsAsync(courseIds);
                return result.Any() ? ResponseFactory.Ok(result) : ResponseFactory.NotFound();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return ResponseFactory.ServerError();
            }
        }
    }
}