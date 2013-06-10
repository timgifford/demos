using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Tests.StepDefinitions
{
    [Binding]
    public class ImportMultipleUsersStepDefinitions
    {
        private readonly IUserService userService = new UserService();
        private User importUser;
        private ValidationResult validationResult;

        [Given(@"a user row:")]
        public void GivenAUserRow(Table table)
        {
            importUser = new User();
            importUser.Username = table.Rows[0]["Username"];
            importUser.FirstName = table.Rows[0]["First Name"];
            importUser.LastName = table.Rows[0]["Last Name"];
        }

        [When(@"row is imported")]
        public void WhenRowIsImported()
        {
            validationResult = userService.ImportUser(importUser);
        }

        [Then(@"validation error should be ""(.*)""")]
        public void ThenValidationErrorShouldBeLastNameRequired(string validationMessage)
        {
            Assert.That(validationMessage, Is.EqualTo(validationResult.ToString()));
        }
    }


}
