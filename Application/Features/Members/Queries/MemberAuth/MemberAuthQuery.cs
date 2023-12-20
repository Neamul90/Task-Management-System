using Application.Exceptions;
using Application.Features.Task.Queries.GetAllTask;
using Application.Helper;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Members.Queries.MemberAuth
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Member user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Token = token;
        }
    }
    public class MemberAuthQuery : IRequest<Response<AuthenticateResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public class MemberAuthQueryHandler : IRequestHandler<MemberAuthQuery, Response<AuthenticateResponse>>
        {
            private readonly IMemberRepositoryAsync _memberRepository;
            private readonly IMapper _mapper;
            private readonly AppSettings _appSettings;

            public MemberAuthQueryHandler(IOptions<AppSettings> appSettings,IMemberRepositoryAsync memberRepository, IMapper mapper)
            {
                _memberRepository = memberRepository;
                _mapper = mapper;
                _appSettings = appSettings.Value;

            }
            public async Task<Response<AuthenticateResponse>> Handle(MemberAuthQuery query, CancellationToken cancellationToken)
            {
                var member = (await _memberRepository.GetAllAsync(a=>a.Email==query.Email)).FirstOrDefault();
                if (member == null) throw new ApiException($"Email is not valid.");
                member.Password=EncDec.Decrypt(member.Password);
                if (member.Password == query.Password)
                {
                    var token = generateJwtToken(member);
                    return new Response<AuthenticateResponse>(new AuthenticateResponse(member, token));
                }
                else
                    throw new ApiException($"Password is incorrect.");
            }
            private string generateJwtToken(Member user)
            {
                // generate token that is valid for 7 days
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
        }
    }
}
