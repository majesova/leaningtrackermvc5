using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningTracker.Models
{
    public class IndividualViewModel
    {   
        public int? Id { get; set; }
        [Required]
        [MaxLength(200)]
        [MinLength(1)]
        [Display(Name="Nombre")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        [Remote("CheckEmail", "Individual", HttpMethod ="GET", ErrorMessage ="Este Email ya está ocupado (Remote)")]
        public string Email { get; set; }
    }
}