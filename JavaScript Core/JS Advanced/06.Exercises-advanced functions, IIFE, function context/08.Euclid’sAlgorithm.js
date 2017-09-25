let result = (function solve () {
    function getGreatestCommonDivisor (number1, number2) {
        if (number2 === 0) {
            return number1;
        } else {
            return getGreatestCommonDivisor(number2, number1 % number2);
        }
    }

    return getGreatestCommonDivisor;
})();