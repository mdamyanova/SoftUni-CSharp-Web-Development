let isOddOrEven = require('../even-or-not').isOddOrEven;
let expect = require('chai').expect;

describe('lookupChar', function () {
   it('with a number parameter, should return undefined', function () {
      expect(isOddOrEven(4)).equal(undefined)
   });
    it('with an object parameter, should return undefined', function () {
        expect(isOddOrEven({ name: 'gosho' })).equal(undefined)
    });
    it('with an even length string, should return correct result', function () {
       expect(isOddOrEven('roar')).equal('even')
    });
    it('with an odd length string, should return correct result', function () {
        expect(isOddOrEven('pesho')).equal('odd')
    });
    it('with multiple consecutive checks, should return correct result', function () {
        expect(isOddOrEven('cat')).equal('odd');
        expect(isOddOrEven('alabala')).equal('odd');
        expect(isOddOrEven('is it even')).equal('even');
    });
});