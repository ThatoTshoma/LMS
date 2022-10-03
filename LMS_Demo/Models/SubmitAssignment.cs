using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_Demo.Models
{
    public class SubmitAssignment
    {
        [Key]
        public int SubmitID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<int> AssesmentID { get; set; }
        public string FilePath { get; set; }
        public DateTime SubmissionDate { get; set; }


        [NotMapped]
        public IFormFile File { get; set; }
        public virtual Student Student { get; set; }
        public virtual Assesment Assesment { get; set; }

    }
}
