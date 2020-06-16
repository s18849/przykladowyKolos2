namespace przyklKolos2.Models
{
    public class Zamowienie_WyrobCukierniczy
    {
        public int IdWyrobuCukierniczego { get; set; }
        public int IdZamowienia { get; set; }
        public int Ilosc { get; set; }
        public string Uwagi { get; set; }
        public Zamowienie Zamowienie { get; set; }
        public WyrobCukierniczy WyrobCukierniczy { get; set; }
    }
}