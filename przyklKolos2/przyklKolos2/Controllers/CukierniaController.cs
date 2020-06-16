using Microsoft.AspNetCore.Mvc;
using przyklKolos2.Exceptions;
using przyklKolos2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace przyklKolos2.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class CukierniaController : ControllerBase
    {
        private readonly ICukierniaDbService _dbService;
        public CukierniaController(ICukierniaDbService service)
        {
            _dbService = service;
        }

        [HttpGet("{nazwisko:string}")]
        public IActionResult GetZamowienia(string nazwisko)
        {
            try
            {
                var result = _dbService.GetZamowienie(nazwisko);
                return Ok(result);
            }catch(NotFoundClientException exc)
            {
                return NotFound(exc.Message);
            }
        }
    }
}
