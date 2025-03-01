﻿using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NZwalks.API.Data;
using NZwalks.API.Mapping;
using NZwalks.API.Repositories;
using NZwalks.API.Repositories.WalkRepositroy;

namespace NZwalks.API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddDbContext<NZWalkerDbContext>(options =>
              options.UseSqlServer(config.GetConnectionString("NZWalksConnectionString")));

            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddScoped<IWalkRepository, WalkRepository>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt => opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer= config["Jwt:Issuer"],
                    ValidAudience= config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
                });

            services.AddDbContext<NZWalksAuthDbContext>(options => options.UseSqlServer(config.GetConnectionString("NZWalksAuthConnectionString")));

            return services;
        }
    }
}
