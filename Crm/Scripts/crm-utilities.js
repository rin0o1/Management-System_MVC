
var CalculationType =
{
    AVARAGE:0,
    SUM : 1,
    PERCENTAGE:2  
};

/*
 Sconto
 Totale

Sconto_= (Totale x Sconto) / 100
Risultato =  Totale-Sconto_
 
\ */


/*Passare il numero preventivo per salvare */
function GeneratePdfFromElementId(form) {

    var ElementsToConvert = form.find('.chg');
    var OriginalType = [];

    var Length = ElementsToConvert.length;


    //=================================================================================================
    //WORK AROUND DA RISOLVERE 
    //=================================================================================================
    //Prendo tutti gli elementi con la classe chg e cambio il tipo da data/number a text per poterlo trasformare in un'immagine
    //Costruito il file riporto lo stato come in origine
    //
    for (var i = 0; i< Length; i++) {
        var Element = ElementsToConvert[i];
        OriginalType.push(Element.type);
        Element.type = 'text';
    }


    html2canvas($('#Form_'), {
        onrendered: function (canvas) {
            var img = canvas.toDataURL("image/png", 1.0);
            var doc = new jsPDF("landscape", "mm", "a4");

            doc.addImage(img, 'PNG', 10, 10, 260, 170);
            for (var x = 0; x < Length; x++) {
                ElementsToConvert[x].type = OriginalType[x];
            }
            RemoveSpinn();   
            doc.save("Image.pdf");
        }
        
    }); 

    
    
}


/**
 * /
 * @param {any} StartElement elemento di partenza per trovre tutti i fratelli
 * @param {any} calculationtype tipo di calcolo che si vuole effettuare dopo avere preso le
 *  informazioni
 *  Questo tipo di operazione è possibile solo ricevendo degli "input" selector come input
 * 
 */





function CalculateDataUsingCustomInput(StartElement, calculationtype) {

    var Inputs = $(StartElement).siblings('.Inp');
    var DestinationElement = $(StartElement).siblings('.Dest');
    var Sconto = $(StartElement).val();
    /*Tutti i valori degli input*/
    var Values = [];

    for (var i = 0; i < Inputs.length; i++) {
       var  SingleValue = Inputs[i].value;
        Values.push(SingleValue);
    }


    var CalculationType = calculationtype;

    switch (CalculationType) {

        case 0:
            break;
        
        case 1:
            break;
        /*PERCENTAGE*/
        case 2:
            var Totale = Values[0];/*In questo caso avrò solo un input che rappresenta il totale*/
            var Risultato =(Sconto>0 && Sconto<100)? Totale - ((Totale * Sconto) / 100) : 0;
            $(DestinationElement).val(Risultato);
            break;
        
        default: break;
    }
}