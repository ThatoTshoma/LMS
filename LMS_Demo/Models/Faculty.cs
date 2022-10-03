using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LMS_Demo.Models
{
    public class Faculty
    {
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }

        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<Assesment> Assesments { get; set; }
        public virtual ICollection<Teach> Teaches { get; set; }

    }
}
