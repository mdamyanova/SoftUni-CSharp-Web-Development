function parachute(map) {
    //Finding the starting position
    var startingPos = findStartingPos();
    var isFalling = true;

    while(isFalling) {
        var currRow = startingPos.row;
        var currCol = startingPos.col;

        //Uncomment to follow row and col progress
        //console.log(currRow,currCol);

        //Checks the next move
        var hasNextMove = checkNextMove(currRow, currCol);
        if(hasNextMove.status == 'flying') {
            startingPos.row = hasNextMove.newRow;
            startingPos.col = hasNextMove.newCol;
        } else {
            if(map[hasNextMove.newRow].charAt(hasNextMove.newCol) == '/' ||
                map[hasNextMove.newRow].charAt(hasNextMove.newCol) == '\\' ||
                map[hasNextMove.newRow].charAt(hasNextMove.newCol) == '|' ) {
                console.log('Got smacked on the rock like a dog!');
                console.log(hasNextMove.newRow, hasNextMove.newCol);
                break;
            } else if (map[hasNextMove.newRow].charAt(hasNextMove.newCol) == '~') {
                console.log('Drowned in the water like a cat!');
                console.log(hasNextMove.newRow, hasNextMove.newCol);
                break;
            } else {
                console.log('Landed on the ground like a boss!');
                console.log(hasNextMove.newRow, hasNextMove.newCol);
                break;
            }
        }
    }

    function findStartingPos() {
        for (var i = 0; i < map.length; i++) {
            for (var j = 0; j < map[i].length; j++) {
                if(map[i][j] == 'o') {
                    return {row: i, col: j};
                }
            }
        }
    }

    function checkNextMove(row, col) {
        var windDirection = 0;
        for (var i = 0; i < map[row+1].length; i++) {
            if(map[row+1].charAt(i) == '>') {
                windDirection += 1;
            } else if(map[row+1].charAt(i) == '<'){
                windDirection -=1;
            }
        }
        if(map[row+1].charAt(col+windDirection) == '-' ||
            map[row+1].charAt(col+windDirection) == '>' ||
            map[row+1].charAt(col+windDirection) == '<') {
            return {status: 'flying', newRow: row + 1, newCol: col + windDirection};
        }
        return {status: 'landed', newRow: row + 1, newCol: col+windDirection};
    }
}