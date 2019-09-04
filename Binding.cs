using static SFSTest.Locators;

namespace SFSTest
{
    using TechTalk.SpecFlow;

    [Binding]
    class Binding : Steps
    {
        [Given(@"user navigates to test website")]
        [When(@"user navigates to test website")]
        public void GivenNavigateToWebsite()
            => Methods.GoToStartPage();

        [When(@"user searches '(.*)' information")]
        public void WhenUserSearchesInformation(string search)
            => Methods.SearchFromPage(search);

        [Then(@"user checks default position of radiobutton is '(.*)'")]
        public void WhenUserChecksDefaultPositionOfRadiobuttonIs(string radio)
            => Methods.RadioIsChecked(radio);

        [Then(@"user checks presence of '(.*)' in search title")]
        public void ThenUserChecksPresenceOfInSearchTitle(string input)
            => Methods.CheckSearchTitle(input);

        [Then(@"user checks correctness of sum of results in search title")]
        public void ThenUserChecksCorrectnessOfSumOfResultsInSearchTitle()
            => Methods.ChecksSumOfResults();

        [Then(@"user checks his location on main page")]
        public void ThenUserChecksHisLocationOnMainPage()
            => Methods.CheckLocation(webSite);

        [Then(@"user checks successful search process")]
        public void ThenUserChecksSuccessfulSearchProcess()
            => Methods.SearchProcess();










        [AfterScenario]
        public void AfterScenario()
            => Methods.TearDown();
    }
}
//WebBrowser.Driver.CaptureScreenShot(ScenarioContext.Current.ScenarioInfo.Title);
