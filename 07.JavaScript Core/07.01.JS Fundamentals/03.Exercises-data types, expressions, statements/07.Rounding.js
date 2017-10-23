function rounding([number, precision]) {
    [number, precision] = [number, precision].map(Number);
    let denominator = Math.pow(10, precision);
    let num = Math.round(number * denominator) / denominator;
    console.log(num)
}