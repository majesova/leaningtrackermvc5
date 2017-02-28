using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningTracker.Data.Entities
{
    public class Course
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal? DurationAvg { get; set; }
        public string Description { get; set; }
        public ICollection<Topic> Topics { get; set; }
    }
}
