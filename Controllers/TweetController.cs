using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tweeter.Data;
using Tweeter.Dtos;
using Tweeter.Models;

namespace Tweeter.Controllers;

public class TweetController : Controller
{
    private readonly DataContext _context;

    public TweetController()
    {
        _context = new DataContext();
    }

    public IActionResult New()
    {
        if (HttpContext.Session.GetInt32("UserId") == null)
            return RedirectToAction("Index", "Home");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult New(string content)
    {
        Tweet newTweet = new Tweet();

        newTweet.Text = content;
        newTweet.Created = DateTime.Now;
        newTweet.Updated = DateTime.Now;
        newTweet.AuthorId = (int)HttpContext.Session.GetInt32("UserId");

        _context.Tweets.Add(newTweet);

        if (_context.SaveChanges() > 0)
        {
            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    public IActionResult Like(int id)
    {
        var userId = (int)HttpContext.Session.GetInt32("UserId");

        if (_context.Likes.FirstOrDefault(l => l.TweetId == id && l.UserId == userId) == null)
        {
            var like = new Like
            {
                UserId = userId,
                TweetId = id
            };

            _context.Likes.Add(like);

            _context.SaveChanges();
        }

        return RedirectToAction("Index", new
        {
            Id = id
        });
    }

    public IActionResult Index(int id)
    {
        var tweet = _context.Tweets.Where(t => t.Id == id).Select(t => new TweetDto
        {
            Id = t.Id,
            Author = t.Author.Fullname,
            AuthorId = t.AuthorId,
            Text = t.Text,
            Updated = t.Updated,
            Likes = t.Likes.Count
        }).SingleOrDefault();

        return View(tweet);
    }


}
