using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningTracker.Models
{
    public class CourseViewModel
    {
        public int? Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public decimal? DurationAvg { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public ICollection<TopicViewModel> AvailableTopics { get; set; }
        public int[] SelectedTopics { get; set; }
    }

    public class CourseDetailsViewModel {
        public int? Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public decimal? DurationAvg { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public ICollection<TopicViewModel> Topics { get; set; }
    }


    public class TopicViewModel {
        public int? Id { get; set; }
        public string Name { get; set; }
    }

    




}