function capitalizeTheWords([arr]) {
    arr = arr.split(' ');
    let result = [];
    for(let word of arr){
        if (word.match(/\w+/)){
            let tempWord = '';
            tempWord += word[0].toUpperCase();
            tempWord += word.substr(1).toLowerCase();
            result.push(tempWord);
        }
    }
    return result.join(' ');
}