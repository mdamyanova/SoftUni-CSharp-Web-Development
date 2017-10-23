function matrixRotation(input) {
    let command = input[0];
    let degrees = command.replace(/[^0-9]/g, '') % 360;

    let matrix = [];
    let len = 0;
    for(let i = 1; i < input.length; i++){
        let line = input[i];
        matrix.push(line.split(''));
        if(line.length > len){
            len = line.length;
        }
    }

    for(let i = 0; i < matrix.length; i++){
        while(matrix[i].length < len){
            matrix[i].push(' ');
        }
    }

    while (degrees > 0){
        matrix = rotate90degrees(matrix);
        degrees -= 90;
    }

    for(let i in matrix){
        console.log(matrix[i].join(''))
    }

    function rotate90degrees(matrix) {
        let maxRow = matrix.length - 1;
        let maxCol = matrix[0].length - 1;
        let result = new Array(maxCol);
        for(let col = 0; col <= maxCol; col++){
            result[col] = new Array(maxRow);
            for(let row = 0; row <= maxRow; row++){
                result[col][maxRow - row] = matrix[row][col];
            }
        }
        return result;
    }
}