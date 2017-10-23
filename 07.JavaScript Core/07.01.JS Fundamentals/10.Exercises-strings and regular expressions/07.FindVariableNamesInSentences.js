function variableNamesInSentences(arr) {
    let text = arr.join('');
    let regex = /_([\w]+)/g;
    let result = [];
    let match = regex.exec(text);
    while(match){
        result.push(match[1]);
        match = regex.exec(text);
    }

    return result.join(',')
}