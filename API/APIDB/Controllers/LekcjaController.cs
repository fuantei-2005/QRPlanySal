using APIDB.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LekcjaController : ControllerBase
    {
        private readonly AppDataContext _appDataContext;

        public LekcjaController(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }

        // GET: api/<LekcjaController>
        [HttpGet]
        public List<Lekcja> Get()
        {
            return _appDataContext.Lekcja.ToList();
        }

        // GET api/<LekcjaController>/5
        [HttpGet("{id}")]
        public Lekcja Get(int id)
        {
            return _appDataContext.Lekcja.Where(x => x.id == id).FirstOrDefault();
        }

        // POST api/<LekcjaController>
        [HttpPost("{salaId},{nauczycielId},{przedmiotId},{klasaId},{godzinaLekcyjna},{zastepstwo}")]
        public void Post(int salaId, int nauczycielId, int przedmiotId, int klasaId, int godzinaLekcyjna, bool zastepstwo)
        {
            Lekcja lekcja = new Lekcja();

            lekcja.sala = _appDataContext.Sala.Where(x => x.id == salaId).FirstOrDefault();
            lekcja.nauczyciel = _appDataContext.Nauczyciel.Where(x => x.id == nauczycielId).FirstOrDefault();
            lekcja.przedmiot = _appDataContext.Przedmiot.Where(x => x.id == przedmiotId).FirstOrDefault();
            lekcja.klasa = _appDataContext.Klasa.Where(x => x.id == klasaId).FirstOrDefault();
            lekcja.godzinaLekcyjna = godzinaLekcyjna;
            lekcja.zastepstwo = zastepstwo;

            _appDataContext.Add(lekcja);
            _appDataContext.SaveChanges();
        }

        // PUT api/<LekcjaController>/5
        [HttpPut("{id},{salaId},{nauczycielId},{przedmiotId},{klasaId},{godzinaLekcyjna},{zastepstwo}")]
        public void Put(int id,int salaId, int nauczycielId, int przedmiotId, int klasaId, int godzinaLekcyjna, bool zastepstwo)
        {
            _appDataContext.Lekcja.Where(x => x.id == id).FirstOrDefault().sala = _appDataContext.Sala.Where(x => x.id == salaId).FirstOrDefault();
            _appDataContext.Lekcja.Where(x => x.id == id).FirstOrDefault().nauczyciel = _appDataContext.Nauczyciel.Where(x => x.id == nauczycielId).FirstOrDefault();
            _appDataContext.Lekcja.Where(x => x.id == id).FirstOrDefault().przedmiot = _appDataContext.Przedmiot.Where(x => x.id == przedmiotId).FirstOrDefault();
            _appDataContext.Lekcja.Where(x => x.id == id).FirstOrDefault().klasa = _appDataContext.Klasa.Where(x => x.id == klasaId).FirstOrDefault();
            _appDataContext.Lekcja.Where(x => x.id == id).FirstOrDefault().godzinaLekcyjna = godzinaLekcyjna;
            _appDataContext.Lekcja.Where(x => x.id == id).FirstOrDefault().zastepstwo = zastepstwo;

            _appDataContext.SaveChanges();
        }

        // DELETE api/<LekcjaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Lekcja toDelete = _appDataContext.Lekcja.Where(x => x.id == id).FirstOrDefault();
            _appDataContext.Lekcja.Remove(toDelete);
            _appDataContext.SaveChanges();
        }
    }
}
