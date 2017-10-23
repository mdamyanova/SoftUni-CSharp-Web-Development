function compoundInterest([principal, interest, period, time]){
    [principal, interest, period, time] = [principal, interest, period, time].map(Number);
    interest /= 100;
    let frequency = 12 / period;
    let total = principal * Math.pow(1 + interest / frequency, frequency * time);
    console.log(total.toFixed(2))
}