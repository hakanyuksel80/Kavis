class FormEditAmac extends Form {

    Save() {
        let d = formEditAmac.GetValues();
        console.log(d);

        if (d.Id == "" || d.Id == undefined && d.Id == "0")
            spViewManager.add_amac(d.Id, d.Baslik);
        else {
            spViewManager.update_amac(d.Index, d.Baslik);
        }
        this.Close();
    }

    Edit(btn) {
        let index = $($(btn).parents(".card")[0]).index();

        let id = $($(btn).parents(".card")[0]).data("id");
        let baslik = $($(btn).parents(".card")[0]).find(".amac-title").text();

        let d = { Id: id, Baslik: baslik, Index: index };
        console.log(d);
        this.PutValues(d);
        this.Show();
    }

}





class StratejikPlanViewManager {

    panel_id = "";

    //templates = new strateji_templates();

    constructor(panel_id, data) {

        this.panel_id = panel_id;

        if (data != undefined) {
            //this.loadData(data);
        }

    }

    add_amac(id = '', text = '', content = '') {

        let i = $(this.panel_id + '>div').length;

        let amac = new AmacPlanItem(id, text, i);

        spViewBuilder.Add(amac);

        let $obj = amac.Draw("added");

        let $header = $obj.find(".card-header").hide();

        $(this.panel_id).append($obj);

        $header.slideDown();

        $obj.data("state");

        return $obj;

    }

    add_hedef(element) {

        let amac_index = $(element).parents(".card").index();

        let i = $(element).parent().prev().children().length;

        let hedef = new HedefPlanItem('', "YENİ HEDEF", i + 1, 'added');

        let amac = spViewBuilder.GetItem(amac_index);

        amac.Add(hedef);

        let $obj = $(hedef.Draw('added')).hide();

        $(element).parent().prev().append($obj);

        $obj.slideDown();
    }

    add_performans(element) {

        let amac_index = $(element).parents(".amac-card").index();
        let hedef_index = $(element).parents(".hedefKarti").index();

        console.log({ amac: amac_index, hedef: hedef_index });

        let amac = spViewBuilder.GetItem(amac_index);
        let hedef = amac.GetItem(hedef_index);


        let i = $(element).parent().prev().find("tbody").children("tr:visible").length;
        let item = new GostergePlanItem({ Id: '', SiraNo: '', Baslik: "", });//i + 1
        $(element).parent().prev().find("tbody").append(item.Draw());

        hedef.AddGosterge(item);
    }

    add_strateji(element) {
        let amac_index = $(element).parents(".amac-card").index();
        let hedef_index = $(element).parents(".hedefKarti").index();
        let i = $(element).parent().prev().find("tbody").children().length;
        let item = new StratejiPlanItem("", "", i);

        let amac = spViewBuilder.GetItem(amac_index);
        let hedef = amac.GetItem(hedef_index);
        console.log({ hedef: hedef, index: hedef_index });
        hedef.AddStrateji(item);

        $(element).parent().prev().find("tbody").append(item.Draw("added"));
    }

    delete_amac(button) {
        let $amac_card = $(button).parents(".card")
        let i = $amac_card.index(); //Düğmenin olduğu amaç bölümün sırasını bul
        let amac = spViewBuilder.GetItem(i); // Bu sıradaki amaç nesnesini al
        spViewBuilder.Remove(amac);// Hazıfazadan sil
        let obj = $($amac_card[0]);//Kart elementini al. Üst kartlara dokunmayalım
        obj.hide(); //Gizle

        //Eğer veritabanında kaydı varsa state özelliğini deleted yap
        if (obj.data("id") != undefined)
            obj.data("state", "deleted");
        else
            obj.remove();//Kaydı yoksa yok et gitsin.

        this.reorder(this.panel_id, ".amac-order:visible"); //Amaç numaralarını tekrar oluştur
    }

    delete_hedef(button) {
        let $amac_panel = $($(button).parents(".amac-content")[0]);
        let $hedef_card = $($(button).parents(".card")[0]);

        let id = $hedef_card.data("id");
        if (id == "" || id == undefined)
            $hedef_card.remove();
        else {
            $hedef_card.hide();
            $hedef_card.data("state", "deleted");
        }

        this.reorder($amac_panel, ".hedef-order:visible");
    }

