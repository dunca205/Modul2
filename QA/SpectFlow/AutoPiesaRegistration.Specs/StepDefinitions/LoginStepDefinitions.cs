using AutoPiesa;
using FluentAssertions;

namespace AutoPiesaRegistration.Specs.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private Login loginPage;
        private string actualUrl;
        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            loginPage = new Login();
            _scenarioContext = scenarioContext;
        }

        [Given("the email \"(.*)\"")]
        public void GivenTheEmailAdress(string userEmailAdress)
        {
            loginPage.EnterEmail(userEmailAdress);
        }

        [Given("password \"(.*)\"")]
        public void GivenThePassword(string userPassword)
        {
            loginPage.EnterPassword(userPassword);
        }

        [When("click on Autentificare")]
        public void LogIntoAccount()
        {
            actualUrl = loginPage.SubmitLogin();
        }

        [Then("the URL should be \"(.*)\"")]
        public void SuccesfulyLoggedIn(string expectedUrl)
        {
            actualUrl.Should().Be(expectedUrl);
            loginPage.CloseChrome();
        }
    }
}