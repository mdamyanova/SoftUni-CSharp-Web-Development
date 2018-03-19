function setValuesToIndexes(n, lines) {
    let nums = [];

    for (let i = 0; i < n; i++){
        nums[i] = 0;
    }

    for (let line of lines){
        line = line.split(' - ');
        nums[line[0]] = line[1];
    }

    for (let num of nums){
        if (num === undefined){
            num = 0;
        }
        console.log(num);
    }
}

setValuesToIndexes(3, ['0 - 5', '1 - 6', '2 - 7']);
console.log('---');
setValuesToIndexes(2, ['0 - 5', '0 - 6', '0 - 7']);
console.log('---');
setValuesToIndexes(5, ['0 - 3', '3 - -1', '4 - 2']);