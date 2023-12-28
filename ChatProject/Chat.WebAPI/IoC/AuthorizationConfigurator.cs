﻿using Duende.IdentityServer.Models;
using Chat.DataAccess;
using Chat.DataAccess.Entities;
using Chat.Service.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Chat.WebAPI.Settings;

namespace Chat.Service.IoC;

public static class AuthorizationConfigurator
{
    public static void ConfigureServices(this IServiceCollection services, ChatSettings settings)
    {
        IdentityModelEventSource.ShowPII = true;
        services.AddIdentity<UserEntity, UserRoleEntity>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
            })
            .AddEntityFrameworkStores<BulletinBoardDbContext>()
            .AddSignInManager<SignInManager<UserEntity>>()
            .AddDefaultTokenProviders();

        services.AddIdentityServer()
            .AddInMemoryApiScopes(new[] { new ApiScope("api") })
            .AddInMemoryUsers(new[]
            {
                new User()
                {
                    UserName = settings.UserId,
                    UserId = settings.UserId,
                    Enabled = true,
                    AllowOfflineAccess = true,
                    AllowedGrantTypes = new List<string>()
                    {
                        GrantType.UserCredentials,
                        GrantType.ResourceOwnerPassword
                    },
                    AllowedScopes = new List<string>() { "api" }
                }
            })
            .AddAspNetIdentity<UserEntity>();

        services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }
        ).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.RequireHttpsMetadata = false;
            options.Authority = settings.IdentityServerUri;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = false,
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            options.Audience = "api";
        });

        services.AddAuthorization();
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        app.UseIdentityServer();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}