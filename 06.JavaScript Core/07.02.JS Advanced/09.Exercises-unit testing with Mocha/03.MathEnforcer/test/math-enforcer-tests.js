let expect = require('chai').expect;
let mathEnforcer = require('../math-enforcer');

describe('math-enforcer', () => {
    describe('addFive function', () => {
        it('should return undefined when the input parameter is a string', function () {
             expect(mathEnforcer.addFive('yani')).to.be.equal(undefined, 'addFive function did not return undefined when the input is a string');
        });

        it('should return undefined when the input is an array', function () {
            expect(mathEnforcer.addFive([1, 2, 3])).to.be.equal(undefined, 'addFive function did not return undefined when the input is an array');
        });
        
        it('should return undefined when the input is an object', function () {
            expect(mathEnforcer.addFive({ x: 5 })).to.be.equal(undefined, 'addFive function did not return undefined when the input is an object');
        });

        it('should return undefined when the input is a function', function () {
            expect(mathEnforcer.addFive(() => 5)).to.be.equal(undefined, 'addFive function did not return undefined when the input is not a number');
        });

        it('should return undefined when the input is a boolean', function () {
            expect(mathEnforcer.addFive(true)).to.be.equal(undefined, 'addFive function did not return undefined when the input is a boolean');
        });

        it('should return 10 when the input is 5', function () {
            expect(mathEnforcer.addFive(5)).to.be.equal(10, 'addFive function did not return correct output when the input is 5');
        });

        
        it('should return 6.1 when the input is 1.1', function () {
            expect(mathEnforcer.addFive(1.1)).to.be.equal(1.1 + 5, 'addFive function did not return correct output when the input is 1.1');
        });
        
        it('should return 4.1 when the input is -0.9', function () {
            expect(mathEnforcer.addFive(-0.9)).to.be.equal(-0.9 + 5, 'addFive function did not return correct output when the input is -0.9');
        });        
    });

    describe('subtractTen function', () => {        
        it('should return undefined when the input is a string', function () {
            expect(mathEnforcer.subtractTen('yani')).to.be.equal(undefined, 'subtractTen function did not return undefined when the input is a string');
        });

        it('should return undefined when the input is an array', function () {
            expect(mathEnforcer.subtractTen([1, 2, 3])).to.be.equal(undefined, 'subtractTen function did not return undefined when the input is an array');
        });
        
        it('should return undefined when the input is an object', function () {
            expect(mathEnforcer.subtractTen({ x: 5 })).to.be.equal(undefined, 'subtractTen function did not return undefined when the input is an object');
        });
        
        it('should return undefined when the input is a function', function () {
            expect(mathEnforcer.subtractTen(() => 5)).to.be.equal(undefined, 'subtractTen function did not return undefined when the input is a function');
        });
        
        it('should return undefined when the input is a boolean', function () {
            expect(mathEnforcer.subtractTen(() => 5)).to.be.equal(undefined, 'subtractTen function did not return undefined when the input is a boolean');
        });

        it('should return -5 when the input is 5', function () {
            expect(mathEnforcer.subtractTen(5)).to.be.equal(5 - 10, 'subtractTen function did not return correct output when the input is 5');
        });

        it('should return -8.9 when the input is 1.1', function () {
            expect(mathEnforcer.subtractTen(1.1)).to.be.equal(1.1 - 10, 'subtractTen function did not return correct output when the input is 1.1');
        });

        it('should return -10.9 when the input is -0.9', function () {
            expect(mathEnforcer.subtractTen(-0.9)).to.be.equal(-0.9 - 10, 'subtractTen function did not return correct output when the input is -0.9');
        });
    });
    
    describe('sum function', () => {
        it('should return undefined when the first parameter of the function is a not a number', function () {
            expect(mathEnforcer.sum('5', 5)).to.be.equal(undefined, 'sum function did not return undefined when the first parameter of the function is not a number');
        });

        it('should return undefined when the second parameter of the function is a not a number', function () {
            expect(mathEnforcer.sum(5, '5')).to.be.equal(undefined, 'sum function did not return undefined when the second parameter of the function is not a number');
        });
        
        it('should return undefined if there are not passed parameters to the function', function () {
            expect(mathEnforcer.sum()).to.be.equal(undefined, 'sum function did not return undefined when the input parameters are zero');
        });
        
        it('should return 10 when the input is (5, 5)', function () {
            expect(mathEnforcer.sum(5, 5)).to.be.equal(10, 'sum function did not return correct output when the input is number');
        });

        it('should return -10 when the input is (-5, -5)', function () {
            expect(mathEnforcer.sum(-5, -5)).to.be.equal(-10, 'sum function did not return correct output when the input is number');
        });
        
        it('should return 5.2 if the input is (4.1, 1.1)', function () {
            expect(mathEnforcer.sum(4.1, 1.1)).to.be.equal(4.1 + 1.1, 'sum function did not return correct output when the input is two floating point numbers');
        });
        
        it('should return -5.2 if the input is (-4.1, -1.1)', function () {
            expect(mathEnforcer.sum(-4.1, -1.1)).to.be.equal(-4.1 + -1.1, 'sum function did not return correct output when the input is two floating point numbers');
        });
    });
});