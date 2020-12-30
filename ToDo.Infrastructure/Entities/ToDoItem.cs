using System;

namespace ToDo.Infrastructure.Entities
{
    public class ToDoItem
    {
        public Guid Id { get; set; }

        public string Task { get; set; }

        public DateTime TaskDate { get; set; }

        public bool Done { get; set; }

        public Guid AccountId { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
