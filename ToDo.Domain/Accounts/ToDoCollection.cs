using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ToDo.Domain.Accounts
{
    public class ToDoCollection
    {
        private readonly IList<ToDoItem> _toDoItems;

        public ToDoCollection()
        {
            _toDoItems = new List<ToDoItem>();
        }

        public IReadOnlyCollection<ToDoItem> GetItems()
        {
            return new ReadOnlyCollection<ToDoItem>(_toDoItems);
        }

        public void Add(ToDoItem toDo)
        {
            _toDoItems.Add(toDo);
        }

        public void Add(IEnumerable<ToDoItem> toDos)
        {
            foreach (var toDo in toDos)
            {
                Add(toDo);
            }
        }

        public void Remove(ToDoItem toDo)
        {
            _toDoItems.Remove(toDo);
        }
    }
}
