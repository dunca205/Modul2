namespace GoRestAPI
{
    public class Comment
    {
        public int Id { get; set; }
        public int post_id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
