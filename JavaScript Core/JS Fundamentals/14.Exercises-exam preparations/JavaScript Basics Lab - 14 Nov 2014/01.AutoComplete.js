function autoComplete(args) {
    var words = args[0].split(" ");
    for (var i = 1; i < args.length; i++) {
        var keyword = args[i],
            possibleWords = [];

        for (var j = 0; j < words.length; j++) {
            var currentWord = words[j];
            if (currentWord.toLowerCase()
                    .indexOf(keyword.toLowerCase()) === 0) {
                possibleWords.push(currentWord);
            }
        }

        if (possibleWords.length > 0) {
            var bestWord = possibleWords.sort(function(s1, s2) {
                if (s1.length === s2.length) {
                    return s1.localeCompare(s2);
                }
                return s1.length - s2.length;
            })[0];
            console.log(bestWord);
        } else {
            console.log("-");
        }
    }
}