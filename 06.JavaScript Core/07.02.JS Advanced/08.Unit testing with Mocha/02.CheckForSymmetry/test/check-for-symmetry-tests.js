let expect = require("chai").expect;
let isSymmetric = require('../check-for-symmetry').isSymmetric;

describe('isSymmetric(arr) - checks if given array is symmetric', function () {
    it('should return true for symmetric array', function () {
        expect(isSymmetric([1,2,3,2,1])).equal(true);
    });
    it('should return false for non-symmetric array', function () {
        expect(isSymmetric(['g', 'o', '6', 'o'])).equal(false);
    });
    it('should return false for non-array', function () {
        expect(isSymmetric(1)).equal(false);
    });
    it('should return true for one element', function () {
        expect(isSymmetric([1])).equal(true);
    });
    it('should return true for symmetric array with different types', function () {
        expect(isSymmetric([5, 'hi', {a:5}, 'hi', 5])).equal(true);
    });
    it('should return false for [1, 2, 3, 4, 2, 1]', function () {
        expect(isSymmetric([1, 2, 3, 4, 2 ,1])).equal(false);
    });
    it('should return true for [-1, 2, -1]', function () {
        expect(isSymmetric([-1, 2, -1])).equal(true);
    });
    it('should return false for [-1, 2, 1]', function () {
        expect(isSymmetric([-1, 2, 1])).equal(false);
    });
});