//Gestione della cancellazione e dei dettagli di ogni row



//Rimuovere una riga
$(document).on("click", ".removeicon", function () {

    var ElementToRemove = $(this).closest("tr");
    //ElementToRemove.fadeToggle('slow');
    ElementToRemove.animate({
        height: 'toggle'
    });
    var Id = ElementToRemove.attr("id");

    //ElementToRemove.remove();
});

///Metodo per rimuovere i dati effettivamente dal database





//Entrare nel dettaglio di un elemento
$(document).on("click", ".detailsicon", function () {
    var ElementToRemove = $(this).closest("tr");
    //ElementToRemove.fadeToggle('slow');
    ElementToRemove.animate({
         left: '250px'
    });
    var Id = ElementToRemove.attr("id");
});
