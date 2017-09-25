function extractText([text]) {
    let regex = /\(([^)]+)\)/g;
    let matches, result = [];
    while (matches = regex.exec(text)) {
        result.push(matches[1]);
    }
    console.log(result.join(', '))
}