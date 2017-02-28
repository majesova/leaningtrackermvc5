using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningTracker.Data.Entities
{
    public class Individual
    {
        public int? Id { get; set; }   
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
