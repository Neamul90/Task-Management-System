using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Task.Commands.CreateTask
{
    public partial class CreateTaskCommand : IRequest<Response<Guid>>
    {
        public int? TaskCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
    
    }
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Response<Guid>>
    {
        private readonly ITaskRepositoryAsync _taskRepository;
        private readonly IMapper _mapper;
        public CreateTaskCommandHandler(ITaskRepositoryAsync taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<WorkTask>(request);
            await _taskRepository.AddAsync(task);
            return new Response<Guid>(task.Id, "Add new task successfully!");
        }
    }
}
