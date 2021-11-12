
function api_post(url, data, onSuccess) {
    return $.post(url, data, onSuccess).fail(function (e) {
        errorMessage("Bağlantı Hatası Hata Oluştu");
    });
}


function api_get(url, onSuccess) {
    return $.get(url, onSuccess).fail(function (e) {
        errorMessage("Bağlantı Hatası Hata Oluştu");
    });
}


function api_delete(url, onSuccess) {

    return $.ajax({
        url: url,
        type: 'DELETE',
        
        success: onSuccess,
    }).fail(function (e) {
        errorMessage("Bağlantı Hatası Hata Oluştu");
    });    
}


function successMessage(baslik, mesaj) {
    //swal(baslik, mesaj, "success");
    toastr.success(mesaj, baslik);
}

function errorMessage(baslik, mesaj) {
    //swal(baslik, mesaj, "success");
    toastr.error(mesaj, baslik);
}

function silmeMesaji(mesaj) {
    mesaj = mesaj == undefined ? "Bu kaydı silmek istediğinize emin misiniz?" : mesaj;
    return swal("Kayıt Silme", mesaj, "error", {
        buttons: ["Hayır", "Evet"],
    });
}

function onayMesaji(mesaj, baslik = "Onay") {
    return swal(baslik, mesaj, {
        buttons: ["Hayır", "Evet"],
    });
}