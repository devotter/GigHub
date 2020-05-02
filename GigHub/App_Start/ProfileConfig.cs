using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;

namespace GigHub.App_Start
{
    public class ProfileConfig : Profile
    {
        public ProfileConfig()
        {
            CreateMap<Notification, NotificationDto>();
            CreateMap<Gig, GigDto>();
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Genre, GenreDto>();
        }
    }

    public static class MappingProfile
    {
        public static IMapper Mapper { get; private set; }
        
        public static void InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new ProfileConfig());
            });
            
            Mapper = config.CreateMapper();
        }
        
    }
}