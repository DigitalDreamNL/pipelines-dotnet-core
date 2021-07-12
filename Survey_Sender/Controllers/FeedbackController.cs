using Microsoft.AspNetCore.Mvc;
using Survey_Sender.Models;
using System;
using System.Collections.Generic;

namespace Survey_Sender.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class FeedbackController : ControllerBase
    {
        [Route("Feedback")]
        //Example request: https://localhost:5001/Feedback
        [HttpGet]
        public List<QuestionRecord> GetFeedback()
        {
            return TableStorageHelper.GetRecords("testtable");
        }

        [Route("FeedbackByDate")]
        //Example request: https://localhost:5001/FeedbackByDate?start=12-12-2020%2011:11&end=12-21-2020%2011:11
        [HttpGet]
        public List<QuestionRecord> GetFeedbackByDate(DateTime start, DateTime end)
        {
          return TableStorageHelper.GetRecords("testtable", start, end);
        }

    }
}
