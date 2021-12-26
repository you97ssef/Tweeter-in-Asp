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
        if(HttpContext.Session.GetInt32("UserId") == null)
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
}
