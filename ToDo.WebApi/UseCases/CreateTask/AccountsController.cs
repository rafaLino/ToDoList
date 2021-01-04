using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDo.Application.Commands.CreateTask;
using ToDo.Application.Repositories;

namespace ToDo.WebApi.UseCases.CreateTask
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly ICreateTaskUseCase _createTaskService;

        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;

        public AccountsController(ICreateTaskUseCase createTaskService, IAccountWriteOnlyRepository accountWriteOnlyRepository)
        {
            _createTaskService = createTaskService;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
        }

        [HttpPost("Task", Name = "Task")]
        public async Task<IActionResult> Post([FromBody] CreateTaskRequest request)
        {
            var result = await _createTaskService.Execute(request.AccountId, request.Task, request.Date);

            return Created(Request.Path, result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAccount()
        {
            var userId = Guid.NewGuid();
            var account = new Domain.Accounts.Account(userId);
            await this.accountWriteOnlyRepository.Add(account);
            return Created(Request.Path, account.Id);
        }
    }
}
