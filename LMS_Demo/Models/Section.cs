using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LMS_Demo.Models
{
    public class Section
    {
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public Nullable<int> YearID { get; set; }

        public virtual Year Year { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Assesment> Assesments { get; set; }
        public virtual ICollection<Teach> Teaches { get; set; }
    }
}
