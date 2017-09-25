let expect = require("chai").expect;
let sum = require('../sum-numbers').sum;

describe('sum(arr) - sum array of numbers', function () {
    it('should return 3 for [1, 2]', function () {
        let expectedSum = 3;
        let actualSum = sum([1, 2]);
        expect(actualSum).to.be.equal(expectedSum);
    });

    it('should return 1 for [1]', function () {
        expect(sum([1])).equal(1);
    });

    it('should return 0 for empty array', function () {
        expect(sum([])).equal(0);
    });
});