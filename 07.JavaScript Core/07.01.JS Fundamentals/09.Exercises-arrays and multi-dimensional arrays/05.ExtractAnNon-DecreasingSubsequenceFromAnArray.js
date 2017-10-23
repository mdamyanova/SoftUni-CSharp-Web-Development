function nonDecreasingSubsequence(arr) {
    arr = arr.map(Number);
    let result = [];
    let biggestNumber = arr[0];
    for(let i=0; i<arr.length; i++){
        if(arr[i] >= biggestNumber){
            result.push(arr[i]);
            biggestNumber = arr[i];
        }
    }
    return result.join('\n');
}