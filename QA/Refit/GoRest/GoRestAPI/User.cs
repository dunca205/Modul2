using GoRestAPI;
using Refit;
using System.Text.Json.Serialization;

namespace GoRest
{
    public class User
    {
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Gender { get; set; }

        public string? Status { get; set; }

        static async Task Main(string[] args)
        {
           
            var token = "d4def2b2e62b4489f8b40995bd9201a8479a1be90fbcbf605b8a46e8a27dbb6c";
            var baseUrl = "https://gorest.co.in/public/v2";
            var refitSettings = new RefitSettings()
            {
                AuthorizationHeaderValueGetter = async () => await Task.FromResult(token)
            };

          
            var goRest = RestService.For<IUsersApi>(baseUrl, refitSettings);

            ///////////////////////////////////////////////////////posts
            // var postToAdd = new Post
            // {
            //     Id = 100,
            //     user_id = 1050082, // foarte ciudat cum daca folosesc CamelCase nu se poate face request ul (Error 422 => Data validation failed (in response to a POST request, for example). Please check the response body for detailed error messages.)
            //     Title = "new post from VS",
            //     Body = "empty body"
            // };

            // var updadedVersion = new Post
            // {
            //     Id = 100,
            //     user_id = 1050082,
            //     Title = "updaded post from VS",
            //     Body = "updaded body"

            // };


            // var goRest = RestService.For<IPostsApi>(baseUrl, refitSettings);

            // add new Post for a certain user id

            //await goRest.AddNewPost(postToAdd);

            // get all posts including the one we added
            // var allPosts = await goRest.GetAllPosts();

            // await goRest.UpdatePost(updadedVersion, allPosts.First().Id);

            // get certain s user s posts
            // var userPosts = await goRest.GetUserPosts(1050082);


            // foreach (Post post in allPosts)
            // {
            //     Console.WriteLine(post.Title);
            //     await goRest.DeleteCertainPost(post.Id);
            // }

            //var goRest = RestService.For<ICommentsApi>(baseUrl, refitSettings);

            //var anaMariaPost_Id = 13150;
            //await goRest.AddNewComment(new Comment 
            //{ Id = 10,
            //  post_id = anaMariaPost_Id,
            //  Name = "AnaMaria",
            //  Email = "anamaria@mail.test", 
            //  Body = "this is the body of a comment VS" });

            //var allComents = await goRest.GetAllComments();

            //var anaMariasComments = await goRest.GetCommentsFor("AnaMaria");

            //foreach ( var comment in anaMariasComments)
            //{
            //    await goRest.DeleteComment(comment.Id);
            //}
        }
    }

}