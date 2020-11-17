using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Persistence.DbSetting;
using Bookeasy.Persistence.Interfaces;
using CsvHelper.Configuration;
using Microsoft.Extensions.Options;

namespace Bookeasy.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            
            services.AddDbContext<NorthwindDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("NorthwindDatabase")));

            services.AddScoped<INorthwindDbContext>(provider => provider.GetService<NorthwindDbContext>());

            return services;
        }
    }
}
