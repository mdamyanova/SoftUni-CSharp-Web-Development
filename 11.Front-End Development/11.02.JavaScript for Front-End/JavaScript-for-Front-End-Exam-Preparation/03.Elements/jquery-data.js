function renderAllElementsInHTML() {
    let heading = $('<h1>');
    heading
        .text("Choose Your Destiny")
        .prependTo('#elementsContainer');

    let firstDivContainer = $('<div class="containers">');
    firstDivContainer
        .appendTo('.container');

    let secondDivContainer = $('<div class="containers">');
    secondDivContainer
        .appendTo('.container');

    let airDiv = $('<div id="air" class="first clickable">')
        .appendTo(firstDivContainer);
    // or airDiv.attr('id', 'air').addClass('first clickable');
    let fireDiv = $('<div id="fire" class="second clickable">')
        .appendTo(firstDivContainer);
    let waterDiv = $('<div id="water" class="third clickable">')
        .appendTo(secondDivContainer);
    let earth = $('<div id="earth" class="fourth clickable">')
        .appendTo(secondDivContainer);
}

function renderSingleElementInHTML() {
    $('#elementInfo').addClass('no-display');

    let backButton = $('<button id="backToElements">');
    backButton
        .text("Back to Elements")
        .appendTo('.back-button');

    let listItem = $('<li>')
        .appendTo('.creatures');

    let firstRadioButton = $('<input>');
    firstRadioButton
        .addClass('radio-button checked')
        .attr('name', 'selector')
        .attr('type', 'radio')
        .attr('value', 'Archangel')
        .appendTo(listItem);

    let firstRadioLabel = $('<label>')
        .text('Archangel')
        .appendTo(listItem);

    let secondRadioButton = $('<input>');
    firstRadioButton
        .addClass('radio-button checked')
        .attr('name', 'selector')
        .attr('type', 'radio')
        .attr('value', 'Elemental')
        .appendTo(listItem);

    let secondRadioLabel = $('<label>')
        .text('Elemental')
        .appendTo(listItem);

    let image = $('<img src="images/archangel.jpg">')
        .attr('id', 'creature-image')
        .attr('alt', 'Archangel')
        .appendTo('.center-after-click');

    let creatureName = $('<p>')
        .attr('id', 'creature-name')
        .text('Archangel')
        .appendTo('#right-after-click');

    let creaturePower = $('<p>')
        .attr('id', 'creature-power')
        .text('Power:2000')
        .appendTo('#right-after-click');

    let creatureUltimate = $('<p>')
        .attr('id', 'creature-ultimate')
        .text('Ultimate: Wind Justice')
        .appendTo('#right-after-click');

    let creatureRegion = $('<p>')
        .attr('id', 'creature-region')
        .text("Region: Heaven's Kingdom")
        .appendTo('#right-after-click');
}

function clickElement() {
    let main = $('#elementsContainer');
    let secondLayout = $('#elementInfo');

    $('div.clickable').on('click', function () {
        main.addClass('no-display');
        secondLayout.removeClass('no-display');
    });
}

renderAllElementsInHTML();
renderSingleElementInHTML();
clickElement();