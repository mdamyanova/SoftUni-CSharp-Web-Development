function addOrRemoveElements(arr) {
    let numbers = [];
    for(let i = 0; i < arr.length; i++){
            let line = arr[i].split(' ');
            let cmd = line[0];
            let num = line[1];
            if(cmd == "add"){
                numbers.push(num);
            }
            else if(cmd == "remove" && num > - 1 && num < numbers.length){
                numbers.splice(num, 1);
            }
    }
    for(let i = 0; i < numbers.length; i++){
        console.log(numbers[i]);
    }
}