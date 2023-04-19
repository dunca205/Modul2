using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoRestAPI
{
    [Headers("Authorization: Bearer")]
    public interface ICommentsApi
    {
        [Get("/comments")]
        Task<List<Comment>> GetAllComments();

        [Get("/comments?name={name}")]
        Task<List<Comment>> GetCommentsFor([AliasAs("name")] string name);

        [Post("/comments")]
        Task AddNewComment([Body] Comment comment);

        [Delete("/comments/{Id}")]   
        Task DeleteComment(int id);
        
    }
}
