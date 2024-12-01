using AutoMapper;
using CoreERP.Dtos;
using CoreERP.Interfaces;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace CoreERP.Controllers
{
    public class AdminController : Controller
    {
        IMapper mapper;
       private readonly IUserService _userService;

        public AdminController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            _userService = userService;
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
<<<<<<< HEAD
                    RedirectToAction("RegisterCompany","Admin");
=======

                    //if(Log.Role=="Role")
                    //{
                    //    HttpContext.Session.SetString("Role", "Admin");
                    var loggedInUserRole = HttpContext.Session.GetString("UserRole");
                    ViewBag.Role = loggedInUserRole;
                    return RedirectToAction("Index", "Admin");
                    //}
                }
                else
                {
                    ViewBag.errorMessage = "Login Failed";
>>>>>>> cf69d8e8159a309aac14902bcf6a99bdb8b7f5f4
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult RegisterCompany()
        {
            return View();
        }


    }

}
