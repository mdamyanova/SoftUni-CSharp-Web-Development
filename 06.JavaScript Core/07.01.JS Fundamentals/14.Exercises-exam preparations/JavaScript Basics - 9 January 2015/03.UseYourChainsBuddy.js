function useYourChainsBuddy(input) {
    var htmlText = input[0];
    var myRegexp = /<p>(.+?[\n]*)<\/p>/g;
    var match = myRegexp.exec(htmlText);
    var outputArr = [];
    while (match != null) {
        //console.log(match[1])
        var spaceReplaceArr = match[1].replace(/[A-Z\W]+/g, ' ').split('');
        var decryptString = '';
        for (var letterIndex = 0; letterIndex < spaceReplaceArr.length; letterIndex ++) {
            var letter = spaceReplaceArr[letterIndex]
            var newLetter = letter;
            if(letter.charCodeAt(0) > 96 && letter.charCodeAt(0) < 110) {
                var newCharCode = letter.charCodeAt(0) + 13;
                newLetter = String.fromCharCode(newCharCode);
            } else if (letter.charCodeAt(0) > 109 && letter.charCodeAt(0) < 123) {
                var newCharCode = letter.charCodeAt(0) - 13;
                newLetter = String.fromCharCode(newCharCode);
            }
            decryptString += newLetter;
        }
        outputArr.push(decryptString);

        match = myRegexp.exec(htmlText);
    }
    console.log(outputArr.join(''))
}