using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CIMS.Models;
using CIMS.Utility;
using CIMS.BaseLayer.Admin;
using CIMS.ActionLayer.Admin;
using CIMS.ActionLayer.Account;
using System.Data;

namespace CIMS.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        #region Declaration
        UserBase userBase = new UserBase();
        AccountAction accountAction = new AccountAction();
        CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();
        #endregion

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            LoginModel model = new LoginModel();
            var loginInfoCookies = Request.Cookies["LoginInfo"];
            //if (loginInfoCookies != null && loginInfoCookies.HasKeys)
            //{
            //    string userName = loginInfoCookies["UserName"];
            //    string userPassword = loginInfoCookies["UserPassword"];
            //    model.UserName = userName;
            //    model.Password = userPassword;
            //}
            try
            {
                //EnumMembers.Main();
                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                Response.Cache.AppendCacheExtension("no-cache");
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            ViewBag.ReturnUrl = returnUrl;


            // dhaval

            DataTable dt = new DataTable();
            dt = getbackground("");

            if (dt!= null && dt.Rows.Count > 0 && dt.Rows[0]["Corporate_logo"].ToString().Length > 0)
            {
                ViewBag.Corporate_logo = dt.Rows[0]["Corporate_logo"].ToString();
            }
            else
            {
                ViewBag.Corporate_logo = "admin-logo.png";
            }

            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["Customer_logo"].ToString().Length > 0)
            {
                ViewBag.Customer_logo = dt.Rows[0]["Customer_logo"].ToString();
            }
            else
            {
                ViewBag.Customer_logo = "";
            }

            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["Corporate_background"].ToString().Length > 0)
            {
                ViewBag.Corporate_background = dt.Rows[0]["Corporate_background"].ToString();

            }
            else
            {
                ViewBag.Corporate_background = "#f79646";
            }

            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["Corporate_back_type"].ToString().Length > 0)
            {
                ViewBag.Corporate_back_type = dt.Rows[0]["Corporate_back_type"].ToString();
            }
            else
            {
                ViewBag.Corporate_back_type = "palette";
            }



            return View();
        }


        public DataTable getbackground(string name)
        {
            CorporateBase CorporateBase = new CorporateBase();
            AdminAction adminAction = new AdminAction();

            CorporateBase.Corporate_action = "get";

            actionResult = adminAction.Corporate_update(CorporateBase);

            return (actionResult.dtResult);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int result = 0;
                    userBase.UserName = model.UserName;
                    userBase.Password = model.Password;
                    model.RememberMe = model.RememberMe;
                    actionResult = accountAction.Login_Load(userBase);
                    if (actionResult.IsSuccess)
                    {
                        DataRow dr = actionResult.dtResult.Rows[0];
                        result = Convert.ToInt32(dr[0]);
                        if (result < 0)
                        {
                            TempData["ErrorMessage"] = "UserName or Passwrd is wrong.";
                            return View(model);
                        }
                        else
                        {
                            //if (model.RememberMe)
                            //{
                            //    var loginInfoCookies = Request.Cookies["LoginInfo"];
                            //    if (loginInfoCookies != null && loginInfoCookies.HasKeys)
                            //    {
                            //        var userName = loginInfoCookies["UserName"];
                            //        var userPassword = loginInfoCookies["UserPassword"];
                            //        // Keep This Login Details in Cookies
                            //        loginInfoCookies["UserName"] = model.UserName;
                            //        loginInfoCookies["UserPassword"] = model.Password;
                            //        loginInfoCookies.Expires = DateTime.Now.AddMonths(6);
                            //        Response.Cookies.Add(loginInfoCookies);
                            //    }
                            //    else
                            //    {
                            //        var loginCookie1 = new HttpCookie("LoginInfo");
                            //        loginCookie1["UserName"] = model.UserName;
                            //        loginCookie1["UserPassword"] = model.Password;
                            //        Response.Cookies.Add(loginCookie1);
                            //    }
                            //}
                            Session["UserId"] = Convert.ToInt32(dr["ID"]);
                            Session["UserName"] = Convert.ToString(dr["UserName"]);
                            Session["RoleName"] = dr["RoleName"] != DBNull.Value ? Convert.ToString(dr["RoleName"]) : string.Empty;
                            Session["RoleId"] = dr["RoleId"] != DBNull.Value ? Convert.ToString(dr["RoleId"]) : "0";
                            Session["ReportProofreadCheck"] = 0;
                            // return RedirectToAction("Index", "Subject", new { area = "Subject" });
                            if (!string.IsNullOrEmpty(returnUrl))
                            {
                                return RedirectToLocal(returnUrl);
                            }
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error in login. Please try again later.";
                ErrorReporting.WebApplicationError(ex);
            }
            // dhaval

            DataTable dt = new DataTable();
            dt = getbackground("");

            if (dt.Rows.Count > 0 && dt.Rows[0]["Corporate_logo"].ToString().Length > 0)
            {
                ViewBag.Corporate_logo = dt.Rows[0]["Corporate_logo"].ToString();
            }
            else
            {
                ViewBag.Corporate_logo = "admin-logo.png";
            }

            if (dt.Rows.Count > 0 && dt.Rows[0]["Corporate_background"].ToString().Length > 0)
            {
                ViewBag.Corporate_background = dt.Rows[0]["Corporate_background"].ToString();

            }
            else
            {
                ViewBag.Corporate_background = "#f79646";
            }

            if (dt.Rows.Count > 0 && dt.Rows[0]["Corporate_back_type"].ToString().Length > 0)
            {
                ViewBag.Corporate_back_type = dt.Rows[0]["Corporate_back_type"].ToString();
            }
            else
            {
                ViewBag.Corporate_back_type = "palette";
            }
            return RedirectToAction("Login");
        }

        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(LoginModel model)
        {
            UserBase userBase = new UserBase();
            try
            {
                if (ModelState.IsValid)
                {
                    int result = 0;
                    userBase.UserName = model.UserName;
                    userBase.Password = model.Password;
                    userBase.RoleType = 2;
                    model.RememberMe = model.RememberMe;
                    actionResult = accountAction.Login_Load(userBase);
                    if (actionResult.IsSuccess)
                    {
                        DataRow dr = actionResult.dtResult.Rows[0];
                        result = Convert.ToInt32(dr[0]);
                        if (result < 0)
                        {
                            TempData["ErrorMessage"] = "UserName or Passwrd is wrong.";
                            return View(model);
                        }
                        else
                        {
                            Session["Admin"] = Convert.ToInt32(dr["Id"]);
                            Session["RoleName"] = "Admin";
                            Session["UserName"] = Convert.ToString(dr["UserName"]);
                            // return RedirectToAction("Index", "Subject", new { area = "Subject" });
                            return Redirect("~/Home/Index");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error in login. Please try again later.";
                ErrorReporting.WebApplicationError(ex);
            }
            return RedirectToAction("AdminLogin");
        }


        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        #region LogOff Get
        [HttpGet]
        public ActionResult LogOff()
        {
            var limit = Request.Cookies.Count;
            for (var i = 0; i < limit; i++)
            {
                var httpCookie = Request.Cookies[i];
                if (httpCookie != null)
                {
                    var cookieName = httpCookie.Name;
                    var aCookie = new HttpCookie(cookieName);
                    aCookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(aCookie);
                }
            }
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login");
        }
        #endregion

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}