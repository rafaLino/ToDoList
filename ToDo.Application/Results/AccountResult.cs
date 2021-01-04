using System;
using System.Collections.Generic;

namespace ToDo.Application.Results
{
    public sealed class AccountResult
    {

        public Guid AccountId { get; }

        public IEnumerable<ToDoResult> ToDoList { get; }

        public AccountResult(Guid accountId, IEnumerable<ToDoResult> toDoList)
        {
            AccountId = accountId;
            ToDoList = toDoList;
        }
    }
}
