﻿using Infrastructure.Contexts;
using Infrastructure.Entities.CoursesEntities;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq;
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

       



        public async Task<IEnumerable<CourseEntity>> QueryAsync(string? category, string? searchQuery)
        {
            try
            {
                var query = _context.Courses.AsQueryable();

                if (!string.IsNullOrEmpty(category) && category != "all")
                    query = query.Where(x => x.CourseCategory.ToLower() == category.ToLower());

                if (!string.IsNullOrEmpty(searchQuery))
                    query = query.Where(x => x.CourseTitle.ToLower().Contains(searchQuery.ToLower()) || x.Author.FullName.ToLower().Contains(searchQuery.ToLower()));

                var courses = await query.ToListAsync();
                return courses;
            }
            catch (Exception)
            { 
                //logger
                return [];
            }
        }
    }
}