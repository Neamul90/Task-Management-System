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

namespace Application.Features.TaskCategories.Commands.CreateTaskCategory
{
    public partial class CreateTaskCategoryCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
    public class CreateTaskCategoryCommandHandler : IRequestHandler<CreateTaskCategoryCommand, Response<int>>
    {
        private readonly ITaskCategoryRepositoryAsync _taskCategoryRepository;
        private readonly IMapper _mapper;
        public CreateTaskCategoryCommandHandler(ITaskCategoryRepositoryAsync taskCategoryRepository, IMapper mapper)
        {
            _taskCategoryRepository = taskCategoryRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateTaskCategoryCommand request, CancellationToken cancellationToken)
        {
            var task_category = _mapper.Map<TaskCategory>(request);
            await _taskCategoryRepository.AddAsync(task_category);
            return new Response<int>(task_category.Id, "Add new task category successfully!");
        }
    }
}
