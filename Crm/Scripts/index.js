

function HideLoadingSpinner() {
    $('.loading-spinner').hide();
}

function ShowLoadingSpinner() {
    $('.loading-spinner').show();
}


function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        $('#myBtn').fadeIn(200);
    } else {
        $('#myBtn').fadeOut(200);
    }
}

function topFunction()
{
    $('html, body').animate({ scrollTop: 0 }, 500);
}