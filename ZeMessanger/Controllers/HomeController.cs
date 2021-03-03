using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ZeMessanger.Data;
using ZeMessanger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;

namespace ZeMessanger.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        public readonly UserManager <AppUser> _userManger;
        public HomeController(ApplicationDbContext context,ILogger<HomeController> logger,UserManager<AppUser> userManger)
        {
            _context = context;
            _logger = logger;
            _userManger = userManger;
        }

        public async Task< IActionResult> Index()
        {
          string rec= HttpContext.Session.GetString("reciever");
            var user = User.Identity.Name;
            var currentUser = await _userManger.GetUserAsync(User);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = currentUser.UserName;
              
            }
          
            var message = await _context.Messages.Where(a=>(a.UserName == user || a.RcreiverName == user)&& (a.RcreiverName== rec || a.UserName == rec)).ToListAsync();
            return View(message);
        }

        public async Task<IActionResult>Create (Message message )
        {
            if (ModelState.IsValid)
            {
                string rec = HttpContext.Session.GetString("reciever");
                message.UserName = User.Identity.Name;
                message.RcreiverName = rec;
                var sender = await _userManger.GetUserAsync(User);
                message.UserID = sender.Id;
                Noti noti = new Noti()
                {
                    UserID = sender.Id,
                    FromUserName = User.Identity.Name,
                    ToUserName=rec,
                    NotiBody=message.Text,
                    NotiHeader=message.Text,
                
                };
                await _context.Notis.AddAsync(noti);
                await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return Error();
        }
        public async Task<IActionResult> Privacy()
        {
            var currentUser = await _userManger.GetUserAsync(User);
            var list = _userManger.Users.Where(a => a.UserName != currentUser.UserName).ToList();
            ViewBag.listOfUsers = list;
            return View();
        }
        public IActionResult GetRecieverName(string reciever)
        {
            HttpContext.Session.SetString("reciever", reciever);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
