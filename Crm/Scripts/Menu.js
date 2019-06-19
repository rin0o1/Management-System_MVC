
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



$(document).on("click", ".removeicon", function () {

    ShowSpin();

    var ElementToRemove = $(this).closest("tr");
    
    var Id = ElementToRemove.attr("id");
    DeleteElement(Id);


    //Senza rimuovere la riga, faccio il refresh 
    //$(this).closest('tr')
    //   .children('td')
    //   .animate({ padding: 2 })
    //   .wrapInner('<div />')
    //   .children()
    //       .slideUp(function () { ElementToRemove.remove(); });

});


    

