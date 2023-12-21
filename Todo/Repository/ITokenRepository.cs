using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data;
using Todo.Models;

namespace Todo.Repository
{
    public interface ITokenRepository
    {
        void Create(Token token);
    }
}
