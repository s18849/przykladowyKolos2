using przyklKolos2.DTOs.Requests;
using przyklKolos2.DTOs.Responses;
using przyklKolos2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace przyklKolos2.Services
{
    public interface ICukierniaDbService
    {
        public IEnumerable<Zamowienie> GetZamowienie(string Nazwisko);
        public void AddZamowienie(int id, AddZamowienieRequest request);
    }
}
