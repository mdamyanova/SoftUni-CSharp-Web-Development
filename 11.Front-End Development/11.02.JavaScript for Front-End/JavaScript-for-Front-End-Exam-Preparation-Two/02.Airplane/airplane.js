function airplane(nums) {
    let departureHour = nums[0];
    let departureMinutes = nums[1];
    let flightDurationMinutes = nums[2];

    let minutes = departureMinutes + flightDurationMinutes;
    let hours = departureHour + Math.floor(minutes / 60);
    minutes %= 60;

    if (hours > 24) {
        hours -= 24;
    }

    console.log(`${hours}h ${minutes}m`);
}

airplane([6, 50, 90]);
airplane([8, 40, 120]);
airplane([23, 50, 75]);