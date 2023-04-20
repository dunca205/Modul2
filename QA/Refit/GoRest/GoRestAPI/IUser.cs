using GoRest;
using Refit;

namespace GoRestAPI
{
    [Headers("Authorization: Bearer")]
    public interface IUsersApi
    {
        [Get("/users")]
        Task<List<User>> GetAllUsers();

        [Get("/users/{id}")]
        Task<User> GetUserById(int id);

        [Get("/users")]
        Task<List<User>> GetUsersByName([Query("name")] string name);

        [Post("/users")]
        Task CreateUser([Body] User user);

        [Put("/users/{id}")]
        Task UpdateUser([Body] User user, int id);

        [Delete("/users/{id}")]
        Task DeleteUser(int id);
    }
}
