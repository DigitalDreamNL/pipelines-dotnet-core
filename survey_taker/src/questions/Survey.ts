interface Survey {
    questions: {
        id: number;
        questionText: string;
        answerPossibilities: string[];
    }[]
}

export default Survey;