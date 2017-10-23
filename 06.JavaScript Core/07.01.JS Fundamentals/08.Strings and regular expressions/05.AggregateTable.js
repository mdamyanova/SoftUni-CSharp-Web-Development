function aggregateTable(input) {
    let result = [], sum = 0;
    for(let str of input){
        let tokens = str.split('|');
        result.push(tokens[1].trim());
        sum+=Number(tokens[2].trim());
    }
    console.log(result.join(', '));
    console.log(sum);
}