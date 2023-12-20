using Application.Exceptions;
using Application.Features.Task.Queries.GetAllTask;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Members.Queries.GetMemberById
{
   
    public class GetMemberByIdQuery : IRequest<Response<Member>>
    {
        public int Id { get; set; }
        public class GetMemberByIdQueryHandler : IRequestHandler<GetMemberByIdQuery, Response<Member>>
        {
            private readonly IMemberRepositoryAsync _memberRepository;
            private readonly IMapper _mapper;

            public GetMemberByIdQueryHandler(IMemberRepositoryAsync memberRepository, IMapper mapper)
            {
                _memberRepository = memberRepository;
                _mapper = mapper;
            }
            public async Task<Response<Member>> Handle(GetMemberByIdQuery query, CancellationToken cancellationToken)
            {
                var member = await _memberRepository.GetByIdAsync(query.Id);
                if (member == null) throw new ApiException($"Member Not Found.");
                return new Response<Member>(member);
            }
        }
    }
}
