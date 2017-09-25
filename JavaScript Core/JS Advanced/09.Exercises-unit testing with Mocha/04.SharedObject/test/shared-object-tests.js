let expect = require('chai').expect;
let sharedObject = require('../shared-object');



describe('shared-object', function () {    

    // start name and income should equal null
    it('should return null after accessing name propery after the object is created', function () {
        sharedObject.updateName('');
        expect(sharedObject.name).to.be.null;
    });

    it('should return null after accessing income propery after the object is created', function () {
        sharedObject.updateIncome('1455GAS');
        expect(sharedObject.name).to.be.null;
    });
    
    describe('changeName function', () => {
        it('should not change the name if the new name string is an empty string', function () {
            let input = '';
            let expectedOutput = sharedObject.name;
            sharedObject.changeName(input);
            expect(sharedObject.name).to.be.equal(expectedOutput, 'Object changed the name property when the input was invalid');
        });

        it('should change the name if the new name string is not a empty string', function () {
            let input = 'Yani'; 
            let expectedOutput = input;
            sharedObject.changeName(input);
            expect(sharedObject.name).to.be.equal(expectedOutput, 'Object changed the name property when the input was invalid');
            expect($('#name').val()).to.be.equal(expectedOutput, 'Object changed the name property when the input was invalid');
        });
    });

    describe('changeIncome function', () => {
        it('should not change the income property if the input parameter is a negative number', function () {
            let input = '-1';
            let expectedOutput = sharedObject.income;
            sharedObject.changeIncome(input);
            expect(sharedObject.income).to.be.equal(expectedOutput, 'Object changed the income property when the input was invalid');
        });

        it('should not change the income property if the input parameter is a negative number', function () {
            let input = '123bas';
            let expectedOutput = sharedObject.income;
            sharedObject.changeIncome(input);
            expect(sharedObject.income).to.be.equal(expectedOutput, 'Object changed the income property when the input was invalid');
        });

        it('should change the income property when the input is valid positive number', function () {
            let input = 666;
            let expectedOutput = input;
            sharedObject.changeIncome(input);
            expect(sharedObject.income).to.be.equal(expectedOutput, 'Object changed the income property when the input was invalid');
            let textBoxValue = Number($('#income').val());
            expect(textBoxValue).to.be.equal(expectedOutput, 'Object changed the income property when the input was invalid');
        });

        it('should not change the income property when the input is 0', function () {
            let input = 0;
            let expectedOutput = sharedObject.income;
            sharedObject.changeIncome(input);
            expect(sharedObject.income).to.be.equal(expectedOutput, 'Object changed the income property when the input was 0');
        });

        it('should not change the income property when the input is string', function () {
            let input = 'test string';
            let expectedOutput = sharedObject.income;
            sharedObject.changeIncome(input);
            expect(sharedObject.income).to.be.equal(expectedOutput, 'Object changed the income property when the input was string');
        });
    });

    describe('updateName function', () => {
        it('should not change the name if the name textbox is empty', function () {
            $('#name').text('');
            let expectedOutput = sharedObject.name;
            sharedObject.updateName();
            expect(sharedObject.name).to.be.equal(expectedOutput, 'Object changed the name property when the textbox was empty');
        });

        it('should change the name property when the textbox is not empty', function () {
            $('#name').val('Yanislav');
            let expectedOutput = $('#name').val();
            sharedObject.updateName();
            expect(sharedObject.name).to.be.equal(expectedOutput, 'Object did not chang the name property when the input was valid string');
        });
    });

    describe('updateIncome function', () => {
        it('should not change the income property if the income textbox is not parsable integer number', function () {
            $('#income').val('test string');
            let expectedOutput = sharedObject.income;
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(expectedOutput, 'Object changed the income property when the textbox value was incorrect');
        });

         it('should not change the income property if the income textbox is not parsable integer number', function () {
            $('#income').val('-50');
            let expectedOutput = sharedObject.income;
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(expectedOutput, 'Object changed the income property when the textbox value was incorrect');
        });

        it('should not change the income property when the input is 0', function () {
            $('#income').val('0');
            let expectedOutput = sharedObject.income;
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(expectedOutput, 'Object changed the income property when the input was 0');
        });

        it('should not change the income property when the input is valid', function () {
            $('#income').val('50');
            let expectedOutput =  50;
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(expectedOutput, 'Object did not changed the income property when the input was correct');
        });
    });
});
