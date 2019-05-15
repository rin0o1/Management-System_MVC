//Gestione della cancellazione e dei dettagli di ogni row



$(document).on("click", ".removeicon", function () {
    var ElementToRemove = $(this).closest("tr");
    ElementToRemove.animate({
        height: 'toggle'
    });

    var Id = ElementToRemove.attr("id");
});

//Metodo asincrono per rimuovere i dati effettivamente dal database



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
