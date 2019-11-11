using BackendServices_todo.Interfaces;
using BackendServices_todo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendServices_todo.Services
{
    public class ToDoRepository : IToDoRepository
    {
        private List<ToDoItem> _toDoList;

        public ToDoRepository()
        {
            InitializeData();
        }

       

        public IEnumerable<ToDoItem> All
        {
            get { return _toDoList; }
        }

        public void Delete(string id)
        {
            _toDoList.Remove(Find(id));
        }

        public bool DoesItemExist(string id)
        {
            return _toDoList.Any(x => x.ID == id);
        }

        public ToDoItem Find(string id)
        {
            return _toDoList.FirstOrDefault(a => a.ID == id);
        }

        public void Insert(ToDoItem item)
        {
            _toDoList.Add(item);
        }

        public void Update(ToDoItem item)
        {
            var todoItem = this.Find(item.ID);
            var index = _toDoList.IndexOf(todoItem);
            _toDoList.RemoveAt(index);
            _toDoList.Insert(index, item);
        }
        private void InitializeData()
        {
            _toDoList = new List<ToDoItem>();

            var todoItem1 = new ToDoItem
            {
                ID = "6bb8a868-dba1-4f1a-93b7-24ebce87e243",
                Name = "Learn app development",
                Notes = "Attend Xamarin University",
                Done = true
            };

            var todoItem2 = new ToDoItem
            {
                ID = "b94afb54-a1cb-4313-8af3-b7511551b33b",
                Name = "Develop apps",
                Notes = "Use Xamarin Studio/Visual Studio",
                Done = false
            };

            var todoItem3 = new ToDoItem
            {
                ID = "ecfa6f80-3671-4911-aabe-63cc442c1ecf",
                Name = "Publish apps",
                Notes = "All app stores",
                Done = false,
            };

            _toDoList.Add(todoItem1);
            _toDoList.Add(todoItem2);
            _toDoList.Add(todoItem3);
        }
    }
}
