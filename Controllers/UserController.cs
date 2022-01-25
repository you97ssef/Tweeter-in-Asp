using Microsoft.AspNetCore.Mvc;
using Tweeter.Data;
using Tweeter.Dtos;
using Tweeter.Models;
using Microsoft.EntityFrameworkCore;
using Tweeter.Services;

namespace Tweeter.Controllers;

public class UserController : Controller
{
    private readonly DataContext _context;

    public UserController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(User user)
    {
        var alert = new AlertDto();

        if (_context.Users.FirstOrDefault(u => u.Username == user.Username) != null)
        {
            alert.Color = "danger";
            alert.Message = "Username already exist";

            return View("Register", alert);
        }

        user.Password = PasswordService.Hash(user.Password);

        _context.Users.Add(user);

        if (_context.SaveChanges() > 0)
        {
            alert.Color = "success";
            alert.Message = "User created succefully";

            return View("Register", alert);
        }

        alert.Color = "warning";
        alert.Message = "Couldn't add user";

        return View("Register", alert);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(User user)
    {
        var alert = new AlertDto();

        var userFromDb = _context.Users.FirstOrDefault(u => u.Username == user.Username);
        if (userFromDb == null)
        {
            alert.Color = "danger";
            alert.Message = "Username dosen't exist";

            return View("Login", alert);
        }

        if (PasswordService.Verify(user.Password, userFromDb.Password))
        {
            alert.Color = "success";
            alert.Message = "Connected succefully";

            HttpContext.Session.SetString("Username", userFromDb.Username);
            HttpContext.Session.SetInt32("UserId", userFromDb.Id);
            HttpContext.Session.SetString("Fullname", userFromDb.Fullname);

            return RedirectToAction("Index", "Home");
        }

        alert.Color = "warning";
        alert.Message = "Wrong Password";

        return View("Login", alert);
    }


    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Register()
    {
        return View("Register", null);
    }

    public IActionResult Profile(int id)
    {
        var userFromDb = _context.Users
            .Where(u => u.Id == id).Include(u => u.Tweets)
            .Select(u => new UserProfileDto
            {
                Id = id,
                Name = u.Fullname,
                Follows = u.Followees.Count,
                Followers = u.Followers.Count,
                Tweets = u.Tweets.OrderByDescending(t => t.Id).Where(t => t.AuthorId == id).Select(t => new TweetTextDateDto
                {
                    Id = t.Id,
                    Text = t.Text,
                    Updated = t.Updated,
                    Likes = t.Likes.Count
                }).ToList()
            }).SingleOrDefault();

        return View(userFromDb);
    }

    public IActionResult Follow(int id)
    {
        var userId = (int)HttpContext.Session.GetInt32("UserId");

        if (_context.Follows.FirstOrDefault(l => l.FolloweeId == id && l.FollowerId == userId) == null)
        {
            var follow = new Follow
            {
                FollowerId = userId,
                FolloweeId = id
            };

            _context.Follows.Add(follow);

            _context.SaveChanges();
        }

        return RedirectToAction("Profile", new
        {
            Id = id
        });
    }
}
