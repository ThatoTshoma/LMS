using System;
using System.Collections.Generic;

namespace LMS_Demo.Models
{
    public class Assesment
    {
        public int AssesmentID { get; set; }
        public string AssessmentName { get; set; }
        public Nullable<int> AssesmentTypeID { get; set; }
        public Nullable<int> ModuleID { get; set; }
        public Nullable<int> FacultyID { get; set; }
        public Nullable<int> SectionID { get; set; }
        public Nullable<int> YearID { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime DueDate { get; set; }

        public int TotalMark { get; set; }
        public string Attachment { get; set; }
        public string Description { get; set; }


        public virtual AssesmentType AssesmentType { get; set; }
        public virtual Module Module { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual Section Section { get; set; }
       // public virtual Lecturer Lecture { get; set; }
        public virtual Year Year { get; set; }

        public virtual ICollection<SubmitAssignment> SubmitAssignments { get; set; }
        public virtual ICollection<Result> Results { get; set; }

    }
}
