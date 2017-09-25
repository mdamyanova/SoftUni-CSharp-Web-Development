function expressionSplit(input) {
    let expression = input[0];
    let elements = expression
        .split(/[\s.();,]+/);
    console.log(elements.join("\n"));
}