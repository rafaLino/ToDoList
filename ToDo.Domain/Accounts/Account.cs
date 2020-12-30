using System;
using System.Collections.Generic;

namespace ToDo.Domain.Accounts
{
    public class Account : IEntity
    {
        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }

        private ToDoCollection _toDos;


        public IReadOnlyCollection<ToDoItem> GetToDoItems()
        {
            return _toDos.GetItems();
        }

        public void NewTask(ToDoItem toDoItem)
        {
            _toDos.Add(toDoItem);
        }

        private Account() { }

        public Account(Guid userId)
        {
            Id = Guid.NewGuid();
            _toDos = new ToDoCollection();
            UserId = userId;
        }

        public static Account Load(Guid id, Guid userId, ToDoCollection toDoItems)
        {
            Account account = new Account
            {
                Id = id,
                UserId = userId,
                _toDos = toDoItems
            };

            return account;
        }
    }
}
