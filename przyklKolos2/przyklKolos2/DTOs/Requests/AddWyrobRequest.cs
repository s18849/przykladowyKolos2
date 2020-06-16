using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace przyklKolos2.DTOs.Requests
{
    public class AddWyrobRequest
    {
        public int ilosc { get; set; }
        public string nazwa { get; set; }
        public string uwagi { get; set; }
    }
}
