using System;
using System.Collections.Generic;

namespace ToDo.Application.Results
{
    public sealed class AccountResult
    {

        public Guid AccountId { get; }

        public List<ToDoResult> ToDoList { get; }

        public AccountResult(Guid accountId, List<ToDoResult> toDoList)
        {
            AccountId = accountId;
            ToDoList = toDoList;
        }
    }
}
