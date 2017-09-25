function vladkosNotebook(arguments) {
    let dataRows = arguments;
    let associativeArr = {};
    for (let i = 0; i < dataRows.length; i++) {
        let currentData = dataRows[i].split('|');
        let color = currentData[0];
        if (!(color in associativeArr)) {
            associativeArr[color] = {};
            associativeArr[color]['opponents'] = [];
            associativeArr[color]['wins'] = 0;
            associativeArr[color]['losses'] = 0;
        }

        if (isInfo(currentData[1])) {
            associativeArr[color][currentData[1]] = currentData[2];
        } else {
            if (currentData[1] === 'win') {
                associativeArr[color]['wins'] += 1;
            } else {
                associativeArr[color]['losses'] +=1;
            }

            associativeArr[color]['opponents'].push(currentData[2]);
        }
    }

    //output
    let formatedResults = {};
    Object.keys(associativeArr).sort().forEach(function (key, index) {
        if (associativeArr[key]['name'] && associativeArr[key]['age']) {
            associativeArr[key]['opponents'].sort();
            let rank = calculateRank(associativeArr[key]['wins'], associativeArr[key]['losses']);
            // 2 digit after dec point
            associativeArr[key]['rank'] = rank.toFixed(2);
            delete associativeArr[key]['wins'];
            delete associativeArr[key]['losses'];
            //add at specific order;
            formatedResults[key] = {};
            Object.keys(associativeArr[key]).sort().forEach(function (innerKey, index) {
                formatedResults[key][innerKey] = associativeArr[key][innerKey];
            });
        } else {
            delete associativeArr[key];
        }
    });

    function calculateRank(wins, losses) {
        return (wins + 1)/(losses + 1);
    }
    function isInfo(element) {
        if (element === 'name' || element === 'age') {
            return true;
        }
        return false;
    }

    console.log(JSON.stringify(formatedResults));
}