using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Repository
{
    public interface IRepositoryManager
    {
        ITokenRepository Token { get; }
        void Save();
    }
}
