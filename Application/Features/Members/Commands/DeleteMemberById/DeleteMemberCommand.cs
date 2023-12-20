using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Members.Commands.DeleteMemberById
{
   
    public class DeleteMemberByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteMemberByIdCommandHandler : IRequestHandler<DeleteMemberByIdCommand, Response<int>>
        {
            private readonly IMemberRepositoryAsync _memberRepository;
            public DeleteMemberByIdCommandHandler(IMemberRepositoryAsync memberRepository)
            {
                _memberRepository = memberRepository;
            }
            public async Task<Response<int>> Handle(DeleteMemberByIdCommand command, CancellationToken cancellationToken)
            {
                var member = await _memberRepository.GetByIdAsync(command.Id);
                if (member == null) throw new ApiException($"Member Not Found.");
                await _memberRepository.DeleteAsync(member);
                return new Response<int>(member.Id, "Member deleted successfully!");
            }
        }
    }
}
