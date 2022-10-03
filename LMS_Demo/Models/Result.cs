using System;
using System.ComponentModel.DataAnnotations;

namespace LMS_Demo.Models
{
    public class Result
    {
        public int ResultID { get; set; }
        public int Mark { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<int> LecturerID { get; set; }
        public Nullable<int> AssesmentID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public virtual Assesment Assesment { get; set; }
    }
}
