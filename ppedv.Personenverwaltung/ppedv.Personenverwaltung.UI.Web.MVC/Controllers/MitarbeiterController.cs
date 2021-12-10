using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.Personenverwaltung.Logik;
using ppedv.Personenverwaltung.Model;
using ppedv.Personenverwaltung.Model.Contacts;

namespace ppedv.Personenverwaltung.UI.Web.MVC.Controllers
{
    public class MitarbeiterController : Controller
    {
        Core core;

        public MitarbeiterController(IRepository repo)
        {
            core = new Core(repo);
        }

        // GET: MitarbeiterController
        public ActionResult Index()
        {
            return View(core.Repository.GetAll<Mitarbeiter>());
        }

        // GET: MitarbeiterController/Details/5
        public ActionResult Details(int id)
        {
            return View(core.Repository.GetById<Mitarbeiter>(id));
        }

        // GET: MitarbeiterController/Create
        public ActionResult Create()
        {
            return View(new Mitarbeiter() { Name = "NEU" });
        }

        // POST: MitarbeiterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mitarbeiter mitarbeiter)
        {
            try
            {
                core.Repository.Add(mitarbeiter);
                core.Repository.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MitarbeiterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(core.Repository.GetById<Mitarbeiter>(id));
        }

        // POST: MitarbeiterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Mitarbeiter mitarbeiter)
        {
            try
            {
                core.Repository.Update(mitarbeiter);
                core.Repository.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MitarbeiterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(core.Repository.GetById<Mitarbeiter>(id));
        }

        // POST: MitarbeiterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var loaded = core.Repository.GetById<Mitarbeiter>(id);
                core.Repository.Delete(loaded);
                core.Repository.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
