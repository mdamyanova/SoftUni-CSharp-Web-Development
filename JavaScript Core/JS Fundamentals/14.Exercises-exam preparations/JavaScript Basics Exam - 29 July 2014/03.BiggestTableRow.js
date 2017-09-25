function biggestTableRow(input) {
    let maxSum = Number.NEGATIVE_INFINITY;
    let maxSumDetails = ' ';
    for(let i = 2; i < input.length - 1; i++){
        let row = input[i];
        let cells = row.match(/<td>(.*?)<\/td>/g);
        let rowSum = 0, values = [];

        for(let c = 1; c < cells.length; c++){
            let cellValue = cells[c];
            cellValue = cellValue.substr('<td>'.length);
            cellValue = cellValue.substr(0, cellValue.length - '</td>'.length);
            let num = Number(cellValue.trim());
            if(!isNaN(num)){
                values.push(cellValue);
                rowSum += num;
            }
        }
        if(rowSum > maxSum && values.length > 0){
            maxSum = rowSum;
            maxSumDetails = values.join(' + ');
        }
    }
    if(maxSum != Number.NEGATIVE_INFINITY){
        console.log(maxSum + ' = ' + maxSumDetails)
    } else {
        console.log('no data');
    }
}