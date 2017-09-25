function tetrisFigures(gameField) {
    let figureI = [
        "o",
        "o",
        "o",
        "o",
    ];
    let figureL = [
        "o-",
        "o-",
        "oo",
    ];
    let figureJ = [
        "-o",
        "-o",
        "oo",
    ];
    let figureO = [
        "oo",
        "oo",
    ];
    let figureZ = [
        "oo-",
        "-oo",
    ];
    let figureS = [
        "-oo",
        "oo-",
    ];
    let figureT = [
        "ooo",
        "-o-",
    ];

    let result = {
        "I": countFits(gameField, figureI),
        "L": countFits(gameField, figureL),
        "J": countFits(gameField, figureJ),
        "O": countFits(gameField, figureO),
        "Z": countFits(gameField, figureZ),
        "S": countFits(gameField, figureS),
        "T": countFits(gameField, figureT),
    };

    console.log(JSON.stringify(result));

    function countFits(field, figure) {
        let figureWidth = figure[0].length;
        let figureHeight = figure.length;
        let fieldWidth = field[0].length;
        let fieldHeight = field.length;
        let fitsCount = 0;
        for (var startRow = 0; startRow <= fieldHeight - figureHeight; startRow++) {
            for (var startCol = 0; startCol <= fieldWidth - figureWidth; startCol++) {
                if (isFit(field, figure, startRow, startCol)) {
                    fitsCount++;
                }
            }
        }
        return fitsCount;
    }

    function isFit(field, figure, startRow, startCol) {
        let figureWidth = figure[0].length;
        let figureHeight = figure.length;
        for (let row = 0; row < figureHeight; row++) {
            for (let col = 0; col < figureWidth; col++) {
                if (figure[row][col] == 'o' && field[row + startRow][col + startCol] != 'o') {
                    return false;
                }
            }
        }
        return true;
    }
}