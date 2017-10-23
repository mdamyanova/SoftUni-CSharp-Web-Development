function aggregates(numbers) {
    numbers = numbers.map(Number);

    let sum = numbers.reduce((a, b) => a + b);
    console.log(`Sum = ${sum}`);

    let min = Math.min.apply(null, Array.from(numbers));
    console.log(`Min = ${min}`);

    let max = Math.max.apply(null, Array.from(numbers));
    console.log(`Max = ${max}`);

    let product = numbers.reduce((a, b) => a * b);
    console.log(`Product = ${product}`);

    let join = numbers.reduce((a, b) => a + '' + b);
    console.log(`Join = ${join}`);
}