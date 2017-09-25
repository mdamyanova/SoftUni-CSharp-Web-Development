function toTheStars(input) {
    let starOne = input[0].split(/\s+/);
    let starTwo = input[1].split(/\s+/);
    let starThree = input[2].split(/\s+/);
    let nInfo = input[3].split(/\s+/);
    let nX = parseFloat(nInfo[0]);
    let nY = parseFloat(nInfo[1]);
    let turns = parseInt(input[4]);

    let starNames = [starOne[0], starTwo[0], starThree[0]];
    let starX = [parseFloat(starOne[1]), parseFloat(starTwo[1]), parseFloat(starThree[1])];
    let starY = [parseFloat(starOne[2]), parseFloat(starTwo[2]), parseFloat(starThree[2])];

    for (let i = 0; i <= turns; i++) {
        let foundStar = false;
        for (let j = 0; j < 3; j++) {
            if (isInsideStar(nX, nY, starX[j], starY[j])) {
                console.log(starNames[j].toLowerCase());
                foundStar = true;
                break;
            }
        }
        if (!foundStar) {
            console.log("space");
        }
        nY++;
    }

    function isInsideStar(nX, nY, sX, sY) {
        return (nX <= sX + 1 && nX >= sX - 1) &&
            (nY <= sY + 1 && nY >= sY - 1);
    }
}