using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuiEksamenDel2.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace GuiEksamenDel2.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            var sessionUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));
            return View();
        }
    }
}
