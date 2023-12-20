using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Application.Helper;

namespace Application.Features.Members.Commands.CreateMember
{
    public partial class CreateMemberCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Response<int>>
    {
        private readonly IMemberRepositoryAsync _memberRepository;
        private readonly IMapper _mapper;
        public CreateMemberCommandHandler(IMemberRepositoryAsync memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = _mapper.Map<Member>(request);
            member.Password=EncDec.Encrypt(member.Password);
            await _memberRepository.AddAsync(member);
            return new Response<int>(member.Id, "Add new member successfully!");
        }
    }
}
