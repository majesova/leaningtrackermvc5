using AutoMapper;
using LearningTracker.Data.Entities;
using LearningTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningTracker.Helpers
{
    public class MapperHelper
    {
        internal static IMapper mapper;

        static MapperHelper() {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Individual, IndividualViewModel>().ReverseMap();
                x.CreateMap<Course, CourseViewModel>().ReverseMap();
                x.CreateMap<Topic, TopicViewModel>().ReverseMap();
                x.CreateMap<Course, CourseDetailsViewModel>().ReverseMap();
                x.CreateMap<AssignedCourseItem, AssignedCourse>().ReverseMap();
                x.CreateMap<NewAssignmentCoursesViewModel, AssignedCourse>().ReverseMap();
                x.CreateMap<EditAssignmentCoursesViewModel, AssignedCourse>().ReverseMap();
            });
            mapper = config.CreateMapper();
        }
    }
}