using System;
using System.Collections.Generic;
using System.Text;
using HRMS.Dal.Contracts.Entities;
using HRMS.Dal.Repositories;
using HRMS.Dal.RepositoryImplementations;
using Microsoft.Extensions.DependencyInjection;

namespace HRMS.Dal.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        public static IServiceCollection RegisterUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
