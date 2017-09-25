let expect = require('chai').expect;
let jsdom = require('jsdom-global')();
let $ = require('jquery');

function nuke (selector1, selector2) {
    if (selector1 === selector2) return;
    $(selector1).filter(selector2).remove();
}

describe('nuke', () => {
    let testObject;
    beforeEach('init the object', function () {
        document.body.innerHTML =
            `<div id="target">
                <div class="nested target">
                    <p>This is some text</p>
                </div>
                <div class="target">
                    <p>Empty div</p>
                </div>
                <div class="inside">
                    <span class="nested">Some more text</span>
                    <span class="target">Some more text</span>
                </div>
            </div>`;
    });

    it('should not delete element which do not match the selectors', () => {
        let selector = $('#target');
        let prev = selector.html();
        nuke('.nested', '.inside');
        expect(selector.html()).to.equal(prev);
    });

    it('should do nthing on invalid selectors', function () {
        let expectedOutput = $('#target').html();
        nuke(99, '#target');
        let input = $('#target').html();
        expect(input).to.equal(expectedOutput, 'Function deleted elements on invalid input');
    });
   
    it('should not delete elements if both selectors are the same', function () {
        let expectedOutput = $('.target').filter('.target').html();
        nuke('.target', '.target');
        let input = $('.target').filter('.target').html();
        expect(input).to.equal(expectedOutput, 'Function deleted elements when both selectors are the same');
    });
});