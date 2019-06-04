//Gestione della cancellazione e dei dettagli di ogni row



$(document).on("click", ".removeicon",  function () {

    var ElementToRemove = $(this).closest("tr");

    //ElementToRemove.animate({
    //    height: 'toggle'
    //});

    $(this).closest('tr')
        .children('td')
        .animate({ padding: 2 })
        .wrapInner('<div />')
        .children()
        .slideUp(function () { ElementToRemove.remove(); });

    var Id = ElementToRemove.attr("id");
    RemoveElement(Id);
});

//Possibile riutilizzo di questa funzione in tutte le pagin
function RemoveElement(id) {

    
    if (id === undefined) 
        return;
    

    var ControllerName = GetControllerName();
    var Action = "/RemoveElementWithId";
    var Url = ControllerName + Action;
    
    $.ajax({

        type: "POST",
        url: Url,
        data: { Id: id },
        async: false,
        success: function () {
            
        }
        ,
        error: function () {
        }

    });


}

//Entrare nel dettaglio di un elemento

//$(document).on("click", ".detailsicon", function () {
//    var ElementToRemove = $(this).closest("tr");
//    var id = ElementToRemove.attr("id");
    
//    var Url = GetControllerName() + "/Details";

//    //Chiamata ajax al controller
//    $.ajax({

//        type: "POST",
//        url: Url,
//        data: { Id : id },
//        async: false,

//        success: function () {
//            alert("ok");
//        }
//        ,
//        error: function () {
//        }
//    });
//    });
