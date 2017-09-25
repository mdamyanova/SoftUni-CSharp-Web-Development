function templateFormat(input) {
    console.log ('<?xml version="1.0" encoding="UTF-8"?>\n<quiz>');
    for(let i=0; i<input.length;i+=2){
        let question = input[i];
        let answer = input[i+1];
        printQuestion(question, answer)
    }
    console.log('</quiz>');
    function printQuestion(question, answer){
        console.log(
  `  <question>
    ${question}
  </question>
  <answer>
    ${answer}
  </answer>`);
    }
}