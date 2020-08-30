using AutoMapper;

namespace InternetDiscussion
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Entities.Author, Models.AuthorDto>();

            CreateMap<Models.AuthorForCreationDto, Entities.Author>();
        }
    }
}
