using System;
using System.ComponentModel.DataAnnotations;

namespace LMS_Demo.Models
{
    public class Teach
    {
        public int TeachID { get; set; }
        public Nullable<int> LecturerID { get; set; }
        public Nullable<int> ModuleID { get; set; }
        public Nullable<int> FacultyID { get; set; }
        public Nullable<int> YearID { get; set; }


        public virtual Module Module { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual Year Year { get; set; }
        public virtual Lecturer Lecturer { get; set; }
    }
}
