using Business.Dtos.SubsribersDtos;
using Infrastructure.Entities.SubscribersEntities;


namespace Business.Factories
{
    public class SubscribeFactory
    {
        public static SubscribeEntity FromDto(CreateSubscribeDto dto)
        {
            return new SubscribeEntity
            {
                Email = dto.Email,
                DailyNewsletter = dto.DailyNewsletter,
                AdvertisingUpdates = dto.AdvertisingUpdates,
                WeenInReview = dto.WeenInReview,
                EventUpdates = dto.EventUpdates,
                StartupsWeekly = dto.StartupsWeekly,
                Podcasts = dto.Podcasts,
            };
        }


        public static SubscribeEntity FromDto(string id, CreateSubscribeDto dto)
        {
            return new SubscribeEntity
            {
                Id = id,
                Email = dto.Email,
                DailyNewsletter = dto.DailyNewsletter,
                AdvertisingUpdates = dto.AdvertisingUpdates,
                WeenInReview = dto.WeenInReview,
                EventUpdates = dto.EventUpdates,
                StartupsWeekly = dto.StartupsWeekly,
                Podcasts = dto.Podcasts,
            };
        }

      
        public static GetSubscribeDto ToDto(SubscribeEntity entity)
        {
            return new GetSubscribeDto
            {
                Id = entity.Id,
                Email = entity.Email,
                DailyNewsletter = entity.DailyNewsletter,
                AdvertisingUpdates = entity.AdvertisingUpdates,
                WeenInReview = entity.WeenInReview,
                EventUpdates = entity.EventUpdates,
                StartupsWeekly = entity.StartupsWeekly,
                Podcasts = entity.Podcasts
            };
        }
    }
}