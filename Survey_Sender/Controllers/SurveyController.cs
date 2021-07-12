using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Survey_Sender.Models;

namespace Survey_Sender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class SurveyController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        public void StoreSurvey([FromBody] Survey request)
        {
            var recordList = new List<QuestionRecord>();
            foreach (var question in request.Questions)
            {
                recordList.Add(new QuestionRecord()
                    {
                    Answer = question.Answer,
                    Comment = question.Comment,
                    PartitionKey = question.Id.ToString(),
                    RowKey = Guid.NewGuid().ToString()
                    }
                );
            }
            TableStorageHelper.SendRecords("testtable", recordList);
        }
    }
}
