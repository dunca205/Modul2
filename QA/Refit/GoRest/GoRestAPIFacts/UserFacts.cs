global using Xunit;
using Refit;

namespace GoRestAPIFacts
{
    public class UserFacts
    {
        private  string baseUrl = "https://gorest.co.in/public/v2";
        private RefitSettings refitSettings = new RefitSettings()
        {
            AuthorizationHeaderValueGetter = async () => await Task.FromResult("d4def2b2e62b4489f8b40995bd9201a8479a1be90fbcbf605b8a46e8a27dbb6c")
        };

        [Fact]
        public void Test1()
        {

        }
    }
}