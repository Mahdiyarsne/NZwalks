using Microsoft.EntityFrameworkCore;
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

            return services;
        }
    }
}
