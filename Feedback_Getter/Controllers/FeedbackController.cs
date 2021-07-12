using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Feedback_Getter.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class FeedbackController : ControllerBase
    {
        [Route("Feedback")]
        //Example request: https://localhost:5001/Feedback
        [HttpGet]
        public void GetFeedback()
        {
           Console.WriteLine("Test");
        }

        [Route("FeedbackByDate")]
        //Example request: https://localhost:5001/FeedbackByDate?start=12-12-2020%2011:11&end=12-21-2020%2011:11
        [HttpGet]
        public void GetFeedbackByDate(DateTime start, DateTime end)
        {
            Console.WriteLine("Test");
        }

    }
}
