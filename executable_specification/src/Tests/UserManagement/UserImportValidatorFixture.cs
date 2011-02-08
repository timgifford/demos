using NUnit.Framework;

namespace Tests.UserManagement
{
    [TestFixture]
    public class UserImportValidatorFixture
    {
        [Test]
        public void ShouldRequireLastName()
        {
            var validator = new UserImportValidator();
            
            var userToValidate = new User();
            userToValidate.FirstName = "FirstName";
            userToValidate.Username = "username";

            var result = validator.Validate(userToValidate);

            Assert.That(result.ToString(),Is.EqualTo("Last Name Required"));
        }

        [Test]
        public void ShouldRequireFirstName()
        {
            var validator = new UserImportValidator();

            var userToValidate = new User();
            userToValidate.LastName = "LastName";
            userToValidate.Username = "username";

            var result = validator.Validate(userToValidate);

            Assert.That(result.ToString(), Is.EqualTo("First Name Required"));
        }
    }
}
