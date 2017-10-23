function extractUniqueWords(text) {
    let words = new Set;
    for (let sentence of text) {
        let foundWords = sentence.toLowerCase().match(/[a-zA-Z0-9_]+/g);
        for (let word of foundWords) {
            words.add(word);
        }
    }

    return [...words.values()].join(', ');
}