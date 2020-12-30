using System;

namespace ToDo.Infrastructure.Entities
{
    public class Account
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
