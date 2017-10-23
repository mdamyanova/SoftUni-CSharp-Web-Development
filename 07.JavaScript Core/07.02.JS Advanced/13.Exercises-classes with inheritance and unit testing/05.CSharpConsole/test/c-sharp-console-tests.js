let expect = require('chai').expect;
let Console = require('../c-sharp-console').Console;

describe('c-sharp-console', () => {
    it('should not change the input parameter and return string if the input parameter is only one and it is a string', function () {
        expect(Console.writeLine('{0}')).to.equal('{0}', 'function did not return correct output');
    });

    it('should return stringified object if the input parameter is only one and it is an object', function () {
        let input = { x: 5, y: 7, cat: 'Pesho' };
        let expectedOutput = JSON.stringify(input);
        expect(Console.writeLine(input)).to.equal(expectedOutput, 'function did not return correct output');
    });

    it('should throw type error if multiple arguments are passed, but the first one is not a string', function () {
        expect(() => Console.writeLine(5, 'meow', 'baw', [5, 10], '123')).to.throw(TypeError);
    });

    it('should return range error If the number of arguments does not correspond to the number of placeholders', function () {
        expect(() => Console.writeLine('One {0} {1} {2}', 'cat', 'dog')).to.throw(RangeError);
    });

    it('should return range error If the number of placeholders does not correspond to the number of the input arguments', function () {
        expect(() => Console.writeLine('Dog and  {12}', 'Cat')).to.throw(RangeError);
    });

    it('should replace all placeholders with corresponding values if the arguments correspond to the placeholders number', function () {
        expect(Console.writeLine('{0} and {1}.{2} and {3}!', 'dog', 'cat', 'PC', 'TV')).to.equal('dog and cat.PC and TV!', 'Function did not return correct output');
    });
});