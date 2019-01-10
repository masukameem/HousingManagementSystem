using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingManagement.Data;
using HousingManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HousingManagement.Controllers
{
    public class HomeController : Controller
    {
        //Database Context
        private readonly TestContext _context;
        private readonly IHostingEnvironment he;

        public HomeController(TestContext context, IHostingEnvironment e)
        {
            _context = context;
            he = e;
        }

        //GET: Index
        public IActionResult Index()
        {
            return View();
        }

        //POST: Index
        [HttpPost]
        public IActionResult Index(Users users)
        {
            using (var db = _context)
            {
                var test = _context.Users.Where(a => a.Email == users.Email && a.Password == users.Password).FirstOrDefault();
               
                if (test != null)
                {
                    RedirectToAction("UserProfile");
                }                
            }
            return View("Index");
        }

        //POST: Index
        [HttpPost]
        public IActionResult Index(Admins admin)
        {
            using (var db = _context)
            {
                var test = _context.Admins.Where(a => a.Id == admin.Id && a.Password == admin.Password).FirstOrDefault();
                if (test != null)
                {
                    RedirectToAction("AdminProfile");
                }               
            }
            return View("Index");
        }


        public IActionResult InsertUsers()
        {
            return View();
        }

        //POST: Users
        [HttpPost]
        public IActionResult InsertUsers([Bind("FirstName, LastName, Image, Contact, Email, Address, Username, Password, Status")]Users users, IFormFile Image)
        {
            using (var db = _context)
            {
                string uploadPath = Path.Combine(he.WebRootPath, "Images");
                Directory.CreateDirectory(Path.Combine(uploadPath));

                string filename = Image.FileName;
                if (filename.Contains('\\'))
                {
                    filename = filename.Split('\\').Last();

                }
                using (FileStream fs = new FileStream(Path.Combine(uploadPath, filename), FileMode.Create))
                {
                    Image.CopyTo(fs);
                }
                users.Image = filename;
               
                var test = new Users
                {
                    Id = users.Id,
                    FirstName = users.FirstName,
                    LastName = users.LastName,
                    Image = users.Image,
                    Contact = users.Contact,
                    Email = users.Email,
                    Address = users.Address,
                    Username = users.Username,
                    Password = users.Password,
                    Status = users.Status
                };

                db.Users.Add(test);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //GET: UserProfile
        public IActionResult UserProfile()
        {
            var test = _context.Users.FirstOrDefault();

            Users model = new Users
            {
                Id = test.Id,
                FirstName = test.FirstName,
                LastName = test.LastName,
                Image = test.Image,
                Contact = test.Contact,
                Email= test.Email,
                Address = test.Address,
                Username = test.Username,
                Password = test.Password,
                Status = test.Status
            };
            return View(model);
        }

        //GET: UserProfile/1
        [HttpPost]
        public IActionResult UserProfile(Users users)
        {
            using (var db = _context)
            {
                var test = _context.Users.Where(a => a.Email == users.Email && a.Password == users.Password).FirstOrDefault();
                if (test == null)
                {
                    return NotFound();
                }          
            return View(test);
            }
        }

        //GET: DeleteUserProfile/1
        public IActionResult DeleteUserProfile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var users = _context.Users.SingleOrDefault(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        //POST: DeleteUserProfile/1
        [HttpPost]
        public IActionResult DeleteUserProfile(int id)
        {
            var users = _context.Users.SingleOrDefault(m => m.Id == id);
            _context.Remove(users);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: AdminProfile/1
        public IActionResult AdminProfile()
        {
            var test = _context.Admins.FirstOrDefault();

            Admins model = new Admins
            {
                Id = test.Id,
                FirstName = test.FirstName,
                LastName = test.LastName,
                Image = test.Image,
                Contact = test.Contact,
                Email = test.Email,
                Address = test.Address,
                Username = test.Username,
                Password = test.Password
            };
            return View(model);
        }

        //POST: AdminProfile/1
        [HttpPost]
        public IActionResult AdminProfile(Admins admins)
        {

            using (var db = _context)
            {
                var test = _context.Admins.Where(a => a.Id == admins.Id && a.Password == admins.Password).FirstOrDefault();
                if (test == null)
                {
                    return NotFound();
                }

                return View(test);
            }
        }

        //GET: DeleteAdminProfile/1
        public IActionResult DeleteAdminProfile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var admins = _context.Admins.SingleOrDefault(m => m.Id == id);
            if (admins == null)
            {
                return NotFound();
            }
            return View(admins);

        }

        //POST: DeleteAdminProfile/1
        [HttpPost]
        public IActionResult DeleteAdminProfile(int id)
        {
            var admins = _context.Admins.SingleOrDefault(m => m.Id == id);
            _context.Remove(admins);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult InsertAdmins()
        {
            return View();
        }

        //POST: InsertAdmins
        [HttpPost]
        public IActionResult InsertAdmins([Bind("FirstName, LastName, Image, Contact, Email, Address, Username, Password")]Admins admins, IFormFile Image)
        {
            using (var db = _context)
            {
                string uploadPath = Path.Combine(he.WebRootPath, "Images");
                Directory.CreateDirectory(Path.Combine(uploadPath));

                string filename = Image.FileName;
                if (filename.Contains('\\'))
                {
                    filename = filename.Split('\\').Last();

                }
                using (FileStream fs = new FileStream(Path.Combine(uploadPath, filename), FileMode.Create))
                {
                    Image.CopyTo(fs);
                }
                admins.Image = filename;



                var test = new Admins
                {
                    Id = admins.Id,
                    FirstName = admins.FirstName,
                    LastName = admins.LastName,
                    Image = admins.Image,
                    Contact = admins.Contact,
                    Email = admins.Email,
                    Address = admins.Address,
                    Username = admins.Username,
                    Password = admins.Password
                };

                db.Admins.Add(test);
                db.SaveChanges();

            }
            return RedirectToAction("Admins");
        }

        //GET: Users
        public IActionResult Users() 
        {
            var test = _context.Users.ToList();
            UsersList usersModel = new UsersList
            {

                UsersAll = test
            };
            return View(usersModel);
        }

        //POST: Users/1
        [HttpPost]
        public IActionResult Users(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var test = _context.Users.Where(a => a.Id == Id).ToList();
            UsersList usersModel = new UsersList
            {
                UsersAll = test
            };

            return View(usersModel);
        }

        //GET: DeleteUsers/1
        public IActionResult DeleteUsers(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var users = _context.Users.SingleOrDefault(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);

        }

        //POST: DeleteUsers/1
        [HttpPost]
        public IActionResult DeleteUsers(int id)
        {
            var users = _context.Users.SingleOrDefault(m => m.Id == id);
            _context.Remove(users);
            _context.SaveChanges();
            return RedirectToAction("Users");
        }

        //GET: Admins
        public IActionResult Admins()
        {
            var test = _context.Admins.ToList();
            AdminsList adminsModel = new AdminsList
            {

                AdminsAll = test
            };
            return View(adminsModel);
        }

        //GET: Admins/1
        [HttpPost]
        public IActionResult Admins(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var test = _context.Admins.Where(a => a.Id == Id).ToList();
            AdminsList adminsModel = new AdminsList
            {
                AdminsAll = test
            };

            return View(adminsModel);
        }

        //GET: DeleteAdmins/1
        public IActionResult DeleteAdmins(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var admins = _context.Admins.SingleOrDefault(m => m.Id == id);
            if (admins == null)
            {
                return NotFound();
            }
            return View(admins);

        }

        //POST: DeleteAdmins/1
        [HttpPost]
        public IActionResult DeleteAdmins(int id)
        {
            var admins = _context.Admins.SingleOrDefault(m => m.Id == id);
            _context.Remove(admins);
            _context.SaveChanges();
            return RedirectToAction("Admins");
        }

        public IActionResult Sell()
        {
            var test = _context.SellAds.ToList();
            SellAdsList sellAdsModel = new SellAdsList
            {

                SellAdsAll = test
            };
            return View(sellAdsModel);
        }

        [HttpPost]
        public IActionResult Sell(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var test = _context.SellAds.Where(a => a.Id == Id).ToList();
            SellAdsList sellAdsModel = new SellAdsList
            {
                SellAdsAll = test
            };

            return View(sellAdsModel);
        }

        public IActionResult SellADmin()
        {
            var test = _context.SellAds.ToList();
            SellAdsList sellAdsModel = new SellAdsList
            {

                SellAdsAll = test
            };
            return View(sellAdsModel);
        }

        [HttpPost]
        public IActionResult SellAdmin(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var test = _context.SellAds.Where(a => a.Id == Id).ToList();
            SellAdsList sellAdsModel = new SellAdsList
            {
                SellAdsAll = test
            };

            return View(sellAdsModel);
        }

        public IActionResult InsertSell()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertSell([Bind("Id, Headline, Details, Address, Price, MainImage, BedroomNo, BathroomNo, OthersNo, NeighborhoodEast, NeighborhoodEastDistance, NeighborhoodWest, NeighborhoodWestDistance, NeighborhoodNorth, NeighborhoodNorthDistance, NeighborhoodSouth, NeighborhoodSouthDistance, AddedBy, OwnerName, OwnerContact, OwnerEmail")]SellAds sellAds, IFormFile Image)
        {
            using (var db = _context)
            {
                string uploadPath = Path.Combine(he.WebRootPath, "Images");
                Directory.CreateDirectory(Path.Combine(uploadPath));

                string filename = Image.FileName;
                if (filename.Contains('\\'))
                {
                    filename = filename.Split('\\').Last();

                }
                using (FileStream fs = new FileStream(Path.Combine(uploadPath, filename), FileMode.Create))
                {
                    Image.CopyTo(fs);
                }
                sellAds.MainImage = filename;

                
                var test = new SellAds

                {
                    Id = sellAds.Id,
                    Headline = sellAds.Headline, 
                    Details = sellAds.Details,
                    Address = sellAds.Address,
                    Price = sellAds.Price,
                    MainImage = sellAds.MainImage,
                    BedroomNo = sellAds.BedroomNo,
                    BathroomNo = sellAds.BathroomNo,
                    OthersNo = sellAds.OthersNo,
                    NeighborhoodEast = sellAds.NeighborhoodEast,
                    NeighborhoodEastDistance = sellAds.NeighborhoodEastDistance,
                    NeighborhoodWest = sellAds.NeighborhoodWest,
                    NeighborhoodWestDistance = sellAds.NeighborhoodWestDistance,
                    NeighborhoodNorth = sellAds.NeighborhoodNorth,
                    NeighborhoodNorthDistance = sellAds.NeighborhoodNorthDistance,
                    NeighborhoodSouth = sellAds.NeighborhoodSouth,
                    NeighborhoodSouthDistance = sellAds.NeighborhoodSouthDistance,
                    AddedBy = sellAds.AddedBy,
                    OwnerName = sellAds.OwnerName,
                    OwnerContact = sellAds.OwnerContact,
                    OwnerEmail = sellAds.OwnerEmail
                };

                db.SellAds.Add(test);
                db.SaveChanges();

            }
            return RedirectToAction("Sell");
        }

        public IActionResult DeleteSell(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sellAds = _context.SellAds.SingleOrDefault(m => m.Id == id);
            if (sellAds == null)
            {
                return NotFound();
            }
            return View(sellAds);

        }

        [HttpPost]
        public IActionResult DeleteSell(int id)
        {
            var sellAds = _context.SellAds.SingleOrDefault(m => m.Id == id);
            _context.Remove(sellAds);
            _context.SaveChanges();
            return RedirectToAction("SellAdmin");
        }

        public IActionResult SellDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var test = _context.SellAds.SingleOrDefault(m => m.Id == id);
            if (test == null)
            {
                return NotFound();
            }
            return View(test);

        }

        public IActionResult Rent()
        {
            var test = _context.RentAds.ToList();
            RentAdsList rentAdsModel = new RentAdsList
            {

                RentAdsAll = test
            };
            return View(rentAdsModel);
        }

        [HttpPost]
        public IActionResult Rent(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var test = _context.RentAds.Where(a => a.Id == Id).ToList();
            RentAdsList rentAdsModel = new RentAdsList
            {
                RentAdsAll = test
            };

            return View(rentAdsModel);
        }

        public IActionResult InsertRent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertRent([Bind("Id, Headline, Details, Address, Rent, MainImage, BedroomNo, BathroomNo,  OthersNo, NeighborhoodEast, NeighborhoodEastDistance, NeighborhoodWest, NeighborhoodWestDistance, NeighborhoodNorth, NeighborhoodNorthDistance, NeighborhoodSouth, NeighborhoodSouthDistance, AddedBy, OwnerName, OwnerContact, OwnerEmail")]RentAds rentAds, IFormFile Image)
        {
            using (var db = _context)
            {
                string uploadPath = Path.Combine(he.WebRootPath, "Images");
                Directory.CreateDirectory(Path.Combine(uploadPath));

                string filename = Image.FileName;
                if (filename.Contains('\\'))
                {
                    filename = filename.Split('\\').Last();

                }
                using (FileStream fs = new FileStream(Path.Combine(uploadPath, filename), FileMode.Create))
                {
                    Image.CopyTo(fs);
                }
                rentAds.MainImage = filename;

                var test = new RentAds

                {
                    Id = rentAds.Id,
                    Headline = rentAds.Headline,
                    Details = rentAds.Details,
                    Address = rentAds.Address,
                    Rent = rentAds.Rent,
                    MainImage = rentAds.MainImage,
                    BedroomNo = rentAds.BedroomNo,
                    BathroomNo = rentAds.BathroomNo,
                    OthersNo = rentAds.OthersNo,
                    NeighborhoodEast = rentAds.NeighborhoodEast,
                    NeighborhoodEastDistance = rentAds.NeighborhoodEastDistance,
                    NeighborhoodWest = rentAds.NeighborhoodWest,
                    NeighborhoodWestDistance = rentAds.NeighborhoodWestDistance,
                    NeighborhoodNorth = rentAds.NeighborhoodNorth,
                    NeighborhoodNorthDistance = rentAds.NeighborhoodNorthDistance,
                    NeighborhoodSouth = rentAds.NeighborhoodSouth,
                    NeighborhoodSouthDistance = rentAds.NeighborhoodSouthDistance,
                    AddedBy = rentAds.AddedBy,
                    OwnerName = rentAds.OwnerName,
                    OwnerContact = rentAds.OwnerContact,
                    OwnerEmail = rentAds.OwnerEmail
                };

                db.RentAds.Add(test);
                db.SaveChanges();

            }
            return RedirectToAction("Rent");
        }

        public IActionResult RentAdmin()
        {
            var test = _context.RentAds.ToList();
            RentAdsList rentAdsModel = new RentAdsList
            {

                RentAdsAll = test
            };
            return View(rentAdsModel);
        }

        [HttpPost]
        public IActionResult RentAdmin(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var test = _context.RentAds.Where(a => a.Id == Id).ToList();
            RentAdsList rentAdsModel = new RentAdsList
            {
                RentAdsAll = test
            };

            return View(rentAdsModel);
        }
        public IActionResult DeleteRent(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var rentAds = _context.RentAds.SingleOrDefault(m => m.Id == id);
            if (rentAds == null)
            {
                return NotFound();
            }
            return View(rentAds);

        }

        [HttpPost]
        public IActionResult DeleteRent(int id)
        {
            var rentAds = _context.RentAds.SingleOrDefault(m => m.Id == id);
            _context.Remove(rentAds);
            _context.SaveChanges();
            return RedirectToAction("RentAdmin");
        }

        public IActionResult RentDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var test = _context.RentAds.SingleOrDefault(m => m.Id == id);
            if (test == null)
            {
                return NotFound();
            }
            return View(test);

        }

        public IActionResult ReportUser()
        {
            return View();
        }

        public IActionResult InsertReport()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertReport([Bind("AddedBy, AddedName, AgainstId, ReportReason, Comment")]Report report)
        {
            using (var db = _context)
            {               
                var test = new Report
                {
                    Id = report.Id,
                    AddedBy = report.AddedBy,
                    AddedName = report.AddedName,
                    AgainstId = report.AgainstId,
                    ReportReason = report.ReportReason,
                    Comment =report.Comment
                };

                db.Report.Add(test);
                db.SaveChanges();

            }
            return RedirectToAction("UserProfile");
        }

        public IActionResult Reports()
        {
            var test = _context.Report.ToList();
            ReportList reportModel = new ReportList
            {

                ReportsAll = test
            };
            return View(reportModel);
        }

        [HttpPost]
        public IActionResult Reports(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var test = _context.Report.Where(a => a.Id == Id).ToList();
            ReportList reportModel = new ReportList
            {
                ReportsAll = test
            };

            return View(reportModel);
        }

        public IActionResult DeleteReport(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var report = _context.Report.SingleOrDefault(m => m.Id == id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);

        }

        [HttpPost]
        public IActionResult DeleteReport(int id)
        {
            var report = _context.Report.SingleOrDefault(m => m.Id == id);
            _context.Remove(report);
            _context.SaveChanges();
            return RedirectToAction("Reports");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public string ErrorLogin()
        {

            
            return "Invalid Login Details";

            //string st = frm["Status"].ToString();
            //return "Select Value is " + st;
        }

        public IActionResult Test()
        {

            return View();
        }
        [HttpPost]
        public string Test(IFormCollection frm)
        {

            string ut = frm["Status"].ToString();
            return "Select Value is " + ut;

            //string st = frm["Status"].ToString();
            //return "Select Value is " + st;
        }



        public IActionResult Index2(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var test = _context.SellAds.SingleOrDefault(m => m.Id == id);
            if (test == null)
            {
                return NotFound();
            }
            return View(test);

        }



    }
}
