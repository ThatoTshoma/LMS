using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LMS_Demo.Models
{
    public class Lecturer
    {
        [Key]
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int FacultyID { get; set; }

        public virtual Faculty Faculty { get; set; }

        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Assesment> Assesments { get; set; }
        public virtual ICollection<Teach> Teaches { get; set; }


    }
}
