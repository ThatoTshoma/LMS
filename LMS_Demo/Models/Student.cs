using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_Demo.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<int> FacultyID { get; set; }
       // public Nullable<int> YearID { get; set; }



        public virtual Faculty Faculty { get; set; }
        //public virtual Section Section { get; set; }
        //public virtual Year Year { get; set; }


        public virtual ICollection<SubmitAssignment> SubmitAssignments { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<Lecturer> Lecturers { get; set; }


    }
}
