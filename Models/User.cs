using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tweeter.Models;

public class User
{
    public int Id { get; set; }

    [MaxLength(64)]
    public string? Fullname { get; set; }

    [MaxLength(64)]
    public string? Username { get; set; }
    
    [MaxLength(64), MinLength(6)]
    public string? Password { get; set; }

    public ICollection<Tweet>? Tweets { get; set; }
    public ICollection<Like>? Likes { get; set; }
    
    [ForeignKey("FollowerId")]
    public ICollection<Follow>? Followers { get; set; }

    [ForeignKey("FolloweeId")]
    public ICollection<Follow>? Followees { get; set; }
}