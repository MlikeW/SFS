namespace SFSTest
{
    public static class Locators
    {
        public const string webSite = "http://sfs.gov.ua/";
        public const string SearchBox = "//*[@name='query']";
        internal const string SearchButton = "//*[@type='submit']";
        internal const string SearchIndicator = "//*[contains(text(),'Пошук по сайту') and @class='title']";
        internal const string RadioName = "//*[contains(text(),'{0}')]/input";
        internal const string SearchInput = "//*[@class='search__info']/p/strong";
        internal const string SearchSumResults = "//*[@class='search__info']/p[2]";
        internal const string SearchTableResults = "//*[@class='table table_search']/tbody//td[3]";
        internal const string SearchResultMessage = "всього знайдено {0} результатів";

        

    }
}
