using Application.Features.Task.Commands.CreateTask;
using Application.Features.Task.Commands.DeleteTaskById;
using Application.Features.Task.Commands.UpdateTask;
using Application.Features.Task.Queries.GetAllTask;
using Application.Features.Task.Queries.GetTaskById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.Controllers
{
    [Authorize]
    public class TaskController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllMemberParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllTaskQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetTaskByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateTaskCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateTaskCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteTaskByIdCommand { Id = id }));
        }
    }
}
