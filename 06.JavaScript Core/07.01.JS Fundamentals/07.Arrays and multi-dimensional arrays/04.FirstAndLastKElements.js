function kElements(arr) {
    let k = Number(arr.shift()); // take the first(K) element
    console.log(arr.slice(0, k).join(' '));
    console.log(arr.slice(arr.length-k, arr.length).join(' '));
}