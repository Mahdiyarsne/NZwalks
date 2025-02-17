using Microsoft.EntityFrameworkCore;
using NZwalks.API.Data;
using NZwalks.API.Mapping;
using NZwalks.API.Repositories;

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

            return services;
        }
    }
}
