using AutoMapper;
using amusinghoS.EntityData.Model;
using amusinghoS.Redis;

namespace amusinghoS.App.Profiles
{
    public class ArticleProfile :Profile
    {
        public ArticleProfile()
        {
            CreateMap<Comment, amusingArticleComment>()
                .ForMember(desc => desc.eamil, opt => opt.MapFrom(src => src.email))
                .ForMember(desc => desc.commentatorName, opt => opt.MapFrom(src => src.name))
                .ForMember(desc => desc.content, opt => opt.MapFrom(src => src.content));
        }
    }
}
