function magicMatrices(matrixRows) {
    let matrix = matrixRows.map(e => e.split(' ').map(Number));

    let magic = true;
    let sum = 0;
    let tempSum = 0;

    // check horizontally
    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            tempSum += matrix[row][col];
        }

        if (row == 0) {
            sum = tempSum;
        }

        if (sum == tempSum) {
            tempSum = 0;
        }

        else {
            magic = false;
            tempSum = 0;
            break;
        }
    }

    // check vertically
    if (magic) {
        for (let col = 0; col < matrix.length; col++) {
            for (let row = 0; row < matrix.length; row++) {
                tempSum += matrix[col][row];
            }

            if (col == 0) {
                sum = tempSum;
            }

            if (sum == tempSum) {
                tempSum = 0;
            }

            else {
                magic = false;
                tempSum = 0;
                break;
            }
        }
    }
    return magic;
}