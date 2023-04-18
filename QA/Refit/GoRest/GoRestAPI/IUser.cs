using GoRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace GoRestAPI
{
    [Headers("Authorization: Bearer")]
    public interface IUser
    {
        [Get("/users")]
        Task<List<User>> GetAllUsers();

        [Get("/users/{id}")]
        Task<User> GetUserById(int id);

        [Post("/users")]
        Task  CreateUser([Body] User user);

        [Put("/users/{id}")]
        Task UpdateUser([Body] User user, int id);

        [Delete("/users/{id}")]
        Task DeleteUser(int id);
    }
}
