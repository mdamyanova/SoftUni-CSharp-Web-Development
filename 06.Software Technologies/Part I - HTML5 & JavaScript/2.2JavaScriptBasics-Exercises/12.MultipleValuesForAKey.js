function multipleValues(arr) {
    let elements = {};
    for(let i = 0; i < arr.length; i++){
        let line = arr[i].split(' ');
        let key = line[0];
        let value = line[1];
        if(line.length == 1){
            if(key in elements){
                console.log(elements[key].join('\n'));
            }
            else{
                console.log("None");
            }
        }
        if(!(key in elements)){
            elements[key] = [];
        }
        elements[key].push(value);
    }
}