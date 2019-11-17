using DataAccess.Events.Repositories;
using DataAccess.Models.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFSetup
{
  public static class EFSetupForEvents
    {
        public static IServiceCollection AddEFForEvents(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HalalaHEventsContext>(opts =>
            {
                opts.UseSqlServer("Server=01-TEC-MINA;Database=HalalaHEvents;Trusted_Connection=True;");
            });
            services.AddScoped<IDataStore, EFDataStore>();
            return services;
        }
    }
}
