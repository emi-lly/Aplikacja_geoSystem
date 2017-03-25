using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aplikacja.Models;

namespace Aplikacja.Controllers
{
    public class IPaddrController : Controller
    {
        public IActionResult ValidateInput()
        {
            var ipaddr = new IPaddr();
            ipaddr.def = "def";
            ViewBag.def = Request.Host.Value;
            ipaddr._IPaddrInput = Request.Host.Host;
            //var i = View(new IPaddr());
            
            return View(ipaddr);
        }
       
        [HttpPost]
        public IActionResult ValidateInput(IPaddr ipaddr)
        {
            if (!ModelState.IsValid)
            {
                return View(ipaddr);
            }
            //string test = inputString;
            //IPaddr IPaddrInput = new IPaddr();
            //IPaddrInput.IPaddrInput = inputString;
            //System.Diagnostics.Debug.WriteLine("kaczucha_ipaddr" + ipaddr.IPaddrInput);

            return RedirectToAction("Execute", "TheLast", new { inputString = ipaddr.IPaddrInput });
            
        }
    }
}