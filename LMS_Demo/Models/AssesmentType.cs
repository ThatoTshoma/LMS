using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LMS_Demo.Models
{
    public class AssesmentType
    {
        [Key]
        public int TypeID { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Assesment> Assesments { get; set; }
    }
}
