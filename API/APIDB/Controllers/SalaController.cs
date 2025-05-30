using APIDB.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly AppDataContext _appDataContext;

        public SalaController(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }

        // GET: api/<SalaController>
        [HttpGet]
        public List<Sala> Get()
        {
            return _appDataContext.Sala.ToList();
        }
        // GET api/<SalaController>/5
        [HttpGet("/api/sala/i{id}")]
        public Sala GetI(int id)
        {
            return _appDataContext.Sala.Where(x => x.id == id).FirstOrDefault();
        }

        [HttpGet("/api/sala/s{pietro},{numer}")]
        public Sala GetS(string pietro, string numer)
        {
            return _appDataContext.Sala.Where(x => x.pietro == pietro && x.numer == numer).FirstOrDefault();
        }

        [HttpGet("/api/sala/p{dummy},{pietro},{numer}")]
        public SalaPlan GetSP(string pietro, string numer, string dummy)
        {
            SalaPlan sp = new SalaPlan();

            Sala s = _appDataContext.Sala.Where(x => x.pietro == pietro && x.numer == numer).FirstOrDefault();
            List<Lekcja> p = _appDataContext.Lekcja.Where(x => x.sala.id == s.id).ToList();

            sp.sala = s;
            sp.plan = p;

            return sp;
        }

        // POST api/<SalaController>
        [HttpPost("{nauczycielId},{pietro},{numer},{dodatkoweInfo}")]
        public void Post(int nauczycielId, string pietro, string numer, string dodatkoweInfo)
        {
            Sala sala = new Sala();
            sala.nauczyciel = _appDataContext.Nauczyciel.Where(x => x.id == nauczycielId).FirstOrDefault();
            sala.pietro = pietro;
            sala.numer = numer;
            sala.dodatkoweInfo = dodatkoweInfo;

            _appDataContext.Add(sala);
            _appDataContext.SaveChanges();

        }

        // PUT api/<SalaController>/5
        [HttpPut("{id},{nauczycielId},{pietro},{numer},{dodatkoweInfo}")]
        public void Put(int id, int nauczycielId, string pietro, string numer, string dodatkoweInfo)
        {
            _appDataContext.Sala.Where(x => x.id == id).FirstOrDefault().nauczyciel = _appDataContext.Nauczyciel.Where(x => x.id == nauczycielId).FirstOrDefault();
            _appDataContext.Sala.Where(x => x.id == id).FirstOrDefault().pietro = pietro;
            _appDataContext.Sala.Where(x => x.id == id).FirstOrDefault().numer = numer;
            _appDataContext.Sala.Where(x => x.id == id).FirstOrDefault().dodatkoweInfo = dodatkoweInfo;

            _appDataContext.SaveChanges();
        }

        // DELETE api/<SalaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Sala toDelete = _appDataContext.Sala.Where(x => x.id == id).FirstOrDefault();
            _appDataContext.Sala.Remove(toDelete);
            _appDataContext.SaveChanges();
        }
    }
}
