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
    public class TaskRepositoryAsync : GenericRepositoryAsync<WorkTask>, ITaskRepositoryAsync
    {
        private readonly DbSet<WorkTask> _workTasks;

        public TaskRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _workTasks = dbContext.Set<WorkTask>();
        }

        public Task<bool> IsUniqueTitleAsync(string title)
        {
            return _workTasks
                 .AllAsync(p => p.Title != title);
        }
    }
}
