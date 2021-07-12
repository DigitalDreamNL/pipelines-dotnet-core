using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;

namespace Survey_Sender.Models
{
    public class QuestionRecord : TableEntity
    {
        public string Answer { get; set; }

        public string Comment { get; set; }
    }
}
