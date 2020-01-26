using LisaRecipes.Application.Query;
using Microsoft.Extensions.DependencyInjection;
using System;
using MediatR;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using LisaRecipes.Contracts;
using LisaRecipes.PersistenceEF;

namespace LisaRecipes.Configuration
{
    public static class ConfigureApplication
    {
        public static IServiceCollection ConfigureApp(this IServiceCollection services, IConfiguration configuration)
        {

            return services
                .AddMediatr()
                .AddPersistenceEF(configuration);
        }
        public static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetRecipe).Assembly);
            return services;
        }
        public static IServiceCollection AddPersistenceEF(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContext<LisaRecipes.PersistenceEF.RecipeDBContext>(config =>
                    {
                        config.UseSqlServer(configuration.GetConnectionString("default"), b => b.MigrationsAssembly("LisaRecipes.PersistenceEF"));
                    })
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
