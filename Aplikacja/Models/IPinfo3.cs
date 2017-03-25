using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace Aplikacja.Models
{
    public class IPinfo3
    {
        public int ID { get; set; }
        public string ipaddress { get; set; }
        public string countryName { get; set; }
        public string countryCode { get; set; }
        public string regionName { get; set; }
        public string cityName { get; set; }
        public string zipCode { get; set; }
        public string timeZone { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }
    }
}
