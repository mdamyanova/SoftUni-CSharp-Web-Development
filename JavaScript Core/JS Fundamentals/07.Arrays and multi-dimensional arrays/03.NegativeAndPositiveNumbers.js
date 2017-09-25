function negativePositive(arr){
    arr = arr.map(Number);
    let result = [];
    for(num of arr){
        if(num < 0){
            result.unshift(num); // insert at the start
        } else {
            result.push(num); // append at the end
        }
    }
    console.log(result.join('\n'))
}