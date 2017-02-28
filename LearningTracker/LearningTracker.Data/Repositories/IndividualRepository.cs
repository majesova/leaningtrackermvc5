using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFramework;
using LearningTracker.Data.Entities;

namespace LearningTracker.Data.Repositories
{


    public class IndividualRepository : BaseRepository<Individual>
    {
        public IndividualRepository(LearningContext context) : base(context)
        {

        }
    }


}
