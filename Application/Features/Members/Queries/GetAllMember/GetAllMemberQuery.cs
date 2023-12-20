using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Members.Queries.GetAllMember
{

    public class GetAllMemberQuery : IRequest<PagedResponse<IEnumerable<GetAllMemberViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllMemberQueryHandler : IRequestHandler<GetAllMemberQuery, PagedResponse<IEnumerable<GetAllMemberViewModel>>>
    {
        private readonly IMemberRepositoryAsync _memberRepository;
        private readonly IMapper _mapper;
        public GetAllMemberQueryHandler(IMemberRepositoryAsync memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllMemberViewModel>>> Handle(GetAllMemberQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllMemberParameter>(request);
            var members = await _memberRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var membersViewModel = _mapper.Map<IEnumerable<GetAllMemberViewModel>>(members);
            return new PagedResponse<IEnumerable<GetAllMemberViewModel>>(membersViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
