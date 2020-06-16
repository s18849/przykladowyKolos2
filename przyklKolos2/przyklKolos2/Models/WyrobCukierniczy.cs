using System.Collections.Generic;

namespace przyklKolos2.Models
{
    public class WyrobCukierniczy
    {
        public int IdWyrobuCukierniczego { get; set; }
        public string Nazwa { get; set; }
        public float CenaZaSzt { get; set; }
        public string Typ { get; set; }
        public ICollection<Zamowienie_WyrobCukierniczy> Zamowienia_WyrobyCukiernicze { get; set; }
    }
}