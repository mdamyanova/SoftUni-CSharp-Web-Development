function oddOrEven(input) {
    if(input[0] % 2 == 0){
        return "even"
    }
    else if(input[0] % 2 != Math.round(input[0] % 2)){
        return "invalid"
    }
    else {
        return "odd"
    }
}