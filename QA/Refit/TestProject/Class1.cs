using Refit;

RefitSettings refitSettings = new RefitSettings()
{
    AuthorizationHeaderValueGetter = async () => await Task.FromResult("d4def2b2e62b4489f8b40995bd9201a8479a1be90fbcbf605b8a46e8a27dbb6c")
};

var goRest = RestService.For<IUser>("https://gorest.co.in/public/v2", refitSettings);

[Headers("Authorization: Bearer")]
public interface IPost
{
    [Get("/posts")]
    Task<List<Post>> GetAllPosts();
}

public class Post
{
    public int User { get; set; }

    public int UserId { get; set; }

    public string? Title { get; set; }

    public string? Body { get; set; }
}
