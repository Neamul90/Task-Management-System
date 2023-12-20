using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TaskCategories.Commands.DeleteTaskCategoryById
{
    public class DeleteTaskCategoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteTaskCategoryCommandHandler : IRequestHandler<DeleteTaskCategoryCommand, Response<int>>
        {
            private readonly ITaskCategoryRepositoryAsync _taskCategoryRepository;
            public DeleteTaskCategoryCommandHandler(ITaskCategoryRepositoryAsync taskCategoryRepository)
            {
                _taskCategoryRepository = taskCategoryRepository;
            }
            public async Task<Response<int>> Handle(DeleteTaskCategoryCommand command, CancellationToken cancellationToken)
            {
                var task_category = await _taskCategoryRepository.GetByIdAsync(command.Id);
                if (task_category == null) throw new ApiException($"Task category Not Found.");
                await _taskCategoryRepository.DeleteAsync(task_category);
                return new Response<int>(task_category.Id, "Task category deleted successfully!");
            }
        }
    }
}
