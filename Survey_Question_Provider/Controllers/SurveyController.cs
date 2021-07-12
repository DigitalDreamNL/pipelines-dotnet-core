using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Survey_Question_Provider.Models;
using System.Collections.Generic;

namespace Survey_Question_Provider.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveyController : ControllerBase
    {
        private readonly ILogger<SurveyController> _logger;

        public SurveyController(ILogger<SurveyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Survey Get()
        {
            var survey = new Survey
            {
                Questions = new List<Question>
            {
                new Question
                {
                    Id = 0,
                    QuestionText = "Pick an answer",
                    AnswerPossibilities = new List<string>
                {
                    "First", "Second", "Third"
                }
                },
                new Question
                {
                    Id = 1,
                    QuestionText = "Pick another answer",
                    AnswerPossibilities = new List<string>
                {
                    "First", "Second", "Third"
                }
                },
                new Question
                {
                    Id = 2,
                    QuestionText = "No multiple choice",
                }
            }
            };
            return survey;
        }
    }
}
