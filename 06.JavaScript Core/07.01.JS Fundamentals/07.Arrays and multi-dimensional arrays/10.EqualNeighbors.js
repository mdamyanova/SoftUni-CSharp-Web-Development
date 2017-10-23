function equalNeighbors(matrixRows) {
    // generate matrix from given strings
    let matrix = matrixRows.map(r => r.split(' '));

    let neighbors = 0;

    // check for equal neighbors vertical
    for(let row = 0; row < matrix.length - 1; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (matrix[row][col] == matrix[row + 1][col]) {
                neighbors++;
            }
        }
    }

    // check for equal neighbors horizontal
    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (matrix[row][col] == matrix[row][col + 1]) {
                neighbors++;
            }
        }
    }
    console.log(neighbors);
}