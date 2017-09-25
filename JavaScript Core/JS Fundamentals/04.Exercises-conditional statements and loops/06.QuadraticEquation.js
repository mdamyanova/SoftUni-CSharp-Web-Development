function quadraticEquation([a, b, c]) {
    [a, b, c] = [a, b, c].map(Number);
    let d=(Math.pow(b,2)-(4*a*c));
    let x1=(-b + Math.sqrt(d)) / (2*a);
    let x2=(-b - Math.sqrt(d)) / (2*a);

    if (d < 0) {
        console.log("No");
    } else if (d == 0) {
        console.log(x1);
    } else {
        let smaller = Math.min(x1, x2);
        console.log(smaller);
        console.log((smaller == x1) ? x2 : x1)
    }
}