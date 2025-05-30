using APIDB.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlasaController : ControllerBase
    {
        private readonly AppDataContext _appDataContext;

        public KlasaController(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }

        // GET: api/<LekcjaController>
        [HttpGet]
        public List<Klasa> Get()
        {
            return _appDataContext.Klasa.ToList();
        }

        // GET api/<KlasaController>/5
        [HttpGet("{id}")]
        public Klasa Get(int id)
        {
            return _appDataContext.Klasa.Where(x => x.id == id).FirstOrDefault();
        }

        // POST api/<KlasaController>
        [HttpPost("{nazwa}")]
        public void Post(string nazwa)
        {
            _appDataContext.Add(new Klasa { nazwa = nazwa });
            _appDataContext.SaveChanges();
        }

        // PUT api/<KlasaController>/5
        [HttpPut("{id},{nazwa}")]
        public void Put(int id, string nazwa)
        {
            _appDataContext.Klasa.Where(x => x.id == id).FirstOrDefault().nazwa = nazwa;
            _appDataContext.SaveChanges();
        }

        // DELETE api/<KlasaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _appDataContext.Remove(_appDataContext.Klasa.Where(x => x.id == id).FirstOrDefault());
            _appDataContext.SaveChanges();
        }
    }
}
