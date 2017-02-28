using LearningTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningTracker.Data.Repositories
{
    public class AssignedCourseRepository : BaseRepository<AssignedCourse>
    {
        public AssignedCourseRepository(LearningContext context):base(context)
        {

        }

    }
}
