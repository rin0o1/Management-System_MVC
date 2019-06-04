
function DataForSelection(btn) {


    
    var ControllerName = GetControllerName();
    var Url = "/" + ControllerName + "/GetDataToAsyncForDialog";
    var Dialog = $('#Dialog_');



    $.ajax({

        type: "GET",
        url: Url,
        dataType: "Json",
        async: false,
        success: function (data) {
            CreateDialog(data);
        },
        error: function()
        {
            alert("Qualcosa è andato storto");
        }
        
    });

    function CreateDialog(ObjectsLoaded) {
        var Template = [
            ' <div id="Dialog_" class="custom-modal-container" >' +
            '  <div class="custom-modal-title">' +
            '  	TITOLO' +
            '  </div>' +
            ' <div id="DataContainer" class="custom-modal-datacontainer">'+
            ' </div>'+
            '  <div id="CloseDialog" class="custom-modal-button-closed col-sm-4 ">' +
            '  			CHIUDI' +
            '  </div>' +
            '</div>'
        ];

        $('.render-body-zone').append(Template);
        Dialog = $('#Dialog_');
        
        for (var i = 0; i < ObjectsLoaded.length; i++) {
            var Element = ObjectsLoaded[i];
            var DataToShow = Element.datatoshow;
            var ValuedId = Element.valueId;

            var DivToAdd = '  <div class="col-sm-12 custom-modal-element" Id="' + ValuedId + '" >' +
                DataToShow +
                '  </div>';

            Dialog.find('#DataContainer').append(DivToAdd);
            console.log("aggiunto elemento");
        }
    }
    
    

    $("#CloseDialog").click(function () {
        RemoveDialog();
    });

    $(".custom-modal-element").click(function () {
        var Text = this.outerText;
        btn.parentElement.firstElementChild.textContent = Text;
        RemoveDialog();
    });

    function RemoveDialog() {
        Dialog.fadeOut(500);
        Dialog.remove();
    }

}


$(window).load(function () {
    // Animate loader off screen
    $(".loading-spinner").fadeOut("slow");
});

function GetControllerName()
{
    var controlllerName = $('#_ControllerName').val();
    return controlllerName;
}


function GetIdFromAPartial() {

    var id = $('#IdOfThisElement').val();
    return id;
}
function scrollFunction() {
    if (document.body.scrollTop > 300 || document.documentElement.scrollTop > 300) {
        $('#btn_scrolltop').fadeIn(200);
    } else {
        $('#btn_scrolltop').fadeOut(200);
    }

}
(function ($) {
    $.fn.serializeFormJSON = function () {

        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };
})(jQuery);
function topFunction()
{
    $('html, body').animate({ scrollTop: 0 }, 'slow');
}