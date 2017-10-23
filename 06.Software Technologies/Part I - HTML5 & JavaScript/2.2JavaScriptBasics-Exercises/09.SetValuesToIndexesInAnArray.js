function setValuesToIndexes(arr) {
    let n = Number(arr[0]);
    let numbers = [];

    for(let i = 0; i < n; i++){
        numbers[i] = '0';
    }
    for(let i = 1; i <= arr.length - 1; i++){
        let line = arr[i].split(' - ');
        numbers[line[0]] = line[1];
    }
    for(let num of numbers){
        console.log(num);
    }
}