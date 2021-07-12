import React from "react";

function SubmitAnswers(props: any) {
    return <div>
        <h1 className="question-question">Survey complete</h1>
        <div className="answer-container">
            Thanks for answering the questions.<br/><br/>
            <div><button className="question-submit" type="button" onClick={props.submitAnswers}>Submit answers</button></div>
            <br/><br/>
            <pre className="response-json">{JSON.stringify({questions: props.responses}, null, 4)}</pre>
        </div>
    </div>
}

export default SubmitAnswers;