﻿using System;
using System.Collections.Generic;

namespace przyklKolos2.Models
{
    public class Zamowienie
    {
        public int IdZamowienia { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime? DataRealizacji { get; set; }
        public string Uwagi { get; set; }
        public int IdKlient { get; set; }
        public int IdPracownik { get; set; }
        public Pracownik Pracownik { get; set; }
        public Klient Klient { get; set; }
        public ICollection<Zamowienie_WyrobCukierniczy> Zamowienia_WyrobyCukiernicze { get; set; }
    }
}