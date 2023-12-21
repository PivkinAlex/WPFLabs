using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entities;

namespace Todo.Responses
{
    public class AuthResponse
    {
        public string? access_token { get; set; }

        [JsonIgnore]
        public UserModel User { get; set; }
    }
}
