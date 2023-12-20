using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Task.Commands.DeleteTaskById
{
   
    public class DeleteTaskByIdCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public class DeleteTaskByIdCommandHandler : IRequestHandler<DeleteTaskByIdCommand, Response<Guid>>
        {
            private readonly ITaskRepositoryAsync _taskRepository;
            public DeleteTaskByIdCommandHandler(ITaskRepositoryAsync taskRepository)
            {
                _taskRepository = taskRepository;
            }
            public async Task<Response<Guid>> Handle(DeleteTaskByIdCommand command, CancellationToken cancellationToken)
            {
                var task = await _taskRepository.GetByIdAsync(command.Id);
                if (task == null) throw new ApiException($"Task Not Found.");
                await _taskRepository.DeleteAsync(task);
                return new Response<Guid>(task.Id, "Task deleted successfully!");
            }
        }
    }
}
