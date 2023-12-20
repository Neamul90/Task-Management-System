using Application.Exceptions;
using Application.Features.Task.Queries.GetTaskById;
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

namespace Application.Features.TaskCategories.Queries.GetTasCategorykById
{
  
    public class GetTaskCategoryByIdQuery : IRequest<Response<TaskCategory>>
    {
        public int Id { get; set; }
        public class GetTaskCategoryByIdQueryHandler : IRequestHandler<GetTaskCategoryByIdQuery, Response<TaskCategory>>
        {
            private readonly ITaskCategoryRepositoryAsync _taskCategoryRepository;
            private readonly IMapper _mapper;

            public GetTaskCategoryByIdQueryHandler(ITaskCategoryRepositoryAsync taskCategoryRepository, IMapper mapper)
            {
                _taskCategoryRepository = taskCategoryRepository;
                _mapper = mapper;
            }
            public async Task<Response<TaskCategory>> Handle(GetTaskCategoryByIdQuery query, CancellationToken cancellationToken)
            {
                var task_category = await _taskCategoryRepository.GetByIdAsync(query.Id);
                if (task_category == null) throw new ApiException($"Task Category Not Found.");
                return new Response<TaskCategory>(task_category);
            }
        }
    }
}
