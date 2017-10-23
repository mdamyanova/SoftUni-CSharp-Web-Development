function concatenateReversed(input) {
    let result = '';
    for(let i=input.length-1; i>=0; i--){
        result += input[i].split('').reverse().join('');
    }
    return result;
}