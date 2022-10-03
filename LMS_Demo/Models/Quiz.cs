using System.ComponentModel.DataAnnotations;

namespace LMS_Demo.Models
{
    public class Quiz
    {
        [Key]
        public int Qid { get; set; }
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
