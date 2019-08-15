using Darek_kancelaria.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static Darek_kancelaria.Controllers.ManageController;

namespace Darek_kancelaria.Controllers
{
    public class HomeController : Controller
    {
        private ContentContext _db;
        ///private ApplicationUserManager _userManager;
        public HomeController()
        {
            _db = new ContentContext();
        }

        public ActionResult Index()
        {
            return View(MPContent());
        }

        [Authorize]
        public ActionResult AddMainPage()
        {
            return View(MPContent());
        }
        
        /// <summary>
        /// Add main page content 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddMainPage(MainPageContent model)
        {
            if (ModelState.IsValid)
            {
                SaveContent(model.FirsGrid, 1);
                SaveContent(model.SecGrid, 1);
                SaveContent(model.ThirdGrid, 1);
                ViewBag.Message = "Dane zostały zapisane!";
                return View();
            }
            else
            {
                return View(model);
            }

        }
        [Authorize]
        public ActionResult AddAboutMe()
        {
            return View(GetAboutMe(2));
        }

        /// <summary>
        /// Add something about me
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddAboutMe(PageContent model)
        {
            if (ModelState.IsValid)
            {
                SaveContent(model, 2);
                ViewBag.Message = "Dane zostały zapisane!";
                return View();
            }
            return View(model);
        }

        public ActionResult AboutMe()
        {
            return View(GetAboutMe(2));
        }

        [Authorize]
        public ActionResult AddOffer()
        {
            return View(GetAboutMe(3));
        }



        /// <summary>
        /// Adding an offer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ValidateInput(false)]
        public ActionResult AddOffer(PageContent model)
        {
            if (ModelState.IsValid)
            {
                SaveContent(model, 3);
                ViewBag.Message = "Dane zostały zapisane!";
                return View();
            }
            return View(model);
        }

