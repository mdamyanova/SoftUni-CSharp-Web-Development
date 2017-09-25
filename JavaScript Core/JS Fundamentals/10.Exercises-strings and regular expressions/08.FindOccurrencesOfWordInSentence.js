function occurrencesOfWordInSentences([text, r]){
    let regex = new RegExp(`\\b${r}\\b`, 'gi');
    let result = text.match(regex) || [];
    return result.length;
}