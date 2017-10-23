function modifyAverage([num]) {
    let nums = num.split('').map(Number);

    while(calcAverage(nums) <= 5){
        nums.push(9);
    }
    return nums.join('');

    function calcAverage(arr) {
        let average = 0;

        for(let num of arr){
            average += num;
        }
        average = average/arr.length;
        return average;
    }
}