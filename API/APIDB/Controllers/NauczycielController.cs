using APIDB.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NauczycielController : ControllerBase
    {
        private readonly AppDataContext _appDataContext;

        public NauczycielController(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }

        // GET: api/<NauczycieleKontroler>
        [HttpGet]
        public List<Nauczyciel> Get()
        {
            return _appDataContext.Nauczyciel.ToList();
        }

        // GET api/<NauczycieleKontroler>/5
        [HttpGet("{id}")]
        public Nauczyciel Get(int id)
        {
            return _appDataContext.Nauczyciel.Where(x => x.id == id).FirstOrDefault();
        }

        // POST api/<NauczycieleKontroler>
        [HttpPost("{imie},{nazwisko}")]
        public void Post(string imie, string nazwisko)
        {
            Nauczyciel nauczyciel = new Nauczyciel();

            nauczyciel.imie = imie;
            nauczyciel.nazwisko = nazwisko;

            _appDataContext.Add(nauczyciel);
            _appDataContext.SaveChanges();
        }

        // PUT api/<NauczycieleKontroler>/5
        [HttpPut("{id},{imie},{nazwisko}")]
        public void Put(int id, string imie, string nazwisko)
        {
            _appDataContext.Nauczyciel.Where(x => x.id == id).FirstOrDefault().imie = imie;
            _appDataContext.Nauczyciel.Where(x => x.id == id).FirstOrDefault().nazwisko = nazwisko;

            _appDataContext.SaveChanges();
        }

        // DELETE api/<NauczycieleKontroler>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Nauczyciel toDelete = _appDataContext.Nauczyciel.Where(x => x.id == id).FirstOrDefault();
            _appDataContext.Nauczyciel.Remove(toDelete);
            _appDataContext.SaveChanges();
        }
    }
}
