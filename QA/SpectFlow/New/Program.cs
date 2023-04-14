// See https://aka.ms/new-console-template for more information
using Refit;

var post = RestService.For<IPost>("https://jsonplaceholder.typicode.com");
var octocat = await post.GetAllPosts();
Console.WriteLine("Hello, World!");
public class Post
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    
}
public interface IPost
{
    [Get("/posts")]

    Task<IEnumerable<Post>> GetAllPosts();

}
