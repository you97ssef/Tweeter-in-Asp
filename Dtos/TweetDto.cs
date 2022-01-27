namespace Tweeter.Dtos;

public class TweetDto
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public string? Author { get; set; }
    public int AuthorId { get; set; }
    public DateTime Updated { get; set; }
    public int Likes { get; set; }
}