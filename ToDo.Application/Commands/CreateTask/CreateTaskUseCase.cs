using System;
using System.Threading.Tasks;
using ToDo.Application.Exceptions;
using ToDo.Application.Repositories;
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

        public async Task Execute(Guid accountId, ToDoItem task)
        {
            Account account = await _accountReadOnlyRepository.Get(accountId);

            if (account == null)
                throw new AccountNotFoundException($"The account {accountId} does not exists");

            account.NewTask(task);

            await _accountWriteOnlyRepository.Update(account);
        }
    }
}
