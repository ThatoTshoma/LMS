using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LMS_Demo.Models
{
    public class Module
    {
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public string ModuleCode { get; set; }
        public Nullable<int> FacultyID { get; set; }
        public Nullable<int> YearID { get; set; }



        public virtual Faculty Faculty { get; set; }
        public virtual Year Year { get; set; }


        public virtual ICollection<Assesment> Assesments { get; set; }



    }
}
