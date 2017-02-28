using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningTracker.Models
{
    public class NewAssignmentCoursesViewModel
    {
        [DisplayName("Fecha de asignación")]
        [Required]
        public DateTime? AssignmentDate { get; set; }

        public SelectList IndividualList { get; set; }

        public SelectList CoursesList { get; set; }

        [DisplayName("Persona")]
        [Required]
        public int? IndividualId { get; set; }
        [DisplayName("Curso")]
        [Required]
        public int? CourseId { get; set; }
    }


    public class EditAssignmentCoursesViewModel
    {
        public int? Id { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public decimal? TotalHours { get; set; }

        [DisplayName("Persona")]
        public IndividualViewModel Individual { get; set; }
        public int IndividualId { get; set; }

        [DisplayName("Fecha de asignación")]
        public DateTime? AssignmentDate { get; set; }
        [DisplayName("Curso")]
        public CourseViewModel Course { get; set; }

        public int CourseId { get; set; }
    }


    public class AssignedCourseItem{

        public int? Id { get; set; }
        public DateTime? AssignmentDate { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public CourseViewModel Course { get; set; }
        public IndividualViewModel Individual { get; set; }
    }
}