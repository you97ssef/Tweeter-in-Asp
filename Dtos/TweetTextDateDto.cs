namespace Tweeter.Dtos;

public class TweetTextDateDto
{
    public int Id { get; set; }
    public string? Text { get; set; } 
    public DateTime Updated { get; set; }
    public int Likes { get; set; }
}