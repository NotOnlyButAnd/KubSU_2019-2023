$(document).ready(function()
{
    $('.openButton').click(function() {
        if(!$('.openButton').hasClass('openDone'))
        {
            $('.openButton').addClass('openDone');
            $('nav').css("left", "0px");
            $('a').css("left", "250px");
        }
        else
        {
            $('.openButton').removeClass('openDone');
            $('nav').css("left", "-250px");
            $('a').css("left", "0px");
        }
    });
});