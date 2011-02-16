using NUnit.Framework;

namespace Tests.UserManagement
{
    [TestFixture]
    public class UserImportValidatorFixture
    {
        [Test]
        public void ShouldRequireLastName()
        {
            // Arrange
            var testUser = new User();
            testUser.FirstName = "FirstName";
            testUser.Username = "username";

            // Act
            var validator = new UserImportValidator();
            var result = validator.Validate(testUser);

            // Assert
            Assert.That(result.ToString(),Is.EqualTo("Last Name Required"));
        }

        [Test]
        public void ShouldRequireFirstName()
        {
            var userToValidate = new User();
            userToValidate.LastName = "LastName";
            userToValidate.Username = "username";

            var result = new UserImportValidator().Validate(userToValidate);

            Assert.That(result.ToString(), Is.EqualTo("First Name Required"));
        }
    }
}
