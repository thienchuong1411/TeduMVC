using OnlineShop.Areas.Admin.Models;
using System.Web.Mvc;
using Models;
using OnlineShop.Areas.Admin.Code;
using System.Web.Security;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(LoginModel model)
        //{
        //    // check if end user have input username by [Required] property in LoginModel
        //    if(ModelState.IsValid)
        //    {
        //        var result = new UserModel().Login(model.UserName, model.Password);
        //        if(result)
        //        {
        //            // luu session
        //            //UserSession userSession = new UserSession();
        //            //userSession.UserName = model.UserName;

        //            // 2 lệnh trên có thể viết thành 1 dòng như sau:
        //            UserSession userSession = new UserSession() { UserName = model.UserName };
        //            SessionHelper.SetSession(userSession);

        //            // 2 lệnh trên có thể viết rút gọn như sau
        //            // SessionHelper.SetSession(new UserSession() { UserName = model.UserName });

        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Username or password is wrong");
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Please input UserName");
        //    }
        //    return View(model);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            // check if end user have input username by [Required] property in LoginModel
            if (ModelState.IsValid)
            {
                //var result = new UserModel().Login(model.UserName, model.Password);

                bool result = new CustomMembershipProvider().ValidateUser(model.UserName, model.Password);
                if (result)
                {
                    // lúc này ta dùng set cookie của Membership thay thế. Vì chút phải viết method Logout tương ứng
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is wrong");
                }
            }
            else
            {
                ModelState.AddModelError("", "Please input UserName");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}