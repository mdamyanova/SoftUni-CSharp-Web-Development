function cooking([n, op1, op2, op3, op4, op5]) {
    let number = Number(n);

    number = operate(number, op1);
    console.log(number);

    number = operate(number, op2);
    console.log(number);

    number = operate(number, op3);
    console.log(number);

    number = operate(number, op4);
    console.log(number);

    number = operate(number, op5);
    console.log(number);

    function operate(number, op) {
        switch (op){
            case 'chop': return number / 2;
            case 'dice': return Math.sqrt(number);
            case 'spice': return number+1;
            case 'bake': return number*3;
            case 'fillet': return number - (number*0.2);
        }
    }
}

cooking([32, 'chop', 'chop', 'chop', 'chop', 'chop']);