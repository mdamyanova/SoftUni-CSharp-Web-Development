function countWords(inputLines) {
    let text = inputLines.join('\n');
    let words = text.split(/[^A-Za-z0-9_]+/).filter(w => w != '');
    let wordsCount = {};
    for(let word of words){
        wordsCount[word] ? wordsCount[word]++ : wordsCount[word] = 1;
    }
    return JSON.stringify(wordsCount);
}