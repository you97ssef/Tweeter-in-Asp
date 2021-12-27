namespace Tweeter.Dtos;

public class UserProfileDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Follows { get; set; }
    public int Followers { get; set; }
    public IEnumerable<TweetTextDateDto> Tweets { get; set; }
}