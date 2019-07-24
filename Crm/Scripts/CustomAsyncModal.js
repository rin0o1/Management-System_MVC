/*
 *-Id dell'elemento selezionato sempre come primo figlio 
 * -Classe Label obbligatoria
 * 
 */
function DataForSelection(btn, Title, ControllerName_) {

    //ShowSpin();

    setTimeout(function () {
        //$(btn).toggleClass("hide", true);
        //$(btn).siblings('span').toggleClass("hide", false);
        ShowSpin();
    }, 10);


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
        '                <input id="InputFilter" style="width:100%" placeholder="Ricerca..." type="text"  />' +
        '                <div  id="DataContainer" class="modal-body">' +
        '                   ' +
        '                </div>' +
        '                <div id="CloseDialog" class="modal-button-closed">' +
        '                    CHIUDI  ' +
        '                </div>' +
        '            </div>' +
        '        </div>';
    


    function LoadData(filter) {

        $.ajax({

            type: "GET",
            url: Url,
            dataType: "Json",
            async: false,
            data: {filter:filter},
            success: function (data) {
                if (filter===null)
                    $('.render-body-zone').append(Template).fadeIn(1000);

                Dialog = $('#Dialog_');
                CreateDialog(data);
            },
            error: function () {
                return;
            }

        });
    }


    LoadData(null);

    //Quando cambia il valore del filtro ricarico i dati
    $("#InputFilter").on("input", function (e) {
        LoadData(this.value);
    });



    function CreateDialog(ObjectsLoaded) {
        
        //Pulisco per evitare di duplicare
        $(Dialog).find('#DataContainer').empty();
        for (var i = 0; i < ObjectsLoaded.length; i++) {

            var Element = ObjectsLoaded[i];
            //var DataToShowArray = [];
            //  DataToShowArray  = Element.datatoshow;
            var ValuedId = Element.valueId;
            var Optional = Element.optional;
            var DataToShow = Element.datatoshow;
            var DivToAdd = null;

            //if (DataToShowArray.length > 1) {
            //    for (var x = 0; x < DataToShowArray.length; x++) {
            //        DataToShow += DataToShowArray[x] + '\xa0\xa0\xa0\xa0\xa0\xa0\xa0\xa0\xa0';
            //    }
            //}

            //else {
            //    DataToShow = DataToShowArray[0];
            //}
            

            if (Option !== -1)
                DivToAdd = '  <div class="col-sm-12 modal-element" Optional="' + Optional + '" Id="' + ValuedId + '" >' +
                    DataToShow +
                    '  </div>';

            else {

           
                DivToAdd = '  <div class="col-sm-12 modal-element" Id="' + ValuedId + '" >' +
                DataToShow +
                    '  </div>';

            }

            Dialog.find('#DataContainer').append(DivToAdd);
        }
    }


    $("#CloseDialog").click(function () {
        RemoveDialog();
    });

    $(".modal-element").click(function () {

        var Text = this.outerText;
        var ValueId = this.getAttribute('Id');
        var Optional = this.getAttribute('Optional');

        
        $(btn).siblings('.Label')[0].textContent = Text;

        btn.parentElement.firstElementChild.value = ValueId;

        //se da errore vuol dire che il campo attributes è vuoto
            try {
                btn.parentElement.firstElementChild.attributes[2].value= Optional;
            } catch (e) {
                //Console.log("nessun campo opzionale");
            }
            
        RemoveDialog();
    });

    function RemoveDialog() {
        //$(btn).toggleClass("hide", false);
        //$(btn).siblings('span').toggleClass("hide", true);

        //Dialog.fadeOut(500);
        Dialog.remove();

        RemoveSpinn();
        
    }

}

function ReloadData(Input) {
    
    ShowSpin();

    var Url = "/" + GetControllerName() + "/GetDataAsync";
    $('#InformationContainer').empty();

    $.ajax({

        type: "POST",
        url: Url,
        dataType: "Json",
        data: {filter: Input.value},
        async: false,
        success: function (data) {
            
            $("#InformationContainer").append(data.HTMLString);
            RemoveSpinn();
        },
        error: function () {
            return;
        }

    });
    

}
