import React, {useState} from "react";

function Question(props: any) {
    const [answer, setAnswer] = useState<string>('');
    const [comment, setComment] = useState<string>('');

    const canSubmit = ((props.question.answerPossibilities && answer !== '') || (!props.question.answerPossibilities && comment !== ''));

    const saveAnswer = () => {
        setAnswer('');
        setComment('');
        props.saveAnswer(answer, comment);
    };

    return (
        <div>
            <h1 className="question-question">{props.question.questionText}</h1>
            <div className="answer-container">
                {props.question.answerPossibilities &&
                <ul className="question-answer-possibilities">
                    {props.question.answerPossibilities.map((a: string) =>
                        <li key={a} className={"question-answer-possibilities-answer" + (answer === a ? " active" : "")} onClick={() => setAnswer(a)}>{a}</li>
                    )}
                </ul>}
                <div>
                    Comments: <br />
                    <textarea className="question-comment" value={comment} onChange={(event) =>  setComment(event.target.value)}/></div>
                <div><button className="question-submit" onClick={saveAnswer} type="button" disabled={!canSubmit}>Next question</button></div>
            </div>
        </div>
    );
}

export default Question;