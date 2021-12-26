using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tweeter.Data;
using Tweeter.Models;

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
        IEnumerable<Tweet>? tweets = _context.Tweets.Include(t => t.Author).ToList();

        return View(tweets);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
