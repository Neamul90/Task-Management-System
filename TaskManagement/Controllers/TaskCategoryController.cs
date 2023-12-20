using Application.Features.Task.Commands.DeleteTaskById;
using Application.Features.TaskCategories.Commands.CreateTaskCategory;
using Application.Features.TaskCategories.Commands.DeleteTaskCategoryById;
using Application.Features.TaskCategories.Commands.UpdateTaskCategory;
using Application.Features.TaskCategories.Queries.GetAllTaskCategory;
using Application.Features.TaskCategories.Queries.GetTasCategorykById;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.Controllers
{
    [Authorize]
    public class TaskCategoryController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllTaskCategoryQuery()));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetTaskCategoryByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateTaskCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateTaskCategoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteTaskCategoryCommand { Id = id }));
        }
    }
}
