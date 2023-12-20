using Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Members.Commands.CreateMember
{
  
    public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
    {
        private readonly IMemberRepositoryAsync memberRepository;
        public CreateMemberCommandValidator(IMemberRepositoryAsync memberRepository)
        {
            this.memberRepository = memberRepository;

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueEmail).WithMessage("{PropertyName} already exist.");
            RuleFor(p => p.Password)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
               .Equal(customer => customer.ConfirmPassword)
                .When(customer => !String.IsNullOrWhiteSpace(customer.Password)).WithMessage("{PropertyName} and ConfirmPassword does not match.");
        }

        private async Task<bool> IsUniqueEmail(string email, CancellationToken cancellationToken)
        {
            return await memberRepository.IsUniqueEmailAsync(email);
        }
    }
}
