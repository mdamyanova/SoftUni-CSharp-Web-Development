let lookupChar = require('../char-lookup').lookupChar;
let expect = require('chai').expect;

describe('lookupChar', function () {
    it('with a non-string first parameter, should return undefined', function () {
        expect(lookupChar(12, 4)).equal(undefined)
    });
    it('with a non-number second parameter, should return undefined', function () {
        expect(lookupChar('pesho', 'gosho')).equal(undefined)
    });
    it('with a floating point number second parameter, should return undefined', function () {
        expect(lookupChar('pesho', 3.15)).equal(undefined)
    });
    it('with an incorrect index value, should return incorrect index', function () {
        expect(lookupChar('gosho', 58)).equal('Incorrect index')
    });
    it('with a negative index value, should return incorrect index', function () {
        expect(lookupChar('gosho', -1)).equal('Incorrect index')
    });
    it('with an index value equal to string length, should return incorrect index', function () {
        expect(lookupChar('gosho', 5)).equal('Incorrect index')
    });
    it('with correct parameters, should return correct value', function () {
        expect(lookupChar('gosho', 0)).equal('g')
    });
    it('with correct parameters, should return correct value', function () {
        expect(lookupChar('gosho', 4)).equal('o')
    });
});