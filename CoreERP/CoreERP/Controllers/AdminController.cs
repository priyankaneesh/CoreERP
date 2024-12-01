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
                
                var login = mapper.Map<Login>(loginDtos);
                var Log = _userService.GetUserLogin(login);
                if(Log != null)
                {

                }
            }
            return View();
        }

    }

}
