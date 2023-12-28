using AutoMapper;
using Chat.BL.User.Entities;
using Chat.Service.Controllers.Entities;

namespace Chat.Service.Mapper;

public class UsersServiceProfile : Profile
{
    public UsersServiceProfile()
    {
        CreateMap<UsersFilter, UsersModelFilter>();
        CreateMap<CreateUsersRequest, CreateUsersModel>(); 
    }
}