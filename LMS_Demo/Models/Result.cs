using System;
using System.ComponentModel.DataAnnotations;

namespace LMS_Demo.Models
{
    public class Result
    {
        public int ResultID { get; set; }
        public int Mark { get; set; }

        [Display(Name ="Module")]
        public Nullable<int> ModuleID { get; set; }

        public virtual Module Module { get; set; }
      
    }
}
