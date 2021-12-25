using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tweeter.Models;

public class Tweet
{
    public int Id { get; set; }

    [MaxLength(255)]
    public string Text { get; set; }
    public User Author { get; set; }
    public int AuthorId { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }

    public ICollection<Like> Likes { get; set; }
}
