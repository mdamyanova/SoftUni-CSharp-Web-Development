function keyValuePairs(arr) {
    let elements = {};
    for(let i = 0; i < arr.length; i++){
        let line = arr[i].split(' ');
        if(line.length == 1){
            if(line[0] in elements){
                console.log(elements[line[0]]);
            }
            else{
                console.log("None");
            }
        }
        elements[line[0]] = line[1];
    }
}