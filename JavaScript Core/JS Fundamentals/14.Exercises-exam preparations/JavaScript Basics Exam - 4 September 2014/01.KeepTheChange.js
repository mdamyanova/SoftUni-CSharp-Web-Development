function keepTheChange(input) {
    let bill = parseFloat(input[0]);
    let mood = input[1];

    let tip = getTip(bill, mood);
    console.log(tip.toFixed(2));

    function getTip(bill, mood) {
        let tipPercent;
        switch (mood) {
            case 'drunk':
                let tip = 0.15 * bill;
                return Math.pow(tip, Number(tip.toString().charAt(0)));
            case 'happy':
                tipPercent = 0.1;
                break;
            case 'married':
                tipPercent = 0.0005;
                break;
            default:
                tipPercent = 0.05;
                break;
        }
        return tipPercent * bill;
    }
}