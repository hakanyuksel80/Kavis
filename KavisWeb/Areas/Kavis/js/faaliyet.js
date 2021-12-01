
class FaaliyetForm extends Form {

    constructor() {
        super("#faaliyetEkle");
    }

    Clear() {
        super.Clear();
    }

    New(eylemId, eylemAdi) {
        this.Clear();
        $(this.modalId + "#FaaliyetId").val('');
        $(this.modalId + " #EylemId").val(eylemId);
        $(this.modalId + " .eylemAdi").text(eylemAdi);
        $(this.modalId + " #BirimId").val($('#seciliBirimId').val());
        $(this.modalId + " #Yil").val(aktifYil);
        this.Show();
    }

    Edit(id, eylemAdi) {

        let THIS = this;

        api_get(base_url("api/Faaliyet/get/" + id), function (d) {           
            
            $(THIS.modalId + " .eylemAdi").text(eylemAdi);            
            THIS.PutValues(d);
            THIS.Show();
        });
    }

    Save() {

        let data = this.GetValues();
        let eylem = $("#faaliyetEkle .eylemAdi").text();

        api_post(base_url("api/Faaliyet/post"), data).done(function (d) {

            if (d.Success) {
                faaliyet.LoadFaaliyetler();
                showTab("faaliyetler");
            }
        });

        return true;
    }


}

class FaaliyetDurumForm extends Form {

    constructor() {
        super("#faaliyetDurum");
    }

    Edit(id, EylemAdi) {
        let THIS = this;

        api_get(base_url("api/FaaliyetDurum/get/" + id), function (d) {
            console.log(d);
            d.Baslama = d.Baslama != null ? d.Baslama.substr(0, 10) : "";
            d.Bitis = d.Bitis != null ? d.Bitis.substr(0, 10) : "";
            THIS.PutValues(d);
            $(THIS.modalId + " .eylem").text(d.EylemAdi);
            $(THIS.modalId + " .faaliyet").text(d.FaaliyetAdi);

            THIS.Show();
        });

    }

    Save() {

        let data = this.GetValues();
        console.log(data);

        api_post(base_url("api/FaaliyetDurum/post"), data).done(function (d) {

            if (d.Success) {
                faaliyet.LoadFaaliyetler();
                successMessage("Kayıt Yapıldı");
            }
        });

        return true;
    }


}


var faaliyetDurumForm = new FaaliyetDurumForm();

var faaliyetForm = new FaaliyetForm();



/*
 * Olay Metodları 
 */

function onFaaliyetDurumClickEvent() {
    let id = $(this).data("id");
    faaliyetDurumForm.Edit(id);
}

function onFaaliyetDuzenleClickEvent() {
    let id = $(this).data("id");
    let eylemAdi = $(this).parent().parent().prev().prev().text();
    faaliyetForm.Edit(id, eylemAdi);
}

function onFaaliyetSilClickEvent() {
    let id = $(this).data("id");
    silmeMesaji("Silmek istediğinize emin misiniz?").then(function (d) {
        if (d) {
            faaliyet.Delete(id);
        }
    });
}