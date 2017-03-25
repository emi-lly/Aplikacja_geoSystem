using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aplikacja.Models;
using Npgsql;
using System.Net;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aplikacja.Controllers
{
    public class IPAddressFormController1 : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IPaddrExecute()
        {
            return View();
        }

        // GET: /IPAddress/Create
        public IActionResult ValidateInput()
        {
            IPinfo newIPinfo = new IPinfo();
            return View(newIPinfo);
        }

        // POST: /IPAddress/Create
        [HttpPost]
        public IActionResult ValidateInput(string inputString)
        {
            IPaddr IPaddrInput = new IPaddr();
            IPaddrInput.IPaddrInput = inputString;
            //if (ModelState.IsValid)
            //{
                List<string> IPpartsList = GetIpaddressToList(IPaddrInput.IPaddrInput);
                double translatedIPaddress = TranslateIPaddress(IPpartsList);
                string ipToCheck = translatedIPaddress.ToString();

                //Connnection
                NpgsqlConnection connection = new NpgsqlConnection("Server=127.0.0.1;UserId=postgres;Password=postgres;Database=ip2location");
                //connection.Open();
                String query = "select * from ip2location_db11 where '" + ipToCheck + "' between ip_from and ip_to";
                NpgsqlCommand cmd = new NpgsqlCommand(query, connection);


                IPinfo3 IPdata = new IPinfo3();
                //var model = new IPinfo();
                using (connection)
                {
                    connection.Open();
                    NpgsqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        IPdata.countryName = (String)rdr["country_name"];
                        IPdata.countryCode = (String)rdr["country_code"];
                        IPdata.regionName = (String)rdr["region_name"];
                        IPdata.cityName = (String)rdr["city_name"];
                        IPdata.zipCode = (String)rdr["zip_code"];
                        IPdata.longitude = (float)rdr["longitude"];
                        IPdata.latitude = (float)rdr["latitude"];
                        IPdata.timeZone = (String)rdr["time_zone"];
                    }
                    connection.Close();
                //}

                return View(IPdata);
            }
            //return View(IPaddrInput);
        }

        public double TranslateIPaddress(List<string> ipAddress)
        {
            List<double> parsedDoubleIpAddress = new List<double>();
            double octet = 0;
            double translatedIpAddr = 0;
            int counter = 0;
            foreach (string s in ipAddress)
            {
                if (double.TryParse(s, out octet))
                {
                    Console.WriteLine(octet);
                    parsedDoubleIpAddress.Add(octet);
                }
                else
                {
                    Console.WriteLine("String could not be parsed.");
                }
                counter++;
            }
            translatedIpAddr += (parsedDoubleIpAddress.ElementAt(0) * Math.Pow(2, 24));
            translatedIpAddr += (parsedDoubleIpAddress.ElementAt(1) * Math.Pow(2, 16));
            translatedIpAddr += (parsedDoubleIpAddress.ElementAt(2) * Math.Pow(2, 8));
            translatedIpAddr += parsedDoubleIpAddress.ElementAt(3);

            return translatedIpAddr;
        }

        public List<string> GetIpaddressToList(string IPaddress)
        {
            IPAddress wynikowy;
            IPAddress.TryParse(IPaddress, out wynikowy);
            Console.WriteLine("Parse success");
            string wynikowy2 = wynikowy.ToString();

            List<string> stringList = wynikowy2.Split('.').ToList();
            return stringList;
        }
    }
}
