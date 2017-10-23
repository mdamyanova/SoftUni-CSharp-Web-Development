function lastKNumbers([n, k]) {
    [n, k] = [n, k].map(Number);
    let nums = [];
    nums[0] = 1;

    for(let i = 1; i < n; i++){
        let sum = 0;

        // get all previous elements
        for(let prev = i-k; prev <= i-1; prev++){
            if(prev>=0){
                sum+=nums[prev]; // add current value to the sum
            }
        }
        nums[i] = sum;
    }

    console.log(nums.join(' '))
}