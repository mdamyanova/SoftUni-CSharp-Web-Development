function shopping(nums) {
    let peshosBudget = nums[0];
    let chocolateCount = nums[1];
    let litersMilk = nums[2];

    //35% less count of oranges than the count of chocolates
    let orangesCount = Math.floor(chocolateCount - (chocolateCount * 0.35));

    let chocolatePrice = 0.65;
    let milkPrice = 2.70;
    let orangePrice = 0.20;

    let sum = (chocolateCount * chocolatePrice) +
        (litersMilk * milkPrice) +
        (orangesCount * orangePrice);

    console.log(orangesCount);

    if (sum <= peshosBudget){
        let money = peshosBudget - sum;
        console.log(`You got this, ${money.toFixed(2)} money left.`);
    } else {
        let money = sum - peshosBudget;
        console.log(`Not enough money, you need ${money.toFixed(2)} more.`)
    }
}

shopping([10, 5, 1.5]);
shopping([3, 4, 2.7]);