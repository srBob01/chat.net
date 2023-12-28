using AutoMapper;
using Chat.BL.Auth;
using Chat.BL.Users;
using Chat.DataAccess;
using Chat.DataAccess.Entities;
using Chat.Service.Settings;
using Microsoft.AspNetCore.Identity;

namespace Chat.Service.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureService(IServiceCollection services, BulletinBoardSettings settings)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUsersProvider>(x =>
            new UsersProvider(x.GetRequiredService<IRepository<UserEntity>>(), x.GetRequiredService<IMapper>(),
                settings.MinimumUserAge));
        services.AddScoped<IAuthProvider>(x =>
            new AuthProvider(x.GetRequiredService<SignInManager<UserEntity>>(),
                x.GetRequiredService<UserManager<UserEntity>>(),
                x.GetRequiredService<IHttpClientFactory>(),
                settings.IdentityServerUri,
                settings.ClientId,
                settings.ClientSecret));
        services.AddScoped<IUsersManager, UsersManager>();
    }
}