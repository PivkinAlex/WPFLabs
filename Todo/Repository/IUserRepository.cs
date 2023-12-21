using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entities;
using Todo.Responses;

namespace Todo.Repository
{
    internal interface IUserRepository 
    {
        AuthResponse? Authorize(string password, string email);

        UserModel? Register(string Name, string post, string Password, string PasswordConfirm);
    }
}
