




function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        $('#btn_scrolltop').fadeIn(200);
    } else {
        $('#btn_scrolltop').fadeOut(200);
    }
    
}

function topFunction()
{
    $('html, body').animate({ scrollTop: 0 }, 'slow');
}