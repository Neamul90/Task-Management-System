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

namespace Application.Features.TaskCategories.Queries.GetAllTaskCategory
{
    public class GetAllTaskCategoryQuery : IRequest<Response<IEnumerable<TaskCategory>>>
    {
    }
    public class GetAllTaskCategoryQueryHandler : IRequestHandler<GetAllTaskCategoryQuery, Response<IEnumerable<TaskCategory>>>
    {
        private readonly ITaskCategoryRepositoryAsync _taskCategoryRepository;
        private readonly IMapper _mapper;
        public GetAllTaskCategoryQueryHandler(ITaskCategoryRepositoryAsync taskCategoryRepository, IMapper mapper)
        {
            _taskCategoryRepository = taskCategoryRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<TaskCategory>>> Handle(GetAllTaskCategoryQuery request, CancellationToken cancellationToken)
        {
            var task_category =await _taskCategoryRepository.GetAllAsync();
            return new Response<IEnumerable<TaskCategory>>(task_category, "successfully get data!");
        }
    }
}
