using Microsoft.AspNetCore.Mvc;
using ppedv.Personenverwaltung.Logik;
using ppedv.Personenverwaltung.Model;
using ppedv.Personenverwaltung.Model.Contacts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.Personenverwaltung.UI.Web.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KundenAPIController : ControllerBase
    {
        Core core;

        public KundenAPIController(IRepository repo)
        {
            core = new Core(repo);
        }

        // GET: api/<KundenAPI>
        [HttpGet]
        public IEnumerable<Kunde> Get()
        {
            return core.Repository.GetAll<Kunde>();
        }

        // GET api/<KundenAPI>/5
        [HttpGet("{id}")]
        public Kunde Get(int id)
        {
            return core.Repository.GetById<Kunde>(id);
        }

        // POST api/<KundenAPI>
        [HttpPost]
        public void Post([FromBody] Kunde value)
        {
            core.Repository.Add(value);
            core.Repository.Save();
        }

        // PUT api/<KundenAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Kunde value)
        {
            //var loaded = Get(id);
            core.Repository.Update(value);
            core.Repository.Save();
        }

        // DELETE api/<KundenAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var loaded = Get(id);
            core.Repository.Delete(loaded);
            core.Repository.Save();
        }
    }
}
