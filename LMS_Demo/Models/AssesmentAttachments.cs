using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_Demo.Models
{
    public class AssesmentAttachments
    {
        [Key]
        public int AttachID { get; set; }
        public string AttachName { get; set; }
        public Nullable<int> TypeID { get; set; }
        public Nullable<System.DateTime> OpenDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<int> SectionID { get; set; }
        public Nullable<int> FacultyID { get; set; }
        public Nullable<int> ModuleID { get; set; }
        public Nullable<int> YearID { get; set; }
        public Nullable<int> LectureID { get; set; }
        public string Description { get; set; }
        public string TotalMark { get; set; }
        public string Attachment { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
        public virtual AssesmentType AssesmentType { get; set; }
        public virtual Module Module { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual Section Section { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public virtual Year Year { get; set; }
    }
}
