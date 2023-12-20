using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TaskCategoryRepositoryAsync : GenericRepositoryAsync<TaskCategory>, ITaskCategoryRepositoryAsync
    {
        private readonly DbSet<TaskCategory> _taskCategories;

        public TaskCategoryRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _taskCategories = dbContext.Set<TaskCategory>();
        }

        public Task<bool> IsUniqueNameAsync(string name)
        {
            return _taskCategories
                 .AllAsync(p => p.Name != name);
        }
    }
}
