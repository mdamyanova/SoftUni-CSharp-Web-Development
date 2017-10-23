function restaurantBill(input) {
    let product = [], sum = 0;
    for(let i in input){
        if(i%2==0){
            product.push(input[i]);
        } else {
            sum += Number(input[i]);
        }
    }
    console.log(`You purchased ${product.join(', ')} for a total sum of ${sum}`)
}