using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tweeter.Data;
using Tweeter.Models;
using Tweeter.Dtos;

namespace Tweeter.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly DataContext _context;

    public HomeController(ILogger<HomeController> logger)
    {
        _context = new DataContext();
        _logger = logger;
    }

    public IActionResult Index()
    {
        var tweets = _context.Tweets.OrderByDescending(t => t.Id).Select(t => 
            new TweetDto
            {
                Id = t.Id,
                Author = t.Author.Fullname,
                AuthorId = t.AuthorId,
                Text = t.Text,
                Updated = t.Updated,
                Likes = t.Likes.Count
            }).ToList();

        return View(tweets);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
