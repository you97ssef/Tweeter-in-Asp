namespace Tweeter.Models;

public class Follow
{
    public int Id { get; set; }
    public int FolloweeId { get; set; }
    public int FollowerId { get; set; }
}