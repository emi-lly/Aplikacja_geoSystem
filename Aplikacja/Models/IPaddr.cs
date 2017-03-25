using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore;


namespace Aplikacja.Models
{
    public class IPaddr
    {
        [Required(ErrorMessage = "Podaj adres w formie x.x.x.x")]
        [StringLength(15)]
        public string _IPaddrInput = "1.1.1.1";

        public string IPaddrInput
        {
            get
            { return _IPaddrInput; }
            set
            { _IPaddrInput = value; }
        }
        public string def { get; set; }

        /*public static string GetUserIPAddress()
        {
            var context = Request.Host.Value;//System.Web.HttpContext.Current;
            string ip = String.Empty;

            if (context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                ip = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            else if (!String.IsNullOrWhiteSpace(context.Request.UserHostAddress))
                ip = context.Request.UserHostAddress;

            if (ip == "::1")
                ip = "127.0.0.1";

            return ip;
        }*/
    }
}
