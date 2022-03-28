using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PS.Domain
{   [Owned]
    public class Adress
    {
        public string City { get; set; }
        public string  StreetAdress { get; set; }
    }
}
