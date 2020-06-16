using Microsoft.EntityFrameworkCore;
using przyklKolos2.DTOs.Responses;
using przyklKolos2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using przyklKolos2.Exceptions;
using przyklKolos2.DTOs.Requests;

namespace przyklKolos2.Services
{
    public class SqlServerCukierniaDbService : ICukierniaDbService
    {
        public readonly CukierniaDbContext _context;

        public SqlServerCukierniaDbService(CukierniaDbContext context)
        {
            _context = context;
        }

        public void AddZamowienie(int id, AddZamowienieRequest request)
        {
            if(_context.Klienci.Any(x =>x.IdKlient == id))
            {
                throw new NotFoundClientException($"Nie znaleziono klienta o id={id} ");
            }
            foreach(var wyrob in request.Wyroby)
            {
                var wyroby = _context.WyrobyCukiernicze.Any(x => x.Nazwa.Equals(wyrob.nazwa));
                    if (!wyroby)
                {
                    throw new NotFoundWyrobException($"Nie znaleziono wyrobu o nazwie={wyrob.nazwa}");
                }
            }

            int orderId = _context.Zamowienia.Max(x => x.IdZamowienia) + 1;
            _context.Zamowienia.Add(
                new Zamowienie
                {
                    IdZamowienia = orderId,
                    DataPrzyjecia = request.dataPrzyjecia,
                    Uwagi = request.Uwagi,
                    IdKlient = id
                }
            );
            foreach (var wyrob in request.Wyroby)
            {
                _context.Zamowienia_WyrobyCukiernicze.Add(
                    new Zamowienie_WyrobCukierniczy
                    {
                        IdWyrobuCukierniczego = _context.WyrobyCukiernicze
                            .Single(x => x.Nazwa.Equals(wyrob.nazwa))
                            .IdWyrobuCukierniczego,
                        IdZamowienia = orderId,
                        Ilosc = wyrob.ilosc,
                        Uwagi = wyrob.uwagi
                    }
                );
            }

            _context.SaveChanges();

        }

        public IEnumerable<Zamowienie> GetZamowienie(string Nazwisko)
        {
            if (Nazwisko != null) 
            {
                Klient klient = _context.Klienci
                    .SingleOrDefault(k => k.Nazwisko.Equals(Nazwisko));
                if(klient == null)
                {
                    throw new NotFoundClientException($"Nie znaleziono klienta o nazwisku={Nazwisko} ");
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
