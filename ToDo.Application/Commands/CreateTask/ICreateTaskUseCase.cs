using System;
using System.Threading.Tasks;
using ToDo.Domain.Accounts;

namespace ToDo.Application.Commands.CreateTask
{
    public interface ICreateTaskUseCase
    {
        Task Execute(Guid accountId, ToDoItem task);
    }
}
