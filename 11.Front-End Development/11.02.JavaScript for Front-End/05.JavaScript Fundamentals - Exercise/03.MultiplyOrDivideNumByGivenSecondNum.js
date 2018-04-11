function multiplyOrDivide(n, x) {
    if (x >= n){
        console.log(n*x)
    } else {
        console.log(n/x);
    }
}

multiplyOrDivide(2, 3);
console.log('---');
multiplyOrDivide(13, 13);
console.log('---');
multiplyOrDivide(3, 2);
console.log('---');
multiplyOrDivide(144, 12);