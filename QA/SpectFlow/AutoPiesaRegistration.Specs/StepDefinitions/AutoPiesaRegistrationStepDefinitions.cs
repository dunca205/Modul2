using AutoPiesa;

namespace AutoPiesaRegistration.Specs.StepDefinitions
{
    [Binding]
    public sealed class AutoPiesaRegistrationStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private ScenarioContext _scenarioContext;
        private Registration autoPiesaRegistration;
        public AutoPiesaRegistrationStepDefinitions(ScenarioContext scenarioContext)
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

        [Then("the displayed error should be  \"(.*)\"")]
        public void ThenTheResultShouldBe(string expected)
        {
            //TODO: implement assert (verification) logic
            //https://www.auto-piesa.ro/cos//
            throw new PendingStepException();
        }
    }
}