function printReversed(nums){
    nums.reverse();

    for (let num of nums){
        console.log(num);
    }
}

printReversed([10, 15, 20]);
console.log('---');
printReversed([5, 5.5, 24, -3]);
console.log('---');
printReversed([20, 1, 20, 1, 20]);