function imperialUnits(num) {
    let feet = num % 12;
    let inches = Math.floor(num/12);
    console.log(`${inches}'-${feet}"`)
}