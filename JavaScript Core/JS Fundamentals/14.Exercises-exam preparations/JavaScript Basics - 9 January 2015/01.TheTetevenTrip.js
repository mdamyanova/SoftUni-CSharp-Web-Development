function theTetevenTrip(input) {
    var output = "";
    for (var row = 0; row < input.length; row++) {
        var tempRow = input[row].split(' ');
        var car = tempRow[0];
        var fuel = tempRow[1];
        var trace = tempRow[2];
        var baggage = parseFloat(tempRow[3]);
        var finalConsumption = calculateFinalConsumption(trace, fuel, baggage);
        finalConsumption = Math.round(finalConsumption);

        output += car + ' ' + fuel + ' ' + trace + ' ' + finalConsumption + "\n";
    }
    console.log(output);

    function getConsumptionByFuel(fuelType) {
        var BASE_CONSUMPTION = 10;
        if(fuelType === 'petrol') {
            return 1 * BASE_CONSUMPTION;
        } else if (fuelType === 'diesel') {
            return 0.8 * BASE_CONSUMPTION;
        } else if (fuelType === 'gas') {
            return 1.2 * BASE_CONSUMPTION;
        }
    }

    function getOverFuelConsumption (baggage) {
        var overFuel = 0.01 * baggage;
        return overFuel;
    }

    function calculateFinalConsumption (trace, fuelType, baggage) {
        var averageConsumption = getConsumptionByFuel(fuelType) + getOverFuelConsumption(baggage);
        if (trace === '1') {
            var consumptionInSnow = calculateOverConsumptionInSnow(10, averageConsumption);
            var calculatedConsumption = consumptionInSnow + (averageConsumption * (110 * 0.01))
        } else {
            var consumptionInSnow = calculateOverConsumptionInSnow(30, averageConsumption);
            var calculatedConsumption = consumptionInSnow + (averageConsumption * (95 * 0.01))
        }

        return calculatedConsumption;
    }

    function calculateOverConsumptionInSnow (km, averageConsumption) {
        return (0.3 * averageConsumption) * (km * 0.01);
    }
}