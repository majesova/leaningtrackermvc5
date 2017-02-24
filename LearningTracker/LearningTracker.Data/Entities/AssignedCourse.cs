namespace LearningTracker.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AssignedCourse")]
    public partial class AssignedCourse
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime AssingmentDate { get; set; }

        public bool IsCompleted { get; set; }

        public int CustomerId { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
