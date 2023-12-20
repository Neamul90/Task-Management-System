using Application.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(
                  configuration.GetConnectionString("DefaultConnection"),
                  b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<ITaskRepositoryAsync, TaskRepositoryAsync>();
            services.AddTransient<ITaskCategoryRepositoryAsync, TaskCategoryRepositoryAsync>();
            services.AddTransient<IMemberRepositoryAsync, MemberRepositoryAsync>();
            #endregion
            services.AddScoped<IMemberService, MemberService>();

        }
    }
}
