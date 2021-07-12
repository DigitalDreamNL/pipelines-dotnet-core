import React, {useEffect, useState} from 'react';
import Question from './questions/Question';
import SubmitAnswers from './questions/SubmitAnswers';
import SurveyResponse from './questions/SurveyResponse';
import axios from "axios";
import Survey from "./questions/Survey";

function App() {
  const [currentQuestion, setCurrentQuestion] = useState<number>(0);
  const [responses, setResponses] = useState<Array<SurveyResponse>>([]);
  const [surveyObject, setSurveyObject] = useState<Survey>({
    questions: []
  });

  useEffect(() => {
    axios.get(process.env.REACT_APP_QUESTIONS_API_URL + "/Survey")
        .then((response: any) => {
          setSurveyObject(response.data);
        });
  }, []);

  const saveAnswer = (answer: string, comment: string) => {
    let newResponse = {
      id: surveyObject.questions[currentQuestion].id,
      question: surveyObject.questions[currentQuestion].questionText,
      answer: answer,
      comment: comment,
    };
    setResponses([...responses, newResponse]);

    setCurrentQuestion(currentQuestion+1);
  }

  const submitAnswers = () => {
    let wrappedResponses = {
      questions: responses
    };
    // TODO TS: Put backend URL in a project setting
    console.log(process.env.REACT_APP_RESPONSES_API_URL);
    axios.post(process.env.REACT_APP_RESPONSES_API_URL + "/Survey", wrappedResponses)
        .then(() => {
          setResponses([]);
          setCurrentQuestion(0);
        });
  }

  return (
    <div className="App">
      {currentQuestion < surveyObject.questions.length && <Question question={surveyObject.questions[currentQuestion]} saveAnswer={saveAnswer} />}
      {currentQuestion >= surveyObject.questions.length && <SubmitAnswers responses={responses} submitAnswers={submitAnswers} />}
    </div>
  );
}

export default App;
