




function scrollFunction() {
    if (document.body.scrollTop > 300 || document.documentElement.scrollTop > 300) {
        $('#btn_scrolltop').fadeIn(200);
    } else {
        $('#btn_scrolltop').fadeOut(200);
    }

}

function topFunction()
{
    $('html, body').animate({ scrollTop: 0 }, 'slow');
}