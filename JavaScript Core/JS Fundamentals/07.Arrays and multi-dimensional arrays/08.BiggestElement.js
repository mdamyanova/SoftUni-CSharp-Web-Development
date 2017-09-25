function biggestElement(matrixRows) {

    // generate matrix from input's strings
    let matrix = matrixRows.map(row => row.split(' ').map(Number));
    let biggestNum = Number.NEGATIVE_INFINITY;

    // for each row's elements compare biggestNum and current element
    // and save it to biggestNum
    matrix.forEach(r => r.forEach(c => biggestNum = Math.max(biggestNum, c)));

    return biggestNum;
}