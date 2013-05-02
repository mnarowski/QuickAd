$(function () {
    console.log("Welcome in QuickAd");
    /**
    *
    *   jQuery binding
    */
    //$(".gallery").lightbox();
    /**
    * Normal functions
    **/

    QShowDialog = function (msgText) {
        var div = "<div style='display:none' title='QuickAd - Wiadomość:'>" + msgText + "</a>";
        var $dlg = $(div);
        $dlg.dialog({ buttons: [{ text: "Ok", click: function () { $(this).dialog("close"); } }], modal: true });
        $dlg.dialog();
        return $dlg;
    }

    QDeleteImage = function (num) {

        var ur = "/usun-fotke/" + num;
        $.ajax({
            url: ur,
            resultType: "json",
            success: function (response) {
                if (response.result) {
                    QShowDialog(response.message);
                    setTimeout("window.location.reload()", 1500);
                }
                else {
                    QShowDialog('Nie można wykonać zmian');
                }
            }
        });

    }
    /***
    *
    *   jQuery functions
    */
    $.fn.addFileUpload = function () {
        var self = this;
        var $form = self.closest("form");
        var imagesSize = $form.children("input[type=file]").size();
        if (imagesSize < 5) {
            $form.append("<input type=\"file\" name=\"file" + imagesSize + "\"/>");
        } else {
            QShowDialog('Nie można dodać więcej niż 5 plików jednorazowo!');
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
                QShowDialog('Zmiany wykonano');
            }
            else {
                QShowDialog('Nie można wykonać zapisu - Czy pole ma unikalną wartość i od 3 do 32 znaków?');
            }
        })
        .error(function () {
            QShowDialog('Zmiana się nie powiodła');
        })
    }


});