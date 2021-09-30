using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Extensions
{
    public static class ServiceCollectionExtension 
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<LibraryContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
        public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
        {
            
            return services;
        }
    }
}
