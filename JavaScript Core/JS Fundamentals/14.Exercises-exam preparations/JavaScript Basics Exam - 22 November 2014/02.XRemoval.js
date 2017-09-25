function xRemove(arr) {
    let matrix = [];
    let resultMatrix = [];

    arr.forEach(function(string) {
        matrix.push(string.toLowerCase().split(''));
        resultMatrix.push(string.split(''));
    });

    for (let row = 0; row < matrix.length - 2; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            let char = matrix[row][col];
            let isX = matrix[row][col + 2] == char &&
                matrix[row + 1][col + 1] == char &&
                matrix[row + 2][col] == char &&
                matrix[row + 2][col + 2] == char;

            if (isX) {
                resultMatrix[row][col] = " ";
                resultMatrix[row][col + 2] = " ";
                resultMatrix[row + 1][col + 1] = " ";
                resultMatrix[row + 2][col] = " ";
                resultMatrix[row + 2][col + 2] = " ";
            }
        }
    }
    let resultArray = [];
    resultMatrix.forEach(function(str) {
        resultArray.push(str.join('').split(" ").join(''));
    });

    resultArray.forEach(function(item) {
        console.log(item);
    });
}