using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Entities
{
    public class TodoModel
    {
        public string? Id { get; set; }

        public string? Category { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public long Date { get; set; }

        public bool IsCompleted { get; set; }
    }
}
