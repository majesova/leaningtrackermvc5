using LearningTracker.Data;
using LearningTracker.Data.Entities;
using LearningTracker.Data.Repositories;
using LearningTracker.Helpers;
using LearningTracker.Models;
using System.Collections.Generic;
using System.Web.Mvc;


namespace LearningTracker.Controllers
{
    [Authorize]
    public class IndividualController : Controller
    {
        LearningContext context = new LearningContext();
          
        // GET: individual
        public ActionResult Index()
        {
            var repository = new IndividualRepository(context);
            var entities = repository.GetAll();
            var results = MapperHelper.mapper.Map<ICollection<IndividualViewModel>>(entities);
           
            return View(results);
        }

        // GET: individual/Details/5
        public ActionResult Details(int id)
        {
            var repository = new IndividualRepository(context);
            var entity = repository.Find(id);
            var model = MapperHelper.mapper.Map<IndividualViewModel>(entity);
            return View(model);
        }

        // GET: individual/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: individual/Create
        [HttpPost]
        public ActionResult Create(IndividualViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repository = new IndividualRepository(context);

                    var emailExiste = repository.Query(x => x.Email == model.Email).Count > 0;
                    if (!emailExiste)
                    {
                        var entity = MapperHelper.mapper.Map<Individual>(model);
                        repository.Insert(entity);
                        context.SaveChanges();
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "El email está ocupado");
                        return View(model);
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: individual/Edit/5
        public ActionResult Edit(int id)
        {

            var repository = new IndividualRepository(context);
            var entity = repository.Find(id);
            var model = MapperHelper.mapper.Map<IndividualViewModel>(entity);
            ModelState.Remove("Email");
            return View(model);
        }

        // POST: individual/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IndividualViewModel model)
        {
            try
            {
                
                    var repository = new IndividualRepository(context);
                    ModelState.Remove("Email");
                    var entity = MapperHelper.mapper.Map<Individual>(model);
                    repository.Update(entity);
                    context.SaveChanges();
                    return RedirectToAction("Index");
            }
            catch
            {
                return View(new IndividualViewModel());
            }
        }

        // GET: individual/Delete/5
        public ActionResult Delete(int id)
        {

            var repository = new IndividualRepository(context);
            var entity = repository.Find(id);
            var model = MapperHelper.mapper.Map<IndividualViewModel>(entity);
            context.SaveChanges();
            return View(model);
        }

        // POST: individual/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var repository = new IndividualRepository(context);
                var entity = repository.Find(id);
                repository.Delete(entity);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(new IndividualViewModel());
            }
        }

        //Remote validacion
        [AllowAnonymous]
        public JsonResult CheckEmail(string email) {
                var repository = new IndividualRepository(context);
            var emailExiste = repository.Query(x => x.Email == email).Count == 0;
            return Json(emailExiste, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
