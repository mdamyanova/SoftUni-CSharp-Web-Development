function gradsToDegrees(number) {
    let degree = number * 0.9 % 360;
    if(degree < 0){
        degree += 360;
    }
    return degree;
}