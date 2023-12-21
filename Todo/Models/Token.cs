using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Models
{
    
    public class Token
    {
        [Column ("Id")]
        public Guid Id { get; set; }
        public string TokenValue { get; set; }
    }
}
