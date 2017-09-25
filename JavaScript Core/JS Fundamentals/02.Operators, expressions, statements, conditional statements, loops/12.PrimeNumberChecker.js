function isPrime(num) {
    let prime = true;
    for (let d = 2; d <=
    Math.sqrt(num); d++) {
        if (num % d == 0) {
            prime = false;
            break;
        }
    }
    return prime && (num > 1);
}