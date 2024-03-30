using Business.Dtos.CoursesDtos;
using Infrastructure.Entities.CoursesEntities;

namespace Business.Factories;

public class CourseFactory
{
    public static CourseEntity FromDto(CreateCourseDto dto)
    {
        return new CourseEntity
        {
            CourseTitle = dto.CourseTitle,
            CourseIngress = dto.CourseIngress,
            CourseDescription = dto.CourseDescription,
            CourseImageUrl = dto.CourseImageUrl,
            IsBestseller = dto.IsBestseller,
            Category = dto.Category,

            Rating = new RatingEntity
            {
                InNumbers = dto.Rating.InNumbers,
                InProcent = dto.Rating.InProcent,
            },
            Price = new PriceEntity
            {
                OriginalPrice = dto.Price.OriginalPrice,
                DiscountPrice = dto.Price.DiscountPrice,
            },
            Included = new IncludedEntity
            {
                HoursOfVideo = dto.Included.HoursOfVideo,
                Articles = dto.Included.Articles,
                Resourses = dto.Included.Resourses,
                LifetimeAccess = dto.Included.LifetimeAccess,
                Certificate = dto.Included.Certificate
            },
            Author = new AuthorEntity
            {
                FullName = dto.Author.FullName,
                Biography = dto.Author.Biography,
                ProfileImageUrl = dto.Author.ProfileImageUrl,

                SocialMedia = new SocialMediaEntity
                {
                    YouTubeUrl = dto.Author.SocialMedia.YouTubeUrl,
                    Subscribers = dto.Author.SocialMedia.Subscribers,
                    FacebookUrl = dto.Author.SocialMedia.FacebookUrl,
                    Followers = dto.Author.SocialMedia.Followers,
                }
            },
            Content = dto.Content.Select(x => new ProgramDetailsEntity
            {
                Title = x.Title,
                Description = x.Description,
            }).ToList()
            
        };
    }

    public static CourseEntity FromDto(string id, CreateCourseDto dto)
    {
        return new CourseEntity
        {
            Id = id,
            CourseTitle = dto.CourseTitle,
            CourseIngress = dto.CourseIngress,
            CourseDescription = dto.CourseDescription,
            CourseImageUrl = dto.CourseImageUrl,
            IsBestseller = dto.IsBestseller,
            Category = dto.Category,

            Rating = new RatingEntity
            {
                InNumbers = dto.Rating.InNumbers,
                InProcent = dto.Rating.InProcent,
            },
            Price = new PriceEntity
            {
                OriginalPrice = dto.Price.OriginalPrice,
                DiscountPrice = dto.Price.DiscountPrice,
            },
            Included = new IncludedEntity
            {
                HoursOfVideo = dto.Included.HoursOfVideo,
                Articles = dto.Included.Articles,
                Resourses = dto.Included.Resourses,
                LifetimeAccess = dto.Included.LifetimeAccess,
                Certificate = dto.Included.Certificate
            },
            Author = new AuthorEntity
            {
                FullName = dto.Author.FullName,
                Biography = dto.Author.Biography,
                ProfileImageUrl = dto.Author.ProfileImageUrl,

                SocialMedia = new SocialMediaEntity
                {
                    YouTubeUrl = dto.Author.SocialMedia.YouTubeUrl,
                    Subscribers = dto.Author.SocialMedia.Subscribers,
                    FacebookUrl = dto.Author.SocialMedia.FacebookUrl,
                    Followers = dto.Author.SocialMedia.Followers,
                }
            },
            Content = dto.Content.Select(x => new ProgramDetailsEntity
            {
                Title = x.Title,
                Description = x.Description,
            }).ToList()

        };
    }

    public static GetCourseDto ToDto(CourseEntity entity)
    {
        try
        {
            return new GetCourseDto
            {
                Id = entity.Id,
                CourseTitle = entity.CourseTitle,
                CourseIngress = entity.CourseIngress,
                CourseDescription = entity.CourseDescription,
                CourseImageUrl = entity.CourseImageUrl,
                IsBestseller = entity.IsBestseller,
                Category = entity.Category,
                Rating = new RatingDto
                {
                    InNumbers = entity.Rating.InNumbers,
                    InProcent = entity.Rating.InProcent,
                },
                Price = new PriceDto
                {
                    OriginalPrice = entity.Price.OriginalPrice,
                    DiscountPrice = entity.Price.DiscountPrice,
                },
                Included = new IncludedDto
                {
                    HoursOfVideo = entity.Included.HoursOfVideo,
                    Articles = entity.Included.Articles,
                    Resourses = entity.Included.Resourses,
                    LifetimeAccess = entity.Included.LifetimeAccess,
                    Certificate = entity.Included.Certificate
                },
                Author = new AuthorDto
                {
                    FullName = entity.Author.FullName,
                    Biography = entity.Author.Biography,
                    ProfileImageUrl = entity.Author.ProfileImageUrl,

                    SocialMedia = new SocialMediaDto
                    {
                        YouTubeUrl = entity.Author.SocialMedia!.YouTubeUrl!,
                        Subscribers = entity.Author.SocialMedia!.Subscribers!,
                        FacebookUrl = entity.Author.SocialMedia!.FacebookUrl!,
                        Followers = entity.Author.SocialMedia!.Followers!,
                    }
                },
                Content = entity.Content.Select(x => new ProgramDetailsDto
                {
                    Title = x.Title,
                    Description = x.Description,
                }).ToList()
            };
        }
        catch (Exception)
        {

            throw;
        }
    }
}