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

namespace Application.Features.Task.Queries.GetTaskById
{
   
    public class GetTaskByIdQuery : IRequest<Response<GetTaskViewModel>>
    {
        public Guid Id { get; set; }
        public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Response<GetTaskViewModel>>
        {
            private readonly ITaskRepositoryAsync _taskRepository;
            private readonly IMapper _mapper;

            public GetTaskByIdQueryHandler(ITaskRepositoryAsync taskRepository, IMapper mapper)
            {
                _taskRepository = taskRepository;
                _mapper = mapper;
            }
            public async Task<Response<GetTaskViewModel>> Handle(GetTaskByIdQuery query, CancellationToken cancellationToken)
            {
                var task = await _taskRepository.GetByIdAsync(query.Id);
                if (task == null) throw new ApiException($"Task Not Found.");
                var taskViewModel = _mapper.Map<GetTaskViewModel>(task);
                return new Response<GetTaskViewModel>(taskViewModel);
            }
        }
    }
}
