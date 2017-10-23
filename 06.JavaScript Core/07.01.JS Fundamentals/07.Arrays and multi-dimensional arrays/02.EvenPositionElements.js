function evenPositionElement(input) {
    let result = [];
    for (let i in input) {
        if (i % 2 == 0) {
            result.push(input[i]);
        }
    }
    return result.join(' ');
}