    delete_strateji(button) {
        let container = $(button).parents("tbody")[0];
        let $s = $($(button).parents("tr")[0]);
        let id = $s.data("id");


        if (id != "" && id != undefined && id != "0") {
            $s.data("state", "deleted");
            console.log($s.data("state"));
            $s.hide();
        }
        else
            $s.remove();
        this.reorder(container, ".strateji-order:visible");
    }

    delete_performans(button) {
        let container = $(button).parents("tbody")[0];
        let $s = $($(button).parents("tr")[0]);
        let id = $s.data("id");
        if (id != "" && id != undefined && id != "0") {
            $s.data("state", "deleted");
            $s.hide();
        }
        else
            $s.remove();
        //this.reorder(container, ".gosterge-order:visible");
    }

    reorder(container, target_name) {
        $(container).find(target_name).each(function (b, d) {
            d.innerText = b + 1;
        });
    }

    update_amac(index, text) {
        let amac = $($('#accordionSP>.card')[index]);
        amac.find(".amac-title").text(text);
        amac.data("state", "modified");
    }

}


class StratejikPlanCRUDManager {

    constructor(buildManager) {
        this.buildManager = buildManager;
    }

    Get(id) {

        let THIS = this;
        return api_get(base_url("api/StratejikPlan/" + id)).done(function (d) {
            console.log({ sp: d });
            THIS.buildManager.Build(d);
            THIS.buildManager.Draw("#accordionSP");
        });
    }

    Post() {
        let THIS = this;

        let data = this.buildManager.Collect();

        data.Id = this.buildManager.Id;
        data.KurumAdi = this.buildManager.KurumAdi;
        data.KurumId = this.buildManager.KurumId;
        data.Baslangic = this.buildManager.Baslangic;
        data.Tur = this.buildManager.Tur;

        return api_post(base_url("api/StratejikPlan"), data).done(function (d) {

            if (d.Success) {
                successMessage("Kayıt Yapıldı");
                THIS.Get(data.Id);
            } else {
                errorMessage(d.Message);
            }


        });
    }

    Delete(id) {

        if (id == 1)
            return errorMessage("Bu Kayıt Silinemez");

        return api_delete(base_url("api/StratejikPlan/" + id), function (d) {
            if (d.Success) {
                successMessage("Stratejik Plan Silindi");

            } else {
                errorMessage(d.Message);
            }
        });

    }

}

/* Events Handlers */


function add_click_event() {
    let i = 0;
    i += $(this).hasClass("btn-add-amac") ? 1 : 0;
    i += $(this).hasClass("btn-add-hedef") ? 2 : 0;
    //i += $(this).hasClass("btn-add-performans") ? 3 : 0;
    i += $(this).hasClass("btn-add-strateji") ? 4 : 0;

    if (i > 0) {
        $('#amacDuzenle .baslik').text(modal_baslik[i]);
        $('#amacDuzenle').modal();
    }
}


function add_performans_click_event() {
    spViewManager.add_performans(this);
    $('select.birim-select').select2({ width: "100%" });
}

function add_strateji_click_event() {
    spViewManager.add_strateji(this);
}

function add_hedef_click_event() {
    spViewManager.add_hedef(this);
}

function add_amac_click_event() {
    formEditAmac.New();
}

function on_btnDelete_click_event() {

    let target = $(this).data("target");

    switch (target) {
        case "amac": spViewManager.delete_amac(this); break;
        case "hedef": spViewManager.delete_hedef(this); break;
        case "performans": spViewManager.delete_performans(this); break;
        case "strateji": spViewManager.delete_strateji(this); break;
        case "sp": on_delete_sp_click_event(this);
    }
}

function on_btnEdit_click_event() {

    let target = $(this).data("target");
    switch (target) {
        case "amac": formEditAmac.Edit(this); break;
    }
}


/* Global Vars */


var spViewBuilder;

var formEditAmac = new FormEditAmac("#amacDuzenle");

var spViewManager = new StratejikPlanViewManager("#accordionSP");

var spManager;

$(function () {

    spViewBuilder = new StratejikPlanItem();

    spManager = new StratejikPlanCRUDManager(spViewBuilder);

    $(document).on("click", ".btn-add-performans", add_performans_click_event);

    $(document).on("click", ".btn-add-strateji", add_strateji_click_event);

    $(document).on("click", ".btn-add-hedef", add_hedef_click_event);

    $(document).on("click", ".btn-add-amac", add_amac_click_event);

    $(document).on("click", ".btn-delete", on_btnDelete_click_event);

    $(document).on("click", ".btn-edit", on_btnEdit_click_event);

   


   


});