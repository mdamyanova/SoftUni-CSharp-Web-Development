function processOddNumbers(arr) {
    let result = arr.filter((num, i) => i % 2 == 1).map(x => 2 * x).reverse();
    return result.join(' ')
}