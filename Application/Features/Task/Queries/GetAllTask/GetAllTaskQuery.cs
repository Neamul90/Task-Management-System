using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Task.Queries.GetAllTask
{

    public class GetAllTaskQuery : IRequest<PagedResponse<IEnumerable<GetAllMemberViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllTaskQueryHandler : IRequestHandler<GetAllTaskQuery, PagedResponse<IEnumerable<GetAllMemberViewModel>>>
    {
        private readonly ITaskRepositoryAsync _taskRepository;
        private readonly IMapper _mapper;
        public GetAllTaskQueryHandler(ITaskRepositoryAsync taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllMemberViewModel>>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllMemberParameter>(request);
            var task = await _taskRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var taskViewModel = _mapper.Map<IEnumerable<GetAllMemberViewModel>>(task);
            return new PagedResponse<IEnumerable<GetAllMemberViewModel>>(taskViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
