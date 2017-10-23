let expect = require('chai').expect;
let createCalculator = require('../add-and-subtract').createCalculator;

let calculator;
beforeEach('Init a calculator instance', () => {
    calculator = createCalculator();
});

describe('add-or-subtract', function () {

    it('should return object containing add, subtract and get as properties', function () {
        let resultObject = createCalculator();
        let resultObjectKeys = Object.keys(resultObject);
        let hasGetKey = resultObjectKeys.indexOf('get') > -1;
        let hasSubtractKey = resultObjectKeys.indexOf('subtract') > - 1;
        let hasAddKey = resultObjectKeys.indexOf('add') > -1;

        expect(hasGetKey).to.be.equal(true, 'Object did not have key named get');
        expect(hasSubtractKey).to.be.equal(true, 'Object did not have key named subtract');
        expect(hasAddKey).to.be.equal(true, 'Object did not have key named subtract');
    });

    it('should return undefined if trying to increment the value of the sum from outside', function () {
        let input = createCalculator.value;
        let expectedOutput = undefined;

        expect(createCalculator.value).to.be.equal(expectedOutput, 'Object is allowing modification of the sum from outside');
    });

    it('should return not modified value if trying to increment the value of the sum from outside', function () {
        let object = createCalculator();
        object.value += 5;
        expect(object.get()).to.be.equal(0, 'Object can be modified from the outside');
    });

    it('should return 10 when add 5 and 5 to the internal sum', function () {
        let expectedOutput = 10;
        let object = createCalculator();
        object.add(5);
        object.add(5);

        expect(object.get()).to.be.equal(expectedOutput, 'Object is returning wrong output when adding numbers to the sum');
    });

    it('should return -10 when subtract -5 and -5 from the internal sum', function () {
        let expectedOutput = -10;
        let object = createCalculator();
        object.subtract(5);
        object.subtract(5);

        expect(object.get()).to.be.equal(expectedOutput, 'Object is returning wrong output when adding numbers to the sum');
    });

    it('should return NaN when the input is not number', function () {
        let object = createCalculator();
        object.subtract('test string');
        object.add('test string');

        expect(object.get()).to.be.NaN;
    });

    it('should return the vlue of the internal sum when using the get property', function () {
        let object = createCalculator();
        let expectedOutput = 0;

        expect(object.get()).to.be.equal(expectedOutput, 'Object did not return the internal sum when using get property');
    });

    it('should return 4.1 when subtracting 1.1 from 5.2', function () {
        let object = createCalculator();
        let expectedOutput = 5.3 - 1.1;
        object.add(5.3);
        object.subtract(1.1);

        expect(object.get()).to.be.equal(expectedOutput, 'Object did not return correct output when adding and subtracting decimal numbers');
    });

    it('should return NaN when no arguments are passed to the function add or subtract', function () {
        let object = createCalculator();
        object.add();
        expect(object.get()).to.be.NaN;
        object.subtract();
        expect(object.get()).to.be.NaN;
    });

    it('should return NaN when the input argument is an array', function () {
        let object = createCalculator();
        object.add([5, 5]);
        expect(object.get()).to.be.NaN;
        object.subtract([5, 5]);
        expect(object.get()).to.be.NaN;
    });

    it('should return correct value if the input is an array with length of 1', function () {
        let object = createCalculator();
        object.add([5]);

        expect(object.get()).to.be.equal(5, 'Object did not return correct value when the input is an array with length of 1');
        object.subtract([5]);
        expect(object.get()).to.be.equal(0, 'Object did not return correct value when the input is an array with length of 1');;
    });

    it('should return correct value when more than one arguments are passed to the function add or subtract', function () {
        let object = createCalculator();
        object.add(1, 2, 3, 4, 5);
        expect(object.get()).to.be.equal(1, 'Object did not return correct value when the input arguments are more than 1');

        object.subtract(1, 2, 3, 4, 5);
        expect(object.get()).to.be.equal(0, 'Object did not return correct value when the input arguments are more than 1');
    });

    it('should return correct value when adding and subtracting numbers to the internal sum', function () {
        let object = createCalculator();
        let expectedOutput = 1.1 + 2.3 - 0.9 + 3.5 + 1.1 - 50 + 0.001;
        object.add(1.1);
        object.add(2.3);
        object.subtract(0.9);
        object.add(3.5);
        object.add(1.1);
        object.subtract(50);
        object.add(0.001);
        expect(object.get()).to.be.equal(expectedOutput, 'Object did not return correct value when adding and subtracting numbers to the internal sum');
    });


    it('should return correct value when passing arguments to the get function', function () {
        let object = createCalculator();
        expect(object.get(1, 2, '123', { x: 5 })).to.be.equal(0, 'Object did not return correct value when passing arguments to the get function');
    });

    it('should return Nan when passing objects to the add and subtract functions', function () {
        let object = createCalculator();
        object.add({ x: 0 });
        expect(object.get()).to.be.NaN;

        object.subtract({ x: 0 });
        expect(object.get()).to.be.NaN;
    });

    it('should return 100 when adding 50 50', function () {
        let object = createCalculator();
        object.add(50);
        object.add(50);
        expect(object.get()).to.be.equal(100, 'Object did not return correct value when adding numbers to the internal sum');
    });

    it('should return -100 when adding 50 50', function () {
        let object = createCalculator();
        object.subtract(50);
        object.subtract(50);
        expect(object.get()).to.be.equal(-100, 'Object did not return correct value when subtracting numbers from the internal sum');
    });

    it('should return 20 when subtracting negative numbers from the internal sum -5, -5, -5, -5', function () {
        let object = createCalculator();
        object.subtract(-5);
        object.subtract(-5);
        object.subtract(-5);
        object.subtract(-5);
        expect(object.get()).to.be.equal(20, 'Object did not return correct value when subtracting negative numbers from the internal sum');
    });

    it('should return -20 when adding negative numbers to the internal sum -5, -5, -5, -5', function () {
        let object = createCalculator();
        object.add(-5);
        object.add(-5);
        object.add(-5);
        object.add(-5);
        expect(object.get()).to.be.equal(-20, 'Object did not return correct value when adding negative numbers to the internal sum');
    });

    it('should return 2 when adding and subtracting numbers (add 10, subtract 7, add -2, subtract -1, get = 2) to the internal sum', function () {
        let object = createCalculator();
        object.add(10);
        object.subtract(7);
        object.add(-2);
        object.subtract(-1);
        expect(object.get()).to.be.equal(2, 'Object did not return correct value when adding negative numbers to the internal sum');
    });

    it('should return Nan when passing string to the add function', function () {
        let object = createCalculator();
        object.add('test string');
        expect(object.get()).to.be.NaN;
    });

    it('should return Nan when passing string to the subtract function', function () {
        let object = createCalculator();
        object.add('test string');
        expect(object.get()).to.be.NaN;
    });
});