using APIDB.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrzedmiotController : ControllerBase
    {
        private readonly AppDataContext _appDataContext;

        public PrzedmiotController(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;

        }
        // GET: api/<PrzedmiotController>
        [HttpGet]
        public List<Przedmiot> Get()
        {
            return _appDataContext.Przedmiot.ToList();
        }

        // GET api/<PrzedmiotController>/5
        [HttpGet("{id}")]
        public Przedmiot Get(int id)
        {
            return _appDataContext.Przedmiot.Where(x => x.id == id).FirstOrDefault();
        }

        // POST api/<PrzedmiotController>
        [HttpPost("{nazwa}")]
        public void Post(string nazwa)
        {
            Przedmiot przedmiot = new Przedmiot();

            przedmiot.nazwa = nazwa;

            _appDataContext.Add(przedmiot);
            _appDataContext.SaveChanges();
        }

        // PUT api/<PrzedmiotController>/5
        [HttpPut("{id},{nazwa}")]
        public void Put(int id, string nazwa)
        {
            _appDataContext.Przedmiot.Where(x => x.id == id).FirstOrDefault().nazwa = nazwa;

            _appDataContext.SaveChanges();
        }

        // DELETE api/<PrzedmiotController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Przedmiot toDelete = _appDataContext.Przedmiot.Where(x => x.id == id).FirstOrDefault();
            _appDataContext.Przedmiot.Remove(toDelete);
            _appDataContext.SaveChanges();
        }
    }
}
