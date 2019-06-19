/*
 *-Id dell'elemento selezionato sempre come primo figlio 
 * -Classe Label obbligatoria
 * 
 */
function DataForSelection(btn, Title, ControllerName_) {


    setTimeout(function () {
        $(btn).toggleClass("hide", true);
        $(btn).siblings('span').toggleClass("hide", false);
    }, 0);
    

    //ii significa che devo prendere il controller del momento, altrimenti quello settato
    var ControllerName = (ControllerName_==="ii") ? GetControllerName() : ControllerName_;
    var Url = "/" + ControllerName + "/GetDataToAsyncForDialog";
    var Dialog = $('#Dialog_');

    //Cercare di sostituire con una partial shared
    var Template = '<div id="Dialog_" class="modal_">' +
        '            <div class="modal-content">' +
        '                <div class="modal-header">' + Title
        +
        '                </div>' +
        '                <div  id="DataContainer" class="modal-body">' +
        '                   ' +
        '                </div>' +
        '                <div id="CloseDialog" class="modal-button-closed">' +
        '                    CHIUDI  ' +
        '                </div>' +
        '            </div>' +
        '        </div>';

    

    $.ajax({

        type: "GET",
        url: Url,
        dataType: "Json",
        async: false,
        success: function (data) {
            $('.render-body-zone').append(Template).fadeIn(1000);
            Dialog = $('#Dialog_');        
            CreateDialog(data);
            
        },
        error: function () {
            return;
        }

    });

    function CreateDialog(ObjectsLoaded) {
        

        for (var i = 0; i < ObjectsLoaded.length; i++) {
            var Element = ObjectsLoaded[i];
            var DataToShow = Element.datatoshow;
            var ValuedId = Element.valueId;
            var Optional = Element.optional;

            var DivToAdd=null;
            if (Option!==-1)
                 DivToAdd = '  <div class="col-sm-12 modal-element" Optional="'+ Optional + '" Id="' + ValuedId + '" >' +
                    DataToShow +
                    '  </div>';
            else DivToAdd = '  <div class="col-sm-12 modal-element" Id="' + ValuedId + '" >' +
                DataToShow +
                '  </div>';


            Dialog.find('#DataContainer').append(DivToAdd);
            console.log("aggiunto elemento");
        }
    }


    $("#CloseDialog").click(function () {
        RemoveDialog();
    });

    $(".modal-element").click(function () {
        var Text = this.outerText;
        var ValueId = this.getAttribute('Id');
        var Optional = this.getAttribute('Optional');

        //trovare errore 
        $(btn).siblings('.Label')[0].textContent = Text;
        btn.parentElement.firstElementChild.value = ValueId;
       
            try {
                btn.parentElement.firstElementChild.attributes[2].value= Optional;
            } catch (e) {
                //Console.log("nessun campo opzionale");
            }
            

        RemoveDialog();
    });

    function RemoveDialog() {
        $(btn).toggleClass("hide", false);
        $(btn).siblings('span').toggleClass("hide", true);
        Dialog.fadeOut(500);
        Dialog.remove();
    }

}