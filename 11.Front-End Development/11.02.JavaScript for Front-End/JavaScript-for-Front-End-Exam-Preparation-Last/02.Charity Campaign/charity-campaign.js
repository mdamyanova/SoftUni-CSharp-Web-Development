function charityCampaign(nums){
    let days = nums[0];
    let confectioners = nums[1];
    let cakes = nums[2];
    let waffles = nums[3];
    let pancakes = nums[4];

    let cakePrice = 45;
    let wafflePrice = 5.80;
    let pancakePrice = 3.20;

    let money = cakes * cakePrice + waffles * wafflePrice + pancakes * pancakePrice;
    let moneyPerDay = money * confectioners;
    let moneyPerCampaign = days * moneyPerDay;
    let moneyAfterExpenses = moneyPerCampaign - (moneyPerCampaign / 8);

    console.log(moneyAfterExpenses.toFixed(2));
}

charityCampaign([20, 8, 14, 30, 16]);
charityCampaign([131, 5, 9, 33, 46]);