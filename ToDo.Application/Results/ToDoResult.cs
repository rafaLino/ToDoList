using System;

namespace ToDo.Application.Results
{
    public sealed class ToDoResult
    {
        public string Task { get; }

        public DateTime TaskDate { get; }

        public bool Done { get; }
    }
}
