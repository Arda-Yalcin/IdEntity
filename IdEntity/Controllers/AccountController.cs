using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IdEntity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdEntity.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(ILogger<AccountController> logger,UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _signInManager=signInManager;
            _userManager=userManager;

        }


        public IActionResult Register()
        {
            return View();
        }


    }
}