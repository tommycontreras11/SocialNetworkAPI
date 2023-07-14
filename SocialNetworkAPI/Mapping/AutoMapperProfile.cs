using AutoMapper;

namespace SocialNetworkAPI.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region User
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();
            #endregion

            #region Post
            CreateMap<Post, GetPostDto>();
            CreateMap<AddPostDto, Post>();
            #endregion
        }
    }
}
