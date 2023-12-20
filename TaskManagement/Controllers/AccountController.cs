using Application.Features.Members.Commands.CreateMember;
using Application.Features.Members.Queries.MemberAuth;
using Application.Features.TaskCategories.Commands.CreateTaskCategory;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.Controllers
{
    public class AccountController : BaseApiController
    {
        // POST api/<controller>
        [HttpPost("register")]
        public async Task<IActionResult> Post(CreateMemberCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Login(MemberAuthQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
