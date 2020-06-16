using System.Collections.Generic;

namespace przyklKolos2.Models
{
    public class Klient
    {
        public int IdKlient { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public ICollection<Zamowienie> Zamowienia{ get; set; }
    }
}