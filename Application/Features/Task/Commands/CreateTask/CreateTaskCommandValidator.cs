using Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Task.Commands.CreateTask
{
  
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        private readonly ITaskRepositoryAsync taskRepository;
        public CreateTaskCommandValidator(ITaskRepositoryAsync taskRepository)
        {
            this.taskRepository = taskRepository;

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueTitle).WithMessage("{PropertyName} already exist.");

        }

        private async Task<bool> IsUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await taskRepository.IsUniqueTitleAsync(title);
        }
    }
}
