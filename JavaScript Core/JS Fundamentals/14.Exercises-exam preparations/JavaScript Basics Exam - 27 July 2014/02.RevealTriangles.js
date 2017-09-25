function revealTriangles(input) {
    let result = [];
    for (let row = 0; row < input.length; row++) {
        result[row] = input[row].split('');
    }

    for (let row = 1; row < input.length; row++) {
        let maxCol = Math.min(
            input[row - 1].length - 2,
            input[row].length - 3);
        for (let col = 0; col <= maxCol; col++) {
            let a = input[row][col];
            let b = input[row][col + 1];
            let c = input[row][col + 2];
            let d = input[row - 1][col + 1];
            if (a == b && b == c && c == d) {
                result[row][col] = '*';
                result[row][col + 1] = '*';
                result[row][col + 2] = '*';
                result[row - 1][col + 2] = '*';
            }
        }
    }
    for (let row = 0; row < input.length; row++) {
        console.log(result[row].join(''))
    }
}