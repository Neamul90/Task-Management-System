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

namespace Application.Features.Task.Commands.UpdateTask
{
   
    public class UpdateTaskCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public int? TaskCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }

        public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Response<Guid>>
        {
            private readonly ITaskRepositoryAsync _taskRepository;
            public UpdateTaskCommandHandler(ITaskRepositoryAsync taskRepository)
            {
                _taskRepository = taskRepository;
            }
            public async Task<Response<Guid>> Handle(UpdateTaskCommand command, CancellationToken cancellationToken)
            {
                var task = await _taskRepository.GetByIdAsync(command.Id);
                if (task == null)
                {
                    throw new ApiException($"Task Not Found.");
                }
                else
                {
                    task.Title = command.Title;
                    task.Description = command.Description;
                    task.DueDate = command.DueDate;
                    task.Status = command.Status;
                    task.TaskCategoryId = command.TaskCategoryId;
                    await _taskRepository.UpdateAsync(task);
                    return new Response<Guid>(task.Id, "Task update successfully!");

                }
            }
        }
    }
}
