using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using wedding_planner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace wedding_planner.Controllers
{
    public class HomeController : Controller
    {

        //  NOTE DB function
        private wedding_plannerContext db;
        public HomeController(wedding_plannerContext context)
        {
            db = context;
        }

        private int? UserSession
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
        }



        // NOTE LOGIN/REGISTRATION routes
        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }


        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid) 
            {
                if (db.Users.Any(u=> u.Email == newUser.Email)) 
                {
                    ModelState.AddModelError("Email", "Email is already in use");
                    return View("Index");
                }
                PasswordHasher<User> Hasher =  new PasswordHasher<User>();
                //Hash the password only after verifying that everything else is good to go
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                db.Add(newUser);
                db.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }





        [HttpPost("login")]
        public IActionResult Login(LoginUser loginUser)
        {
            if (ModelState.IsValid == false)
            {
                return View("Index");
            }

            User dbUser = db.Users
                .FirstOrDefault(u => u.Email== loginUser.LoginEmail);
            
            if (dbUser == null)
            {
                ModelState.AddModelError("LoginEmail", "Email not found");
            }

            if (ModelState.IsValid == false)
            {
                return View("Index");
            }

            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            PasswordVerificationResult pwCompareResult = hasher.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

            if (pwCompareResult == 0)
            {
                ModelState.AddModelError("LoginEmail", "Incorrect password");
                return View("Index");
            }

            HttpContext.Session.SetInt32("UserId", dbUser.UserId);
            return RedirectToAction("Dashboard");
        }


        [HttpPost("logout")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }




        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            List<Wedding> AllWeddings = db.Weddings.Include(w => w.GuestList).OrderByDescending (d => d.CreatedAt).ToList();
            
        
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index");
            }
            return View("Dashboard", AllWeddings);

        }


        // NOTE Wedding Routes
        [HttpGet("/weddings/new")]
        public IActionResult NewWedding()
        {
            return View("Newwedding");
        }



        [HttpPost("/weddings/create")]
        public IActionResult CreateWedding(Wedding createWedding)
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index");
            }

            int UserId = (int) HttpContext.Session.GetInt32("UserId");
            if (ModelState.IsValid)
            {
                createWedding.UserId = UserId;
                createWedding.Creator = db.Users.FirstOrDefault(u => u.UserId == UserId);

                db.Weddings.Add(createWedding);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("Newwedding");
        }




        [HttpPost("weddings/delete/{weddingId}")]
        public IActionResult DeleteWedding(int weddingId)
        {   
            Wedding toDelete = db.Weddings.FirstOrDefault( d => d.WeddingId == weddingId);
            int UserId = (int) HttpContext.Session.GetInt32("UserId");
            if (toDelete != null)
            {
                db.Weddings.Remove(toDelete);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("Dashboard");
        }




        // NOTE Many to Many Weddings
                // many to many categories 



        [HttpGet("/weddings/{weddingId}")]
        public IActionResult Viewwedding(int weddingId)
        {
            int? UserId = (int) HttpContext.Session.GetInt32("UserId");
            if (ModelState.IsValid)
            {
                Wedding wedding = db.Weddings
                .Include(w => w.GuestList)
                .ThenInclude(g => g.guest)
                .FirstOrDefault(t => t.WeddingId == weddingId);

                if (UserId == null)
                {
                    return RedirectToAction("Dashboard");
                }

            return View("Viewwedding", wedding);
            
            }
            return RedirectToAction("Dashboard");
        }


        // [HttpPost("/RSVP/{weddingId}")]
        // public IActionResult RSVP(int weddingId)
        // {
        //     RSVP newRSVP = new RSVP()
        //     {
        //         WeddingId = weddingId, UserId = (int)UserSession
        //     };

        //     Console.WriteLine("Hello, we made it");
        //     db.Add(newRSVP);
        //     db.SaveChanges();
        //     return RedirectToAction("Dashboard");

        // }

            // [HttpPost("/RSVP/{WeddingID}")]
            //         public IActionResult RSVP(RSVP newGuestResponse, int WeddingID, int UserId, bool existingRSVP)
            //         {
            //             int ? userId = HttpContext.Session.GetInt32("UserId");
            //             if (userId != null)
            //             {
            //                 if(existingRSVP){
            //                     newGuestResponse.UserId = (int)HttpContext.Session.GetInt32("UserId");
            //                     newGuestResponse = db.RSVPs.FirstOrDefault(g => g.WeddingId == WeddingID && g.UserId == newGuestResponse.UserId);
            //                     db.RSVPs.Remove(newGuestResponse);
            //                     db.SaveChanges();
            //                     return RedirectToAction("Dashboard");

            //                 } else {
            //                     Wedding currentWedding = db.Weddings.Include(w => w.GuestList).ThenInclude(u => u.guest).FirstOrDefault(cw => cw.WeddingId == WeddingID);

            //                     newGuestResponse.WeddingId = currentWedding.WeddingId; 
            //                     newGuestResponse.UserId =(int) HttpContext.Session.GetInt32("UserId");
            //                     db.Add(newGuestResponse);
            //                     db.SaveChanges();
            //                     return RedirectToAction("Dashboard");
            //                 }
            //             }
            //             return View("Index");
            //         }

        [HttpPost("/RSVP/{weddingId}")]
        public IActionResult RSVP(int weddingId)
        {
            if (UserSession == null)
            {
                return RedirectToAction("Index");
            }

            RSVP isRSVPed = db.RSVPs
            .FirstOrDefault(r => r.WeddingId == weddingId && r.UserId == UserSession);

            if(isRSVPed == null)
            {
                RSVP newRSVP = new RSVP()
                {
                    WeddingId = weddingId, UserId = (int)UserSession
                };

            Console.WriteLine("Hello, we made it");
            db.Add(newRSVP);
            db.SaveChanges();
            return RedirectToAction("Dashboard");

            }

            db.Remove(isRSVPed);
            db.SaveChanges();
            return RedirectToAction("Dashboard");

            
        }







        // NOTE pre installed things
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
