using AutoPiesa;
using FluentAssertions;
using OpenQA.Selenium.DevTools.V109.Page;

namespace AutoPiesaRegistration.Specs.StepDefinitions
{
    [Binding]
    public sealed class RegistrationStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private Registration autoPiesaRegistration;
        string displayedErrors;
        public RegistrationStepDefinitions(ScenarioContext scenarioContext)
        {
            autoPiesaRegistration = new Registration();
            _scenarioContext = scenarioContext;
        }

        [Given("the name \"(.*)\"")]
        public void GivenTheName(string userFullName)
        {
            autoPiesaRegistration.EnterFullName(userFullName);
        }

        [Given("the email adress \"(.*)\"")]
        public void GivenTheEmailAdress(string userEmailAdress)
        {
            autoPiesaRegistration.EnterEmail(userEmailAdress);
        }

        [Given("the password \"(.*)\"")]
        public void GivenThePassword(string userPassword)
        {
            autoPiesaRegistration.EnterPassword(userPassword);
        }

        [Given("the confirmation password \"(.*)\"")]
        public void GivenTheConfirmationPassword(string userConfirmationPassword)
        {
            autoPiesaRegistration.EnterConfirmationPasswordd(userConfirmationPassword);
        }

        [Given("agree with personal data collector (.*)")]
        public void GivenAgreementForPersonalDataCollector(bool agree)
        {
            autoPiesaRegistration.AgreeWithPersonalDataCollector(agree);
        }

        [Given("agree with conditions and confindentiality policy (.*)")]
        public void GivenAgreementForConditionsAndConfindentialityPolicy(bool agree)
        {
            autoPiesaRegistration.AgreeWithConditionsAndConfindentialityPolicy(agree);
        }

        [When("click on Continuare")]
        public void CreateNewAccount()
        {
            autoPiesaRegistration.ContinueRegistration();
        }

        [Then("the displayed name error should be \"(.*)\"")]
        public void ThenTheResultShouldBe(string expected)
        {
            displayedErrors = autoPiesaRegistration.DisplayedNameErrors();
            displayedErrors.Should().Be(expected);
            autoPiesaRegistration.CloseDriver();
        }

        [Then("the displayed email error should be \"(.*)\"")]
        public void EmailErrors(string expected)
        {
            displayedErrors = autoPiesaRegistration.DisplayedEmailErrors();
            displayedErrors.Should().Be(expected);
            autoPiesaRegistration.CloseDriver();
        }

        [Then("the displayed password error should be \"(.*)\"")]
        public void PasswordErrors(string expected) 
        {
            displayedErrors = autoPiesaRegistration.DisplayedPasswordErrors();
            displayedErrors.Should().Be(expected);
            autoPiesaRegistration.CloseDriver();
        }

        [Then("the displayed confirmation password error should be \"(.*)\"")]
        public void CondfirmationPasswordErrors(string expected)
        {
            displayedErrors = autoPiesaRegistration.DisplayedConfirmationPasswordErrors();
            displayedErrors.Should().Be(expected);
            autoPiesaRegistration.CloseDriver();
        }
        [Then("the displayed disagreement error should be \"(.*)\"")]
        public void DisagreementErrors(string expected)
        {
            displayedErrors = autoPiesaRegistration.DisplayMandatoryAgreementsErrors();
            displayedErrors.Should().Be(expected);
            autoPiesaRegistration.CloseDriver(
        }
    }
}