using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Helpers;


namespace Todo.Tests.Helpers
{
    public class ValidatorTest
    {
        [Test]
        public void ValidatePassword_ShortString_ErrorsNotEmpty()
        {
            Validator.Errors.Clear();
            Validator.ValidatePassword("as3");
            Assert.That(Validator.Errors.Any());
        }

        [Test]
        public void ValidateEmail_WithoutDot_ErrorsNotEmpty()
        {
            Validator.Errors.Clear();
            Validator.ValidateEmail("hgjashd@ndskru");
            Assert.That(Validator.Errors.Any());
        }
    }
}
