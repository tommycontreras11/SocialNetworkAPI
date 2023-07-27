using AutoMapper;

namespace SocialNetworkAPI.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region User
            CreateMap<User, GetUserDto>()
                .ReverseMap()
                .ForMember(dest => dest.CreatedAt, src => src.Ignore())
                .ForMember(dest => dest.ModifiedAt, src => src.Ignore());
            CreateMap<AddUserDto, User>();
            #endregion

            #region Post
            CreateMap<Post, GetPostDto>()
                .ReverseMap()
                .ForMember(dest => dest.CreatedAt, src => src.Ignore())
                .ForMember(dest => dest.ModifiedAt, src => src.Ignore());
            CreateMap<AddPostDto, Post>();
            #endregion

            #region Comment
            CreateMap<Comment, GetCommentDto>()
                .ReverseMap()
                .ForMember(dest => dest.CreatedAt, src => src.Ignore())
                .ForMember(dest => dest.ModifiedAt, src => src.Ignore());
            CreateMap<AddCommentDto, Comment>();
            #endregion
        }
    }
}