        public ActionResult Offer()
        {
            return View(GetAboutMe(3));
        }
        [Authorize]
        public ActionResult AddContact()
        {
            using (_db)
            {
                var contact = _db.Contacts.FirstOrDefault();
                if (contact != null)
                {
                    return View(contact);
                }
                else
                {
                    return View(new ContactModel());
                }
            }
        }
        /// <summary>
        /// Add contact information
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddContact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                using (_db)
                {
                    var contact = _db.Contacts.FirstOrDefault();
                    if (contact != null)
                    {
                        contact.Address = model.Address;
                        contact.Code = model.Code;
                        contact.Email = model.Email;
                        contact.Phone = model.Phone;
                        contact.Postal = model.Postal;

                        _db.SaveChanges();
                    }
                    else
                    {
                        _db.Contacts.Add(model);
                        _db.SaveChanges();
                    }
                }
                ViewBag.Message = "Dane zostały zapisane!";
                return View();
            }
            else
            {
                return View(model);
            }
        }


        public ActionResult Contact()
        {
            using (_db)
            {
                var contact = _db.Contacts.FirstOrDefault();
                if (contact != null)
                {
                    var eModel = new EmailModel
                    {
                        Contact = contact
                    };
                    return View(eModel);
                }
                else
                {
                    var eModel = new EmailModel
                    {
                        Contact = new ContactModel()
                    };
                    return View(eModel);
                }
            }
        }
        /// <summary>
        /// Send client question and add client to database. Block client if send more than 3 messages per day.
        /// </summary>
        /// <param name="model">Email object</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Contact(EmailModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.Message = Logging.CheckSender(Request.UserHostAddress, model);
                    ModelState.Clear();
                    var contact = _db.Contacts.FirstOrDefault();
                    if (contact != null)
                    {
                        var eModel = new EmailModel
                        {
                            Contact = contact
                        };
                        return View(eModel);
                    }
                    else
                    {
                        var eModel = new EmailModel
                        {
                            Contact = new ContactModel()
                        };
                        return View(eModel);
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Shared");
                }
            }
            else
            {
                var contact = _db.Contacts.FirstOrDefault();
                if (contact != null)
                {
                    model.Contact = contact;
                    return View(model);
                }
                else
                {
                    model.Contact = new ContactModel();
                    return View(model);
                }
            }
        }
        /// <summary>
        /// View blog entry
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult BlogView(int id)
        {
            using (_db)
            {
                var getBlog = _db.Blogs.FirstOrDefault(x => x.Id == id);
                if (getBlog != null)
                {
                    return View(getBlog);
                }
                return View("Error");
            }
        }
        /// <summary>
        /// Blog view
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns></returns>
        public ActionResult Blog(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var blogs = _db.Blogs.Select(x => x).OrderByDescending(x => x.AddDate);
            return View(blogs.ToPagedList(pageNumber, pageSize));
        }


        /// <summary>
        /// List of blog entries
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns></returns>
        public ActionResult BlogList(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            var blogs = _db.Blogs.Select(x => x).OrderByDescending(x => x.AddDate);
            return View(blogs.ToPagedList(pageNumber, pageSize));

        }

        [Authorize]
        public ActionResult AddBlog()
        {
            return View();
        }
        /// <summary>
        /// Add blog entry 
        /// </summary>
        /// <param name="model">Blog entry object</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddBlog(BlogModel model)
        {
            if (ModelState.IsValid)
            {
                using (_db)
                {
                    var blog = new BlogModel
                    {
                        AddDate = DateTime.Now,
                        Title = model.Title,
                        Content = model.Content
                    };
                    _db.Blogs.Add(blog);
                    _db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Message = "Dane zostały zapisane!";
                    return View();
                }
            }
            return View(model);
        }
        /// <summary>
        /// Delete blog entry
        /// </summary>
        /// <param name="id">Entry id</param>
        /// <returns></returns>
        [Authorize]
        public ActionResult DeleteBlog(int id)
        {
            try
            {
                using (_db)
                {
                    _db.Blogs.Remove(_db.Blogs.FirstOrDefault(x => x.Id == id));
                    _db.SaveChanges();
                    return View();
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }
        /// <summary>
        /// Edit blog entry
        /// </summary>
        /// <param name="id">Entry id</param>
        /// <returns></returns>
        [Authorize]
        public ActionResult EditBlog(int id)
        {
            using (_db)
            {
                var getBlog = _db.Blogs.Where(x => x.Id == id).FirstOrDefault();
                if (getBlog != null)
                {
                    return View(getBlog);
                }
                return RedirectToAction("Error");
            }
        }
        /// <summary>
        /// Remove all blog entries
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult BlogRemoveAll()
        {
            try
            {
                using (_db)
                {
                    var getAll = _db.Blogs.Select(x => x);
                    _db.Blogs.RemoveRange(getAll);
                    _db.SaveChanges();
                    ViewBag.Message = "Wszystkie wpisy bloga zostały usunięte!";
                    return View();
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        /// <summary>
        /// Visitors who sent the mail - ip addresses
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns></returns>
        [Authorize]
        public ActionResult GetMailedIp(int? page)
        {
            using (_db)
            {
                int pageSize = 20;
                int pageNumber = (page ?? 1);
                var getSender = _db.Logs.Where(x => x.SMail == true).Select(x => x).OrderByDescending(x => x.DateTime);
                if (getSender != null)
                {
                    return View(getSender.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
        }

        /// <summary>
        /// Who viewed site
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns></returns>
        [Authorize]
        public ActionResult WhoViewed(int? page)
        {
            using (_db)
            {
                int pageSize = 20;
                int pageNumber = (page ?? 1);
                var getSender = _db.Logs.Where(x => x.SMail == false).Select(x => x).OrderByDescending(x => x.DateTime);
                if (getSender != null)
                {
                    return View(getSender.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
        }


        /// <summary>
        /// Edit blog entry information
        /// </summary>
        /// <param name="model"> Edited object</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult EditBlog(BlogModel model)
        {
            if (ModelState.IsValid)
            {
                using (_db)
                {
                    var getBlog = _db.Blogs.Where(x => x.Id == model.Id).FirstOrDefault();
                    getBlog.Content = model.Content;
                    getBlog.Title = model.Title;
                    _db.SaveChanges();
                    return RedirectToAction("Blog");
                }
            }
            return View(model);
        }

        public ActionResult Error()
        {
            return View();
        }


        #region HELPERS



        /// <summary>
        /// Get main page information (for all sections)
        /// </summary>
        /// <returns></returns>
        private MainPageContent MPContent()
        {
            using (_db)
            {
                var content = _db.PageContents.Where(x => x.PageNumber == 1).Select(x => x).ToList();
                if (content != null)
                {
                    var mpc = new MainPageContent
                    {
                        FirsGrid = content.Where(x => x.WitchGrid == 1).FirstOrDefault(),
                        SecGrid = content.Where(x => x.WitchGrid == 2).FirstOrDefault(),
                        ThirdGrid = content.Where(x => x.WitchGrid == 3).FirstOrDefault()
                    };
                    return mpc;
                }
                else
                {
                    return new MainPageContent();

                }
            }
        }

        /// <summary>
        /// Get information about me
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns></returns>
        private PageContent GetAboutMe(int page)
        {
            using (_db)
            {
                var content = _db.PageContents.Where(x => x.PageNumber == page).Select(x => x).FirstOrDefault();
                if (content != null)
                {
                    return content;
                }
                else
                {
                    return new PageContent();

                }
            }
        }

        /// <summary>
        /// Save main page data (all three sections)
        /// </summary>
        /// <param name="content">Section content</param>
        /// <param name="page">Witch section</param>
        [Authorize]
        private void SaveContent(PageContent content, int page)
        {
            try
            {
                if (page == 1)
                {
                    var getPages = _db.PageContents.Where(x => x.PageNumber == 1 && x.WitchGrid == content.WitchGrid).Select(x => x).FirstOrDefault();
                    if (getPages != null)
                    {
                        getPages.Content = content.Content;
                        getPages.Title = content.Title;
                    }
                    else
                    {
                        var pc = new PageContent
                        {
                            PageNumber = page,
                            Content = content.Content,
                            Title = content.Title.ToUpper(),
                            WitchGrid = content.WitchGrid
                        };
                        _db.PageContents.Add(pc);
                    }
                }
                if (page == 2 || page == 3)
                {
                    var getPages = _db.PageContents.Where(x => x.PageNumber == page).Select(x => x).FirstOrDefault();
                    if (getPages != null)
                    {
                        getPages.Content = content.Content;
                        getPages.Title = content.Title;
                    }
                    else
                    {
                        var pc = new PageContent
                        {
                            PageNumber = page,
                            Content = content.Content,
                            Title = content.Title,
                            WitchGrid = 0
                        };
                        _db.PageContents.Add(pc);
                    }
                }
                _db.SaveChanges();
            }
            catch (Exception)
            {
                RedirectToAction("Error");
            }
        }

        /// <summary>
        /// Facebook redirection counter
        /// </summary>
        /// <returns>Confirmation</returns>
        public JsonResult FaceCounter()
        {
            using (_db)
            {
                var count = _db.Faces.Select(x => x).FirstOrDefault();
                if (count != null)
                {
                    count.Counter += 1;
                }
                else
                {
                    _db.Faces.Add(new FaceCountModel { Counter = 1});
                    _db.SaveChanges();
                }
                _db.SaveChanges();
                return Json("OK", JsonRequestBehavior.AllowGet);
            }
        }


        /// <summary>
        /// Remove visitors data
        /// </summary>
        /// <param name="mailers">Visitors who sent the mail</param>
        /// <returns></returns>
        [Authorize]
        public ActionResult RemoveVisitors(bool mailers)
        {
            try
            {
                using (_db)
                {
                    var getVisitors = _db.Logs.Where(x => x.SMail == mailers).Select(x => x).ToList();
                    _db.Logs.RemoveRange(getVisitors);
                    _db.SaveChanges();
                }
                if (mailers) {
                    return RedirectToAction("Index", "Manage", new { message = ManageMessageId.RemovedMailers });
                }
                return RedirectToAction("Index", "Manage", new { message = ManageMessageId.RemovedVisitors });
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }
    }
}
        #endregion

