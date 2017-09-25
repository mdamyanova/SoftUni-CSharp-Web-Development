function captureTheWords(arr) {
    let text = arr.join('');
    let regex = /\d+/g;
    let numbers = text.match(regex);
    return numbers.join(' ')
}