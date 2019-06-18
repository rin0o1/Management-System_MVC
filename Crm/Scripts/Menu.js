
function showmenu() {
    $('.image-open-menu').fadeOut(200);
    $("#mymenu").toggle("drop");
}



function closemenu() {
    $("#mymenu").toggle("drop");
    $('.image-open-menu').fadeIn(1000);
}


/* FINIRE */
var ControllerName;



function DeleteElement(Id) {
    ShowSpin();

    var id = (Id === -1) ? GetIdFromAPartial() : Id;

    var ControllerName = GetControllerName();
    var Action = "/RemoveElementWithId";
    var Url = "/" + ControllerName + Action;

    $.ajax({
        type: "POST",
        url: Url,
        data: { Id: id },
        async: false,
        success: function (redirectToUrl) {
            toastr.success("CANCELLAZIONE AVVENUTA CORRETTAMENTE");
            window.location.replace(redirectToUrl.redirectTo);
            return true;
        }
        ,
        error: function () {
            toastr.error("ERRORE", "Errore nella cancellazione dell'elemento");
            RemoveSpinn();
            return false;
        }


    });


}





    

