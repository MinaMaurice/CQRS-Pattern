using DataAccess.Commands.Repositories;
using DataAccess.Domain.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFSetup
{
  public static class EFSetupForCommands
    {
        public static IServiceCollection AddEF(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HalalaHContext>(opts =>
            {
                opts.UseSqlServer("Server=01-TEC-MINA;Database=HalalaH;Trusted_Connection=True;");
            });
            services.AddScoped<IDataStore, EFDataStore>();
            return services;
        }
    }
}
