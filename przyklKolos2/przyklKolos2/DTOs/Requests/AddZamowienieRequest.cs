using przyklKolos2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace przyklKolos2.DTOs.Requests
{
    public class AddZamowienieRequest
    {
        public DateTime dataPrzyjecia { get; set; }
        public string Uwagi { get; set; }
        public ICollection<AddWyrobRequest> Wyroby { get; set; }
    }
}
