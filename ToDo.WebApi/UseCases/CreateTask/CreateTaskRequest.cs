using System;

namespace ToDo.WebApi.UseCases.CreateTask
{
    public class CreateTaskRequest
    {
        public Guid AccountId { get; set; }

        public string Task { get; set; }

        public DateTime Date { get; set; }
    }
}
