function renderElements() {

    // div header-ctr
    $('<h1>')
        .text('Basic calculated fields sample.')
        .appendTo('#header-ctr');
    $('<hr>')
        .appendTo('#header-ctr');

    // form

    // first label
    let spanOne = $('<span>')
        .text('Distance (mi) *');
    let inputOne = $('<input>')
        .attr('type', 'text')
        .attr('placeholder', 'Enter Distance')
        .prop('required', true);

    $('<label>')
        .addClass('one')
        .append(spanOne, inputOne)
        .appendTo('form');

    // second label
    let spanTwo = $('<span>')
        .text('Weight (lb)');
    let inputTwo = $('<input>')
        .attr('type', 'text')
        .attr('placeholder', 'Enter Weight')
        .prop('required', true);
    let spanTwoSecond = $('<span>')
        .addClass('fragile')
        .text('Fragile');
    let selectTwo = $('<select>')
        .append(
            $('<option>', {
                value: 'Value 0',
                text: 'Select Something',
                disabled: true,
                selected: true
            }),
            $('<option>', {
                value: 'Value 1',
                text: 'No',
            }),
            $('<option>', {
                value: 'Value 2',
                text: 'Yes',
            })
        );

    $('<label>')
        .addClass('two')
        .append(spanTwo, inputTwo, spanTwoSecond, selectTwo)
        .appendTo('form');

    // third label
    let spanThree = $('<span>')
        .text('Length (in)');
    let spanThreeSecond = $('<span>')
        .addClass('height')
        .text('height (in)');
    let spanThreeThird = $('<span>')
        .addClass('width')
        .text('width (in)');
    let inputThree = $('<input>')
        .attr('type', 'number')
        .attr('placeholder', 'Length');
    let inputThreeSecond = $('<input>')
        .attr('type', 'number')
        .attr('placeholder', 'Height');
    let inputThreeThird = $('<input>')
        .attr('type', 'number')
        .attr('placeholder', '10')
        .attr('min', '1')
        .attr('max', '1000');

    $('<label>')
        .addClass('three')
        .append(spanThree, spanThreeSecond, spanThreeThird,
            inputThree, inputThreeSecond, inputThreeThird)
        .appendTo('form');

    // fourth label
    let headerFour = $('<h3>')
        .text('Extra services:');
    let paragraphFour = $('<p>')
        .append((
            $('<input>', {
                type: 'checkbox',
                text: 'Insurance',
            }))
        );
    let paragraphFourSecond = $('<p>')
        .append((
            $('<input>', {
                type: 'checkbox',
                text: 'Express Delivery',
            }))
        );

    $('<label>')
        .addClass('four')
        .append(headerFour, paragraphFour, paragraphFourSecond)
        .appendTo('form');

    // price label
    let spanPrice = $('<span>')
        .text('total:');
    let paragraphPrice = $('<p>')
        .addClass('total-price')
        .text('$ 00.00');

    $('<label>')
        .addClass('price')
        .append(spanPrice, paragraphPrice)
        .appendTo('form');

    // submit
    $('<p>')
        .addClass('submit')
        .text('Im Ready')
        .appendTo('form');

    // after success
    let headerAfterSuccess = $('<h1>')
        .text('Good Job!');
    let imageAfterSuccess = $('<img src="register_success.png">')
        .attr('alt', 'success');

    $('.after-success')
        .append(headerAfterSuccess, imageAfterSuccess);
}

function onClick(){

    $('.submit').on('click', function () {
        $('#header-ctr').toggle();
        $('form').toggle();
        $('.after-success').removeClass('hidden');
    });
}

renderElements();
onClick();