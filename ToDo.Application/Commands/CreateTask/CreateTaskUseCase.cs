using System;
using System.Threading.Tasks;
using ToDo.Application.Exceptions;
using ToDo.Application.Repositories;
using ToDo.Application.Results;
using ToDo.Domain.Accounts;

namespace ToDo.Application.Commands.CreateTask
{
    public class CreateTaskUseCase : ICreateTaskUseCase
    {
        private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;

        private readonly IAccountWriteOnlyRepository _accountWriteOnlyRepository;

        public CreateTaskUseCase(IAccountReadOnlyRepository accountReadOnlyRepository, IAccountWriteOnlyRepository accountWriteOnlyRepository)
        {
            _accountReadOnlyRepository = accountReadOnlyRepository;
            _accountWriteOnlyRepository = accountWriteOnlyRepository;
        }

        public async Task<ToDoResult> Execute(Guid accountId, string taskDescription, DateTime taskDate)
        {
            Account account = await _accountReadOnlyRepository.Get(accountId);
            ToDoItem task = new ToDoItem(taskDescription, taskDate);
            if (account == null)
                throw new AccountNotFoundException($"The account {accountId} does not exists");

            account.NewTask(task);

            await _accountWriteOnlyRepository.Update(account);

            return new ToDoResult(task.Task, task.TaskDate, task.Done);
        }
    }
}
