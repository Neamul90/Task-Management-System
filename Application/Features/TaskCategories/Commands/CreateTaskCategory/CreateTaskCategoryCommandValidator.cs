using Application.Features.Task.Commands.CreateTask;
using Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TaskCategories.Commands.CreateTaskCategory
{
    public class CreateTaskCategoryCommandValidator : AbstractValidator<CreateTaskCategoryCommand>
    {
        private readonly ITaskCategoryRepositoryAsync taskCategoryRepository;
        public CreateTaskCategoryCommandValidator(ITaskCategoryRepositoryAsync taskCategoryRepository)
        {
            this.taskCategoryRepository = taskCategoryRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueName).WithMessage("{PropertyName} already exist.");

        }

        private async Task<bool> IsUniqueName(string name, CancellationToken cancellationToken)
        {
            return await taskCategoryRepository.IsUniqueNameAsync(name);
        }
    }
}
