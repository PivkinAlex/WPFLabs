using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Contract
{
    internal class ApiRoutes
    {
        private const string ApiRoute = "http://45.144.64.179";
        public static class Auth
        {
            public static string Login = ApiRoute + "/api/auth/login";
            public static string Registration = ApiRoute + "/api/auth/registration";
        }

        public static class File
        {
            public static string GetFile = ApiRoute + "/api/user/photo/{fileId}";
        }

        public static class Todo
        {
            public static string Todos = ApiRoute + "/api/todos";
            public static string DeleteTodo = ApiRoute + "/api/todos/";
            public static string MarkTodo = ApiRoute + "/api/todos/mark/";
        }

        public static class User
        {
            public static string UserInfo = ApiRoute + "/api/user";
            public static string UserPhoto = ApiRoute + "/api/user/photo";
        }
    }
}
