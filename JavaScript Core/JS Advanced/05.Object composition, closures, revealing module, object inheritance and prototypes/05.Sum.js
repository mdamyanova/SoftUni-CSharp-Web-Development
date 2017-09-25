function sum() {
    let domObject = {
        num1: '',
        num2: '',
        result: '',
        init: (selector1, selector2, resultSelector) => {
            domObject.num1 = $(selector1);
            domObject.num2 = $(selector2);
            domObject.result = $(resultSelector);
        },
        add: () => {
            let firstNum = Number(domObject.num1.val());
            let secondNum = Number(domObject.num2.val());
            let resultValue = firstNum + secondNum;
            domObject.result.val(resultValue);
        },
        subtract: () => {
            let firstNum = Number(domObject.num1.val());
            let secondNum = Number(domObject.num2.val());
            let resultValue = firstNum - secondNum;
            domObject.result.val(resultValue);
        }
    };

    return domObject;
}