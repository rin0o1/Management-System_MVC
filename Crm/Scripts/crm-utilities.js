

function GeneratePdfFromElementId() {

    html2canvas($('#Form_'), {
        onrendered: function (canvas) {
            var img = canvas.toDataURL("image/png");
            
            var doc = new jsPDF('landscape');
            doc.addImage(img, 'JPEG', 0, 0);
            doc.save("Image.pdf");
        }
    }); 

}