using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Todo.Entities;
using Todo.Responses;
using static Todo.Contract.ApiRoutes;


namespace Todo.Repository
{
    internal class UserRepository
    {
        public AuthResponse? Authorize(string password, string email)
        {
            ValidateLogin(password, email);
            if (Validator.Errors.Any())
            {
                MessageBox.Show(string.Join(Environment.NewLine, Validator.Errors), "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
            else
            {
                var user = new UserModel()
                {
                    Password = password,
                    Email = email
                };
                var client = new WebClient();
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json-patch+json");
                var result = client.UploadString(Auth.Login, JsonConvert.SerializeObject(user));
                var response = JsonConvert.DeserializeObject<AuthResponse>(result);
                if (response != null && response.access_token != null)
                    response.User = GetUserInfo(response.access_token);
                return response;
            }
        }

        public AuthResponse? Register(string name, string email, string password, string passwordConfirm)
        {
            ValidateRegistration(name, email, password, passwordConfirm);
            if (Validator.Errors.Any())
            {
                MessageBox.Show(string.Join(Environment.NewLine, Validator.Errors), "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
            else
            {
                var user = new UserModel()
                {
                    Email = email,
                    Password = password,
                    Name = name,
                };

                var client = new WebClient();
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json-patch+json");
                var result = client.UploadString(Auth.Registration, JsonConvert.SerializeObject(user));
                var response = JsonConvert.DeserializeObject<AuthResponse>(result);
                if (response != null && response.access_token != null)
                    response.User = GetUserInfo(response.access_token);
                return response;
            }
        }

        public UserModel GetUserInfo(string accessToken)
        {
            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json-patch+json");
            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + accessToken);
            var response = client.DownloadString(User.UserInfo);
            return JsonConvert.DeserializeObject<UserModel>(response) ?? new UserModel();
        }

        private void ValidateLogin(string password, string email)
        {
            Validator.Errors.Clear();
            Validator.ValidateEmail(email);
            Validator.ValidatePassword(password);
        }

        private void ValidateRegistration(string userName, string email, string password, string passConfirm)
        {
            Validator.Errors.Clear();
            Validator.ValidateName(userName);
            Validator.ValidateEmail(email);
            Validator.ValidatePassword(password);
            Validator.PasswordsEquality(password, passConfirm);
        }

    }
}
