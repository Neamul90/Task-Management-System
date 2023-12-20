using Application.Features.Members.Queries.MemberAuth;
using Application.Helper;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IMemberService
    {
        Member GetById(int id);
    }

    public class MemberService : IMemberService
    {
        private readonly ApplicationDbContext _context;

        public MemberService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Member GetById(int id)
        {
            return  _context.Members.Find(id);
        }
    }
}
