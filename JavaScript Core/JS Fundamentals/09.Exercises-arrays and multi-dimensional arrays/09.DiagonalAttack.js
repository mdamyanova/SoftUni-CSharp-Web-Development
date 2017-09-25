function diagonalsAttack(matrixRows) {
    let matrix = matrixRows.map(row => row.split(' ').map(Number));

    let sumFirstDiagonal = 0;
    for (let i = 0; i < matrix.length; i++) {
        sumFirstDiagonal += matrix[i][i];
    }

    let sumSecondDiagonal = 0;
    for (let i = 0; i < matrix.length; i++) {
        sumSecondDiagonal += matrix[i][matrix.length-1-i];
    }

    if (sumFirstDiagonal == sumSecondDiagonal){
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix.length; col++) {
                if( row != col && row != matrix.length-1-col)  {
                    matrix[row][col] = sumFirstDiagonal;
                }
            }
        }
        printMatrix(matrix);
    }
    else
    {
        printMatrix(matrix);
    }

    function printMatrix(matrix) {
        for (let row = 0; row < matrix.length; row++) {
            console.log(matrix[row].join(' '))
        }
    }
}