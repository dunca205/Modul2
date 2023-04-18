using Refit;

var token = "d4def2b2e62b4489f8b40995bd9201a8479a1be90fbcbf605b8a46e8a27dbb6c";
var newUser = new User
{
    Id = 1,
    Name = "Ana Maria",
    Gender = "female",
    Email = "testfemale@test.comm",
    Status = "active"
};

var newData = new User
{
    Id = 2,
    Name = "Updated Ana Maria",
    Gender = "female",
    Email = "updadedEmail@test.com",
    Status = "active"
};

var refitSettings = new RefitSettings()
{
    AuthorizationHeaderValueGetter = async () => await Task.FromResult(token)
};

var goRest = RestService.For<IUser>("https://gorest.co.in/public/v2", refitSettings);

// create a new user
await goRest.CreateUser(newUser);

// get all users including the one we create
var allUsers = await goRest.GetAllUsers();

// get the Id for the user we added
var newUserId = allUsers.First().Id;

Console.WriteLine("Id of new user {0} is : {1} ", allUsers.First().Name, newUserId);

// get user by id
var userById = await goRest.GetUserById(newUserId);

// update new user
await goRest.UpdateUser(newData, newUserId);

// delete user
await goRest.DeleteUser(newUserId);

[Headers("Authorization: Bearer")]
public interface IUser
{
    [Get("/users")]
    Task<List<User>> GetAllUsers();

    [Get("/users/{id}")]
    Task<User> GetUserById(int id);

    [Post("/users")]
    Task CreateUser([Body] User user);

    [Put("/users/{id}")]
    Task UpdateUser([Body] User user, int id);

    [Delete("/users/{id}")]
    Task DeleteUser(int id);
}

public class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public string? Status { get; set; }
}
