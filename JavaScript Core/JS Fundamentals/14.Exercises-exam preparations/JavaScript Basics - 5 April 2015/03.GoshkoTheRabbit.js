function goshkoTheRabbit(input) {
    var garden = [],
        directions = input[0].split(', ').filter(function(x) {return x;}),
        moves = [],
        rowPos = 0,
        colPos = 0,
        gosho = {
            '&': 0,
            '*': 0,
            '#': 0,
            '!': 0,
            'wall hits': 0
        };
    for (var i = 1; i < input.length; i++) {
        garden.push(input[i].split(', ').filter(function(x) {return x;}));
    }

    directions.forEach(moveToDirection);

    console.log(JSON.stringify(gosho));
    console.log(moves.length > 0 ? moves.join('|') : 'no');

    function moveToDirection(direction) {
        if(direction == 'right') {
            if(colPos + 1 < garden[rowPos].length) {
                ++colPos;
                checkVegetable();
            }
            else {
                gosho['wall hits']++;
            }
        } else if(direction == 'left') {
            if(colPos - 1 >= 0) {
                --colPos;
                checkVegetable();
            }
            else {
                gosho['wall hits']++;
            }
        } else if(direction == 'up') {
            if(rowPos - 1 >= 0) {
                --rowPos;
                checkVegetable();
            }
            else {
                gosho['wall hits']++;
            }
        } else if(direction == 'down') {
            if(rowPos + 1 < garden.length) {
                ++rowPos;
                checkVegetable();
            }
            else {
                gosho['wall hits']++;
            }
        }
    }

    function checkVegetable() {
        garden[rowPos][colPos] = garden[rowPos][colPos].replace(/\{([&*!#])\}/g, function(match, group) {
            gosho[group] += 1;
            return '@';
        });
        moves.push(garden[rowPos][colPos]);
    }
}