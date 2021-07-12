using System.Collections.Generic;

namespace Survey_Question_Provider.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public List<string> AnswerPossibilities { get; set; }
    }
}
