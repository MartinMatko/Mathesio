using AutoMapper;

namespace InternetDiscussion
{
    public class TopicsProfile : Profile
    {
        public TopicsProfile()
        {
            CreateMap<Models.TopicForCreationDto, Entities.Topic>();
            CreateMap<Entities.Topic, Models.TopicDto>();
            CreateMap<Entities.Topic, Models.TopicLookupDto>();
        }
    }
}
