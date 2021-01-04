using System;
using System.Threading.Tasks;
using ToDo.Application.Results;

namespace ToDo.Application.Commands.CreateTask
{
    public interface ICreateTaskUseCase
    {
        Task<ToDoResult> Execute(Guid accountId, string taskDescription, DateTime taskDate);
    }
}
