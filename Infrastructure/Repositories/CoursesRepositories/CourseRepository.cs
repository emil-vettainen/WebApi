using Infrastructure.Contexts;
using Infrastructure.Entities.CoursesEntities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.CoursesRepositories
{
    public class CourseRepository : BaseRepository<CourseEntity, CosmosDbContext>
    {
        private readonly CosmosDbContext _context;
        public CourseRepository(CosmosDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<bool> ExistsAsync(Expression<Func<CourseEntity, bool>> predicate)
        {
            try
            {
                var entityExists = await _context.Courses.Where(predicate).Select(x => x.Id).FirstOrDefaultAsync() != null;
                return entityExists;

            }
            catch (Exception)
            {

                //logger
                return false;
            }
        }

        //public async Task<CourseEntity> CategoryAsync(string category)
        //{
        //    try
        //    {
        //        var courses = _context.Courses.Where(course => course.)

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}