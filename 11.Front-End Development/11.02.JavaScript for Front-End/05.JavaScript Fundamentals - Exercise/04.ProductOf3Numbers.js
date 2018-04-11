function productOf3Numbers(x, y, z) {
    let counter = 0;

    if(x < 0){
        counter++;
    }
    if(y < 0){
        counter++;
    }
    if(z < 0){
        counter++;
    }
    if(counter % 2 == 1){
        console.log('Negative')
    } else {
        console.log('Positive');
    }
}

productOf3Numbers(2, 3, -1);
console.log('---');
productOf3Numbers(5, 4, 3);
console.log('---');
productOf3Numbers(-3, -4, 5);