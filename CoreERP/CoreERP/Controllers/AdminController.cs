using AutoMapper;
using CoreERP.Dtos;
using CoreERP.Interfaces;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace CoreERP.Controllers
{
    public class AdminController : Controller
    {
        IMapper mapper;
       private readonly IUserService _userService;
        private CoreErpdbContext _dbContext;

        public AdminController(IMapper mapper, IUserService userService, CoreErpdbContext dbContext)
        {
            this.mapper = mapper;
            _userService = userService;
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginDtos loginDtos)
        {
            if(ModelState.IsValid)
            {
                

                
                var Log = _userService.GetUserLogin(loginDtos);
                //HttpContext.Session.SetString("Role", Log.Role.ToString());
                if (Log != null)
                {


                    //if(Log.Role=="Role")
                    //{
                    //    HttpContext.Session.SetString("Role", "Admin");
                    var loggedInUserRole = HttpContext.Session.GetString("Role");
                    HttpContext.Session.SetString("Role", Log.Role);
                    HttpContext.Session.SetString("Username", Log.Username);
                    ViewBag.Role = Log.Role;
                    return RedirectToAction("Index", "Admin");
                    //}
                }
                else
                {
                    ViewBag.errorMessage = "Login Failed";
                }
            }
            return View();
        }

        //public IActionResult CompanyRegistration(CompanyDtos companyDtos)
        //{

        //}

        [HttpGet]
        public IActionResult Dashboard()
        {
            // Retrieve LoginId from the session
            int userLoginId = HttpContext.Session.GetInt32("LoginId") ?? 0;

            if (userLoginId == 0)
            {
                ViewBag.ErrorMessage = "LoginId not found in session."; // Redirect if no LoginId found in session
            }

            // Fetch company data for the logged-in user
            var company = _dbContext.Companies.FirstOrDefault(c => c.LoginId == userLoginId);

            if (company == null)
            {
                return View("NoCompany"); // Show a view if no company is linked to this user
            }

            return View(company);
        }
    }


}


