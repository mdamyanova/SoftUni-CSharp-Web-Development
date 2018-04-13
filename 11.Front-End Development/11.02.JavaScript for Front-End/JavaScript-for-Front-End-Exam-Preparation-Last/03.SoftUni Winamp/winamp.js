function renderDataInHTML() {
    let heading=$('<h1>');

    heading
        .text('Front-End-Player')
        .addClass('heading')
        .appendTo('form');

    let imgContainer=$('<div>');

    imgContainer
        .addClass('img-ctr')
        .appendTo('form');

    let image=$('<img src="love-music.png" alt="music">');

    image.appendTo(imgContainer);

    let divContainer=$('<div>');

    divContainer
        .addClass('container')
        .appendTo('form');

    let prevIcon=$('<i id="prev" class="fa fa-step-backward"' +
        ' aria-hidden="true"></i>');

    prevIcon.appendTo(divContainer);

    let playIcon=$('<i id="play" class="fa fa-play-circle" ' +
        'aria-hidden="true"></i>');

    playIcon.appendTo(divContainer);

    let pauseIcon=$('<i id="pause" class="fa fa-pause-circle" aria-hidden="true"></i>');
    pauseIcon
        .addClass('hidden')
        .appendTo(divContainer);

    let nextIcon=$('<i id="next" class="fa fa-step-forward"' +
        ' aria-hidden="true"></i>');

   nextIcon.appendTo(divContainer);

    let inputDiv=$('<div>');

    inputDiv
        .addClass('input-ctr')
        .appendTo('form');

    let inputType=$('<input>');

    inputType
        .attr('type','text')
        .addClass('result')
        .attr('disabled','disabled')
        .attr('value','Play me !')
        .appendTo(inputDiv);

    $('#play').on('click',function () {
        $('#play').addClass('hidden');
        $('#pause').removeClass('hidden');
        $('.result').val('Music Playing');

    });

    $('#pause').on('click',function () {
        $('#pause').addClass('hidden');
        $('#play').removeClass('hidden');
        $('.result').val('Music Paused');

    });

    $('#prev').on('click',function () {
        $('.result').val('Previous song');

    });

    $('#next').on('click',function () {
        $('.result').val('Next song');

    });
}

renderDataInHTML();