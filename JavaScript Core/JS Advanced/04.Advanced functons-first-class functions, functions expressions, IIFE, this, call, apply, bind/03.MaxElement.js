function maxElement(inputArray) {

    let inputNumber = (function (){
        return {
            maxNumber: (numbers) => Math.max.apply(null, numbers)
        };
    })();

    return inputNumber.maxNumber(inputArray);
}