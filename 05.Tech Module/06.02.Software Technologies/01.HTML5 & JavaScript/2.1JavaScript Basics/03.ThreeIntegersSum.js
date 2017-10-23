function numsSum(arr) {
    let nums = arr[0].split(' ').map(Number);

    console.log(
        check(nums[0], nums[1], nums[2]) ||
        check(nums[0], nums[2], nums[1]) ||
        check(nums[2], nums[1], nums[0]) ||
        "No"
    );

    function check(num1, num2, num3){
        if(num1 > num2){
            [num1, num2] = [num2, num1];
        }
        if(num1 + num2 == num3){
            return `${num1} + ${num2} = ${num3}`;
        }
    }
}