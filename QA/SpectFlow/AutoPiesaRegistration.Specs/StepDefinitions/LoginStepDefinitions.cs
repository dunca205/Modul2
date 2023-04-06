using AutoPiesa;
using FluentAssertions;

namespace AutoPiesaRegistration.Specs.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private Login loginPage;
        private bool succes;
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
            loginPage.SubmitLogin();
        }

        [Then("the URL should change (.*)")]
        public void SuccesfulyLoggedIn(bool pass)
        {
            succes = loginPage.SuccesfulyLoggedIn();
            succes.Should().Be(pass);
            loginPage.CloseChrome();
        }
    }
}
