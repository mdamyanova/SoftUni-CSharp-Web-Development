function theNumbers(input) {
    let text = input[0];
    let numbers = text.split(/\D+/g).filter(Boolean);
    for (let i = 0; i < numbers.length; i++) {
        let num = parseInt(numbers[i]);
        let hex = num.toString(16);
        let leadingZeros = 4 - hex.length;
        let upperHex = new Array(leadingZeros + 1).join('0') + hex;
        numbers[i] = '0x' + upperHex.toUpperCase();
    }
    console.log(numbers.join('-'));
}