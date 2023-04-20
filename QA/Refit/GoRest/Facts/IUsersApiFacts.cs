global using Xunit;
using GoRest;
using GoRestAPI;
using Refit;
namespace Facts
{
    public class IUsersApiFacts
    {
        public RefitSettings RefitSettings = new RefitSettings()
        {
            AuthorizationHeaderValueGetter = async () => await Task.FromResult("d4def2b2e62b4489f8b40995bd9201a8479a1be90fbcbf605b8a46e8a27dbb6c")
        };

        User VSUser = new User
        {

            Id = 1,
            Name = "Ana Maria Vs",
            Gender = "female",
            Email = "testfemaleVS@test.comm",
            Status = "active"

        };

      //  [Fact] ////#1
        public async Task GetAllUsers()
        {
            IUsersApi goRest = RestService.For<IUsersApi>("https://gorest.co.in/public/v2", RefitSettings);

            var allUsers = await goRest.GetAllUsers();
            Assert.False(allUsers.Any(user => user.Name == VSUser.Name));
        }

     //   [Fact] ////#2
        public async Task AddNewUser_UserNameIsPresentInList()
        {

            IUsersApi goRest = RestService.For<IUsersApi>("https://gorest.co.in/public/v2", RefitSettings);

            await goRest.CreateUser(VSUser);


            var allUsers = await goRest.GetAllUsers();

            Assert.True(allUsers.Any(user => user.Name == VSUser.Name));

            var userById = await goRest.GetUserById(allUsers.First().Id);
            Assert.Equal(VSUser.Name, userById.Name);
        }

        // nu inteleg o chestie, de ex:
        // 1. daca rulez toate testele si cele de sus (Fact #1 si Fact #2) impreuna cu (Fact #3 si Fact#4) ,
        //  => Fact 3 si 4 nu vor identifica elementul adaugat la Fact 2
        //  -ca Fact 3 si 4 sa nu pice, trebuie sa rulez 1 data testele (#1 si #2) fara (#3 si #4) apoi doar #3 si #4 fara 1 si 2

       [Fact] //#3
        public async Task GetUpdadedInformation()
        {
            IUsersApi goRest = RestService.For<IUsersApi>("https://gorest.co.in/public/v2", RefitSettings);
            var newData = new User
            {

                Name = "Updated Ana Maria Vs",
                Gender = "female",
                Email = "updadedEmail@test.com",
                Status = "active"
            };


            var getUserByName = await goRest.GetUsersByName(VSUser.Name);
            await goRest.UpdateUser(newData, getUserByName.Single().Id);
        }

        [Fact] //#4
        public async Task GetUserByName_UserShouldBeTheOneWeAddedInThePeviousFact()
        {
            IUsersApi goRest = RestService.For<IUsersApi>("https://gorest.co.in/public/v2", RefitSettings);

            var getUserByName = await goRest.GetUsersByName(VSUser.Name);
            var id = getUserByName.First().Id;
            await goRest.DeleteUser(getUserByName.First().Id);
        }

    }
}