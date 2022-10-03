using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LMS_Demo.Models
{
    public class Year
    {
        public int YearID { get; set; }
        public string YearName { get; set; }


        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<Assesment> Assesments { get; set; }
        public virtual ICollection<Teach> Teaches { get; set; }


    }
}
