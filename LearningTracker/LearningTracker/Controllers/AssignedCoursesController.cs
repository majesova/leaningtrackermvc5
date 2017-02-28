using LearningTracker.Data;
using LearningTracker.Data.Entities;
using LearningTracker.Data.Repositories;
using LearningTracker.Filters;
using LearningTracker.Helpers;
using LearningTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace LearningTracker.Controllers
{
    [Authorize]
    public class AssignedCoursesController : Controller
    {
        LearningContext context = new LearningContext();
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: AssignedCourses
        [Log]
        public ActionResult Index()
        {
            
            var repository = new AssignedCourseRepository(context);
            var includes = new Expression<Func<AssignedCourse, object>>[] { x => x.Course, x=>x.Individual};
            ICollection<AssignedCourse> etities = new List<AssignedCourse>();
            
               etities = repository.QueryIncluding(null, includes, "AssignmentDate");
            
            var model = MapperHelper.mapper.Map<ICollection<AssignedCourseItem>>(etities);
            return View(model);
        }

        [HttpGet]
        public ActionResult NewAssignment() {
            var repository = new AssignedCourseRepository(context);
            var model = new NewAssignmentCoursesViewModel();
            model.CoursesList = PopulateCourses(model.CourseId);
            model.IndividualList = PopulateIndividuals(model.IndividualId);
            return View(model);
        }

        [HttpPost]
        public ActionResult NewAssignment(NewAssignmentCoursesViewModel model) {
            var repository = new AssignedCourseRepository(context);
            try { 

            if (ModelState.IsValid) {
                var entity = MapperHelper.mapper.Map<AssignedCourse>(model);
                entity.IsCompleted = false;
                repository.Insert(entity);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            model.CoursesList = PopulateCourses(model.CourseId);
            model.IndividualList = PopulateIndividuals(model.IndividualId);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult EditAssignment(int id) {
            var repository = new AssignedCourseRepository(context);
            var model = new EditAssignmentCoursesViewModel();
            try
            {
                var includes = new Expression<Func<AssignedCourse, object>>[] { x => x.Course, x => x.Individual };
                var entity = repository.QueryIncluding(x=>x.Id == id, includes, "AssignmentDate").SingleOrDefault();
                model = MapperHelper.mapper.Map<EditAssignmentCoursesViewModel>(entity);
                return View(model);
            }
            catch (Exception ex) {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }
            
        }

        [HttpPost]
        public ActionResult EditAssignment(int id, EditAssignmentCoursesViewModel model)
        {
            var repository = new AssignedCourseRepository(context);
            try
            {
                
                if (ModelState.IsValid) {

                    var entityForUpd = MapperHelper.mapper.Map<AssignedCourse>(model);
                    repository.Update(entityForUpd);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

                var includes = new Expression<Func<AssignedCourse, object>>[] { x => x.Course, x => x.Individual };
                var entity = repository.QueryIncluding(x => x.Id == id, includes, "AssignmentDate").SingleOrDefault();
                model.Course = MapperHelper.mapper.Map<CourseViewModel>(entity.Course);
                model.Individual = MapperHelper.mapper.Map<IndividualViewModel>(entity.Individual);
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }

        }
        private SelectList PopulateIndividuals(object selectedItem = null)
        {
            var repository = new IndividualRepository(context);
            var individuals = repository.Query(null, "Name").ToList();
            individuals.Insert(0, new Individual { Id = null, Name = string.Empty });
            return new SelectList(individuals, "Id", "Name", selectedItem);
        }

        private SelectList PopulateCourses(object selectedItem = null)
        {
            var repository = new CourseRepository(context);
            var courses = repository.Query(null, "Name").ToList();
            courses.Insert(0, new Course { Id = null, Name = string.Empty });
            return new SelectList(courses, "Id", "Name", selectedItem);
        }


        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

    }
}