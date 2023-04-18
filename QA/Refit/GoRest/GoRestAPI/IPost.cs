using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoRestAPI
{
    [Headers("Authorization: Bearer")]
    public interface IPost
    {
        [Get("/posts")]
        Task<List<Post>> GetAllPosts();

        [Get("/posts?user_id={id}")]
        Task<List<Post>> GetUserPosts(int id);

        [Post("/posts")]
        Task AddNewPost([Body] Post post);

        [Put("/posts/{postId}")]
        Task UpdatePost([Body] Post updateData, int postId);

        [Delete("/posts/{id}")]
        Task DeleteCertainPost(int id);
    }
}
