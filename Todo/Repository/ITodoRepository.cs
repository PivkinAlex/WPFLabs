using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entities;

namespace Todo.Repository
{
    internal interface ITodoRepository
    {
        string CreateTodo(string category, string title, string description, DateTime date);
        bool DeleteTodo(string id);
        bool MarkTodo(string id);
        List<TodoModel>? GetAllTodos();

    }
}
