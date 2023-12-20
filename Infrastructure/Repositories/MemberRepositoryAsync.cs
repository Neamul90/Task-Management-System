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
    public class MemberRepositoryAsync : GenericRepositoryAsync<Member>, IMemberRepositoryAsync
    {
        private readonly DbSet<Member> _members;

        public MemberRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _members = dbContext.Set<Member>();
        }

        public Task<bool> IsUniqueEmailAsync(string email)
        {
            return _members
                .AllAsync(p => p.Email != email);
        }

      
    }
}
