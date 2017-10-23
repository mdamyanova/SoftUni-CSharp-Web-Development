function productOfNumbers(nums) {
    let num1 = Number(nums[0]);
    let num2 = Number(nums[1]);
    let num3 = Number(nums[2]);

    let counter = 0;

    if(num1 < 0){
        counter++;
    }
    if(num2 < 0){
        counter++;
    }
    if(num3 < 0){
        counter++;
    }
    if(counter % 2 == 1){
        return "Negative";
    }
    return "Positive";
}