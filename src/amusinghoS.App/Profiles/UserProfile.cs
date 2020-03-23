using AutoMapper;
using amusinghoS.EntityData.Model;
using amusinghoS.App.Dto;
using amusinghoS.Shared;

namespace amusinghoS.App.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserViewModel, amusingUser>()
                .ForMember(desc => desc.password, opt => opt.MapFrom(src => MD5Helper.GenerateMD5(src.password)))
                .ForMember(desc => desc.articleUserName, opt => opt.MapFrom(src => src.username));
        }
    }
}
