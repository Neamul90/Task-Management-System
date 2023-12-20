using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TaskCategories.Commands.UpdateTaskCategory
{
    public class UpdateTaskCategoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateTaskCategoryCommandHandler : IRequestHandler<UpdateTaskCategoryCommand, Response<int>>
        {
            private readonly ITaskCategoryRepositoryAsync _taskCategoryRepository;
            public UpdateTaskCategoryCommandHandler(ITaskCategoryRepositoryAsync taskCategoryRepository)
            {
                _taskCategoryRepository = taskCategoryRepository;
            }
            public async Task<Response<int>> Handle(UpdateTaskCategoryCommand command, CancellationToken cancellationToken)
            {
                var task_category = await _taskCategoryRepository.GetByIdAsync(command.Id);
                if (task_category == null)
                {
                    throw new ApiException($"Task category Not Found.");
                }
                else
                {
                    task_category.Name = command.Name;
                    await _taskCategoryRepository.UpdateAsync(task_category);
                    return new Response<int>(task_category.Id, "Task category update successfully!");

                }
            }
        }
    }
}
