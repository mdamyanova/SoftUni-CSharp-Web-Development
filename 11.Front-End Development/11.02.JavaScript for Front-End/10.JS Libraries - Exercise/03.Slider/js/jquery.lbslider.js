(function($){
    $.fn.lbSlider = function(options) {
        var options = $.extend({
            leftBtn: '.leftBtn',
            rightBtn: '.rightBtn',
            visible: 3,
            autoPlay: false,  // true or false
            autoPlayDelay: 10,  // delay in seconds
            autoPlayDirection: 'right-to-left'  //autoplay direction
        }, options);
        var make = function() {
            $(this).css('overflow', 'hidden');
            
            var thisWidth = $(this).width();
            var mod = thisWidth % options.visible;
            if (mod) {
                $(this).width(thisWidth - mod); // to prevent bugs while scrolling to the end of slider
            }
            
            var el = $(this).children('ul');
            el.css({
                position: 'relative',
                left: '0'
            });
            var leftBtn = $(options.leftBtn), rightBtn = $(options.rightBtn);

            var sliderFirst = el.children('li').slice(0, options.visible);
            var tmp = '';
            sliderFirst.each(function(){
                tmp = tmp + '<li>' + $(this).html() + '</li>';
            });
            sliderFirst = tmp;
            var sliderLast = el.children('li').slice(-options.visible);
            tmp = '';
            sliderLast.each(function(){
                tmp = tmp + '<li>' + $(this).html() + '</li>';
            });
            sliderLast = tmp;

            var elRealQuant = el.children('li').length;
            el.append(sliderFirst);
            el.prepend(sliderLast);
            var elWidth = el.width()/options.visible;
            el.children('li').css({
                float: 'left',
                width: elWidth
            });
            var elQuant = el.children('li').length;
            el.width(elWidth * elQuant);
            el.css('left', '-' + elWidth * options.visible + 'px');

            function disableButtons() {
                leftBtn.addClass('inactive');
                rightBtn.addClass('inactive');
            }
            function enableButtons() {
                leftBtn.removeClass('inactive');
                rightBtn.removeClass('inactive');
            }

            leftBtn.click(function(event){
                event.preventDefault();
                if (!$(this).hasClass('inactive')) {
                    disableButtons();
                    el.animate({left: '+=' + elWidth + 'px'}, 300,
                        function(){
                            if ($(this).css('left') == '0px') {$(this).css('left', '-' + elWidth * elRealQuant + 'px');}
                            enableButtons();
                        }
                    );
                }
                return false;
            });

            rightBtn.click(function(event){
                event.preventDefault();
                if (!$(this).hasClass('inactive')) {
                    disableButtons();
                    el.animate({left: '-=' + elWidth + 'px'}, 300,
                        function(){
                            if ($(this).css('left') == '-' + (elWidth * (options.visible + elRealQuant)) + 'px') {$(this).css('left', '-' + elWidth * options.visible + 'px');}
                            enableButtons();
                        }
                    );
                }
                return false;
            });

            if (options.autoPlay) {
                function aPlay() {
                	var direction =(options.autoPlayDirection);
                	if(direction === 'left-to-right')
                		leftBtn.click();
                	else if(direction === 'right-to-left')
                		rightBtn.click();
                	else
                		leftBtn.click();
                    delId = setTimeout(aPlay, options.autoPlayDelay * 1000);
                }
                var delId = setTimeout(aPlay, options.autoPlayDelay * 1000);
                el.hover(
                    function() {
                        clearTimeout(delId);
                    },
                    function() {
                        delId = setTimeout(aPlay, options.autoPlayDelay * 1000);
                    }
                );
            }
        };
        return this.each(make);
    };
})(jQuery);
