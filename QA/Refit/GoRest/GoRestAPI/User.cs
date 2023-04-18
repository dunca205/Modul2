using System;
using GoRestAPI;
using Refit;

namespace GoRest
{
    public class User
    {
        public int Id { get; set; }

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

            //var newUser = new User
            //{
            //    Id = 1,
            //    Name = "Ana Maria",
            //    Gender = "female",
            //    Email = "testfemale@test.comm",
            //    Status = "active"
            //};

            //var newData = new User
            //{
            //    Id = 2,
            //    Name = "Updated Ana Maria",
            //    Gender = "female",
            //    Email = "updadedEmail@test.com",
            //    Status = "active"
            //};


            //var goRest = RestService.For<IUser>(baseUrl, refitSettings);

            //await goRest.CreateUser(newUser);

            //// get all users including the one we create
            //var allUsers = await goRest.GetAllUsers();

            //// get the Id for the user we added
            //var newUserId = allUsers.First().Id;

            //Console.WriteLine("Id of new user {0} is : {1} ", allUsers.First().Name, newUserId);

            //// get user by id
            //var userById = await goRest.GetUserById(newUserId);

            //// update new user
            //await goRest.UpdateUser(newData, newUserId);

            //// delete user
            //await goRest.DeleteUser(newUserId);

            var postToAdd = new Post
            {
                Id = 100,
                user_id = 1050082, // foarte ciudat cum daca folosesc CamelCase nu se poate face request ul (Error 422 => Data validation failed (in response to a POST request, for example). Please check the response body for detailed error messages.)
                Title = "new post from VS",
                Body = "empty body"
            };

            var updadedVersion = new Post
            {
                Id = 100,
                user_id = 1050082,
                Title = "updaded post from VS",
                Body = "updaded body"

            };


            var goRest = RestService.For<IPost>(baseUrl, refitSettings);

            // add new Post for a certain user id
            await goRest.AddNewPost(postToAdd);

            //get all posts including the one we added
            var allPosts = await goRest.GetAllPosts();

            await goRest.UpdatePost(updadedVersion, allPosts.First().Id);

            //get certain s user s posts
            var userPosts = await goRest.GetUserPosts(1050082);


            foreach (Post post in allPosts)
            {
                Console.WriteLine(post.Title);
                await goRest.DeleteCertainPost(post.Id);
            }

        }
    }

}