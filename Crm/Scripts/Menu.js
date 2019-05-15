
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

//$(document).on("click", ".crm-menu-button", function () {

//    var ButtonPressed = $(this).attr("value");
//    ControllerName = $("#_ControllerName").attr("value");

//    switch (ButtonPressed) {

//        case "add":
//            AddElement();
//            break;
//        case "print":
//            window.print();
//            break;
//    }

//});


//Richiamare il metodo aggiungi del controller
function AddElement()
{
    ControllerName = $("#_ControllerName").attr("value");
    $.post( ControllerName+"/Create");

}




    

