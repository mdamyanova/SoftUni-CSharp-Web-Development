function rotateArray(arr) {
    let steps = arr.pop();
    if(steps > arr.length){
        steps = steps % arr.length;
    }

    while (steps > 0) {
        // the last element become the first
        arr.unshift(arr.pop());
        steps--;
    }
    return arr.join(' ');
}