$(function () {
    console.log("Welcome in QuickAd");

    $.fn.addFileUpload = function () {
        var self = this;
        var $form = self.closest("form");
        var imagesSize = $form.children("input[type=file]").size();
        if (imagesSize < 5) {
            $form.append("<input type=\"file\" name=\"file" + imagesSize + "\"/>");
        } else {
            alert('Nie można dodać więcej niż 5 plików jednorazowo!');
        }
    }
});