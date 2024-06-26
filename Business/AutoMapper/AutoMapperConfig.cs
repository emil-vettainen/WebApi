﻿using AutoMapper;
using Business.Dtos.CoursesDtos;
using Infrastructure.Entities.CoursesEntities;

namespace Business.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        { 
            CreateMap<CreateCourseDto, CourseEntity>()
                .ForMember(x => x.Id, x => x.Ignore())
                .ForMember(x => x.Created, x => x.Ignore())
                .ForMember(x => x.LastUpdated, x => x.MapFrom(x => DateTime.Now));


            CreateMap<RatingDto, RatingEntity>();
            CreateMap<PriceDto, PriceEntity>();
            CreateMap<IncludedDto, IncludedEntity>();
            CreateMap<AuthorDto, AuthorEntity>();
            CreateMap<SocialMediaDto, SocialMediaEntity>();
            CreateMap<HighlightsDto, HighlightsEntity>();
            CreateMap<ProgramDetailsDto, ProgramDetailsEntity>();

            CreateMap<CourseEntity, GetCourseDto>();

            CreateMap<RatingEntity, RatingDto>();
            CreateMap<PriceEntity, PriceDto>();
            CreateMap<IncludedEntity, IncludedDto>();
            CreateMap<AuthorEntity, AuthorDto>();
            CreateMap<SocialMediaEntity, SocialMediaDto>();
            CreateMap<HighlightsEntity, HighlightsDto>();
            CreateMap<ProgramDetailsEntity, ProgramDetailsDto>();
        }
    }
}