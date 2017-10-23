function validityChecker([x1, y1, x2, y2]) {
    [x1, y1, x2, y2] = [x1, y1, x2, y2].map(Number);
    let x3 = 0, y3 = 0;

    if(checkIfItsIntegerValue(calculateDistance(x1, y1, x3, y3))){
        console.log(`{${x1}, ${y1}} to {${x3}, ${y3}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x3}, ${y3}} is invalid`)
    }
    if(checkIfItsIntegerValue(calculateDistance(x2, y2, x3, y3))){
        console.log(`{${x2}, ${y2}} to {${x3}, ${y3}} is valid`);
    } else {
        console.log(`{${x2}, ${y2}} to {${x3}, ${y3}} is invalid`)
    }
    if(checkIfItsIntegerValue(calculateDistance(x1, y1, x2, y2))){
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`)
    }

    function calculateDistance(firstX, firstY, secondX, secondY) {
        let result = Math.pow(firstX - secondX, 2) + Math.pow(firstY - secondY, 2);
        return Math.sqrt(result);
    }
    function checkIfItsIntegerValue(number) {
        if(number === parseInt(number, 10)){
            return true;
        }
        return false;
    }
}