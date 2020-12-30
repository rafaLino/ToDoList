using System;

namespace ToDo.Domain.Accounts
{
    public sealed class ToDoItem : IEntity
    {
        public Guid Id { get; private set; }
        public string Task { get; private set; }
        public DateTime TaskDate { get; private set; }
        public bool Done { get; private set; }

        private ToDoItem()
        {

        }

        public ToDoItem(string taskDescription, DateTime taskDate, bool done = false)
        {
            Id = Guid.NewGuid();
            Done = done;
            Task = taskDescription;
            TaskDate = taskDate;
        }

        public void ToggleDone()
        {
            Done = !Done;
        }

        public static ToDoItem Load(Guid id, string task, DateTime taskDate, bool done)
        {
            ToDoItem todoItem = new ToDoItem
            {
                Id = id,
                Task = task,
                TaskDate = taskDate,
                Done = done,
            };

            return todoItem;
        }

    }
}
