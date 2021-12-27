namespace Tweeter.Dtos;

public class UserTweetsDto
{
    public string Name { get; set; }

    public IEnumerable<TweetTextDateDto> Tweets { get; set; }
}