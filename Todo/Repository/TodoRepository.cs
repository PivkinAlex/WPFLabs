using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Todo.Contract;
using Todo.Entities;

namespace Todo.Repository
{
    internal class TodoRepository
    {
        private readonly string _accessToken;

        public TodoRepository(string accessToken) => _accessToken = accessToken;

        public List<TodoModel> GetAllTodos()
        {
            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json-patch+json");
            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + _accessToken);
            var response = client.DownloadString(ApiRoutes.Todo.Todos);
            return JsonConvert.DeserializeObject<List<TodoModel>>(response) ?? new List<TodoModel>();
        }

        public string CreateTodo(string category, string title, string description, DateTime date)
        {
            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json-patch+json");
            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + _accessToken);

            var todo = new TodoModel()
            {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                Description = description,
                Date = 0,
                Category = category,
                IsCompleted = false,
            };

            return client.UploadString(ApiRoutes.Todo.Todos, JsonConvert.SerializeObject(todo));
        }

        public bool DeleteTodo(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiRoutes.Todo.DeleteTodo);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + _accessToken);
                var response = client.DeleteAsync(id).Result;
                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
        }

        public bool MarkTodo(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiRoutes.Todo.MarkTodo);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + _accessToken);
                var requestContent = new StringContent(id);
                var response = client.PutAsync(id, requestContent).Result;
                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
        }
    }
}
