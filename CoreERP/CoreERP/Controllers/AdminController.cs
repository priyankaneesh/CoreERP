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

                    //if(Log.Role=="Role")
                    //{
                    //    HttpContext.Session.SetString("Role", "Admin");
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


    }

}
