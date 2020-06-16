using Microsoft.EntityFrameworkCore;
using przyklKolos2.DTOs.Responses;
using przyklKolos2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using przyklKolos2.Exceptions;

namespace przyklKolos2.Services
{
    public class SqlServerCukierniaDbService : ICukierniaDbService
    {
        public readonly CukierniaDbContext _context;

        public SqlServerCukierniaDbService(CukierniaDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Zamowienie> GetZamowienie(string Nazwisko)
        {
            if (Nazwisko != null) 
            {
                Klient klient = _context.Klienci
                    .SingleOrDefault(k => k.Nazwisko.Equals(Nazwisko));
                if(klient == null)
                {
                    throw new NotFoundClientException($"Nie znaleziono klienta o id={klient.IdKlient} ");
                }

                return _context.Zamowienia.ToList().Where(z => z.IdKlient == klient.IdKlient);
            }
            else
            {
                return _context.Zamowienia.ToList();
            }

           
        }
    }
}
