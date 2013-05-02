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

    $.fn.changeField = function (ime_type) {
        var self = this;
        var $self = $(self);
        var $node_data = {
            "id": "",
            "type": "",
            "value": ""
        };

        $node_data.id = $self.attr("data-desc");
        $node_data.type = ime_type;
        $node_data.value = $self.parent().children().first().val();


        $.post("/Account/Admin", $node_data)
        .success(function (response) {
            if (response.result) {
                alert('Zmiany wykonano');
            }
            else {
                alert('Nie można wykonać zapisu - Czy pole ma unikalną wartość i od 3 do 32 znaków?');
            }
        })
        .error(function () {
            alert('Zmiana się nie powiodła');
        })
    }
});