using System.Collections.Generic;
using Todo.Models;

namespace Todo
{
    public class UserModel
    {
        public UserModel()
        {
            Todos = new List<TodoModel>();
        }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public List<TodoModel>? Todos { get; set; }

    }
}