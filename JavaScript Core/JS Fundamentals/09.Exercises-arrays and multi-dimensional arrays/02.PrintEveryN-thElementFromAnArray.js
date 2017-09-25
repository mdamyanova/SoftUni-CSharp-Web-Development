function printNthElements(arr) {
    let step = Number(arr[arr.length-1]);
    arr = arr.slice(0, arr.length-1);
    for(let i = 0; i < arr.length; i+=step){
        console.log(arr[i]);
    }
}