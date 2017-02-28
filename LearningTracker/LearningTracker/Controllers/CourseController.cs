using LearningTracker.Data;
using LearningTracker.Data.Entities;
using LearningTracker.Data.Repositories;
using LearningTracker.Helpers;
using LearningTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Web;
using Microsoft.AspNet.Identity;

namespace LearningTracker.Controllers
{
    public class CourseController : Controller
    {
        LearningContext context = new LearningContext();
        
        // GET: Course
        public ActionResult Index()
        {
            
            var repository = new CourseRepository(context);
            var entities = repository.GetAll();
            var model = MapperHelper.mapper.Map<IEnumerable<CourseViewModel>>(entities);
            return View(model);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            var model = new CourseDetailsViewModel();
            var repository = new CourseRepository(context);
            var includes = new Expression<Func<Course, object>>[] { x => x.Topics };
            var entity = repository.QueryIncluding(x => x.Id == id, includes).SingleOrDefault();
            model = MapperHelper.mapper.Map<CourseDetailsViewModel>(entity);
            return View(model);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            var model = new CourseViewModel();
            var repository = new CourseRepository(context);
            var topicRepository = new TopicRepository(context);
            var topics = topicRepository.Query(null, "Name");
            model.AvailableTopics = MapperHelper.mapper.Map<ICollection<TopicViewModel>>(topics);
            return View(model);
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(CourseViewModel model)
        {
            try
            {
                var repository = new CourseRepository(context);
                var topicRepository = new TopicRepository(context);
                var topics = topicRepository.Query(null, "Name");
                model.AvailableTopics = MapperHelper.mapper.Map<ICollection<TopicViewModel>>(topics);
                
                if (ModelState.IsValid) {
                    var entity = MapperHelper.mapper.Map<Course>(model);
                    repository.InsertCourse(entity, model.SelectedTopics);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);

            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new CourseViewModel();
            try
            {
                var repository = new CourseRepository(context);
                var includes = new Expression<Func<Course, object>>[] { x => x.Topics };
                var entity = repository.QueryIncluding(x => x.Id == id, includes).SingleOrDefault();
                var topicRepository = new TopicRepository(context);
                var topics = topicRepository.Query(null, "Name");
                model = MapperHelper.mapper.Map<CourseViewModel>(entity);
                model.AvailableTopics = MapperHelper.mapper.Map<ICollection<TopicViewModel>>(topics);
                model.SelectedTopics = entity.Topics.Select(x => x.Id.Value).ToArray();
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CourseViewModel model)
        {
            try
            {
                var repository = new CourseRepository(context);
                var topicRepository = new TopicRepository(context);
                var topics = topicRepository.Query(null, "Name");
                model.AvailableTopics = MapperHelper.mapper.Map<ICollection<TopicViewModel>>(topics);

                if (ModelState.IsValid)
                {
                    var entity = MapperHelper.mapper.Map<Course>(model);
                    repository.UpdateCourse(entity, model.SelectedTopics);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                
                
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new CourseViewModel();
            var repository = new CourseRepository(context);
            var entity = repository.Find(id);
            model = MapperHelper.mapper.Map<CourseViewModel>(entity);
            return View(model);
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CourseViewModel collection)
        {
            try
            {
                var repository = new CourseRepository(context);
                var entity = repository.Find(id);
                repository.Delete(entity);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
