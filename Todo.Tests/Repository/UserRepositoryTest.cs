using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Repository;

namespace Todo.Tests.Repository
{
    public class UserRepositoryTest
    {
        [Test]
        public void Authorize_UserNotExist_ErrorUnuthorized()
        {
            var userRepository = new UserRepository();
            TestDelegate testDelegate = () => userRepository.Authorize("abobaaa", "aboba@mail.ru");
            Assert.Throws<System.Net.WebException>(testDelegate);
        }

        [Test]
        public void Authorize_UserExists_SuccessResponse()
        {
            var userRepository = new UserRepository();
            var response = userRepository.Authorize("sdfe25255", "yoooos@mail.ru");
            Assert.IsNotNull(response);
        }

        [Test]
        public void GetUserInfo_IncorrectToken_ErrorBadRequest()
        {
            var userRepository = new UserRepository();
            TestDelegate testDelegate = () => userRepository.GetUserInfo("sdfe25255");
            Assert.Throws<System.Net.WebException>(testDelegate);
        }
    }
}
