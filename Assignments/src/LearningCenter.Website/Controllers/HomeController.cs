using LearningCenter.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningCenter.Website.Models;
using System.Security.Permissions;
using LearningCenter.Business;
using Microsoft.Ajax.Utilities;

namespace LearningCenter.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClassManager classManager;
        private readonly IUserManger userManager;
        private readonly IUserClassManager userClassManager;

        public HomeController(IClassManager classManager, IUserManger userManager, IUserClassManager userClassManager)
        {
            this.classManager = classManager;
            this.userManager = userManager;
            this.userClassManager = userClassManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ClassList()
        {
            ViewBag.Message = "Classes";
            var classes = classManager.Classes.Select(t => new ClassModel { Id = t.Id, Description = t.Description, Name = t.Name, Price = t.Price }).ToArray();

            var model = new ClassesViewModel
            {
                Classes = classes
            };
            return View(model);
        }

        [Authorize]
        public ActionResult StudentClasses()
        {
            ViewBag.Message = "Student Classes";

            var user = (UserModel)Session["User"];
            var classes = userClassManager.Classes(user.Id)
                .Select(t => new UserClassModel { ClassId = t.ClassId, ClassName = t.ClassName, ClassDescription = t.ClassDescription, ClassPrice = t.ClassPrice })
                .ToArray();

            return View(classes);
        }

        [Authorize]
        public ActionResult EnrollInClass()
        {
            var user = (UserModel)Session["User"];
            var model = new EnrollInClassViewModel
            {
                AvailableClasses = GetAvailableClasses(user.Id)
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EnrollInClass(EnrollInClassViewModel viewModel)
        {
            var user = (UserModel)Session["User"];

            if (ModelState.IsValid)
            {
                
                var enrolledClass = userClassManager.Add(user.Id, viewModel.SelectedClassId);
                var classes = userClassManager.Classes(user.Id)
                    .Select(t => new UserClassModel { ClassId = t.ClassId, ClassName = t.ClassName, ClassDescription = t.ClassDescription, ClassPrice = t.ClassPrice })
                    .ToArray();

                return View("StudentClasses", classes);
            }
            else
            {
                var model = new EnrollInClassViewModel
                {
                    AvailableClasses = GetAvailableClasses(user.Id)
                };

                return View(model);
            }
            
        }

        private IEnumerable<SelectListItem> GetAvailableClasses(int userId)
        {
            var enrolledClasses = userClassManager.Classes(userId)
                .Select(t => new UserClassModel { ClassId = t.ClassId, ClassName = t.ClassName, ClassDescription = t.ClassDescription, ClassPrice = t.ClassPrice })
                .ToArray();

            var availableClasses = classManager.Classes.Where(t => !enrolledClasses.Any(u => u.ClassId == t.Id)).Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToArray();

            return availableClasses;
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.LogIn(loginModel.Email, loginModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Email and password do not match.");
                }
                else
                {
                    Session["User"] = new UserModel { Id = user.Id, Email = user.Email, IsAdmin = user.IsAdmin };

                    System.Web.Security.FormsAuthentication.SetAuthCookie(loginModel.Email, false);

                    return Redirect(returnUrl ?? "~/");
                }
            }

            return View(loginModel);
        }

        public ActionResult LogOff()
        {
            Session["User"] = null;
            System.Web.Security.FormsAuthentication.SignOut();

            return Redirect("~/");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                userManager.Register(registerModel.Email, registerModel.Password);

                return Redirect("~/");
            }
            else
            {
                return View();
            }
        }
    }
}