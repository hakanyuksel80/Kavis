




var modal_baslik = ["", "Amaç", "Hedef", "Performans", "Strateji"];

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






class StratejikPlan {

    panel_id = "";

    templates = new strateji_templates();

    constructor(panel_id, data) {

        this.panel_id = panel_id;

        if (data != undefined) {
            //this.loadData(data);
        }

    }

    add_amac(id = '', text = '', content = '') {

        let i = $(this.panel_id + '>div').length;

        let amac = new AmacPlanItem(id, text, i);

        a.Add(amac);

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

        let amac = a.GetItem(amac_index);

        amac.Add(hedef);

        let $obj = $(hedef.Draw('added')).hide();

        $(element).parent().prev().append($obj);

        $obj.slideDown();
    }

    add_performans(element) {

        let amac_index = $(element).parents(".amac-card").index();
        let hedef_index = $(element).parents(".hedefKarti").index();

        console.log({ amac: amac_index, hedef: hedef_index });

        let amac = a.GetItem(amac_index);
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

        let amac = a.GetItem(amac_index);
        let hedef = amac.GetItem(hedef_index);
        console.log({ hedef: hedef, index: hedef_index });
        hedef.AddStrateji(item);

        $(element).parent().prev().find("tbody").append(item.Draw("added"));
    }

    delete_amac(button) {
        let i = $(button).parents(".card").index();
        let amac = a.GetItem(i);
        a.Remove(amac);
        let obj = $($(button).parents(".card")[0]);
        obj.hide();

        if (obj.data("id") != undefined)
            obj.data("state", "deleted");
        else
            obj.remove();

        this.reorder(this.panel_id, ".amac-order:visible");
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
        let a = $($('#accordionSP>.card')[index]);
        a.find(".amac-title").text(text);
        a.data("state", "modified");
    }


}


var sp = new StratejikPlan("#accordionSP", SP_Data);


function add_performans_click_event() {
    sp.add_performans(this);
}

function add_strateji_click_event() {

    sp.add_strateji(this);

}

function add_hedef_click_event() {

    sp.add_hedef(this);

}

function add_amac_click_event() {
    formEditAmac.New();
}



function on_btnDelete_click_event() {

    let target = $(this).data("target");

    switch (target) {
        case "amac": sp.delete_amac(this); break;
        case "hedef": sp.delete_hedef(this); break;
        case "performans": sp.delete_performans(this); break;
        case "strateji": sp.delete_strateji(this); break;
        case "sp": on_delete_sp_click_event(this);
    }
}

function on_btnEdit_click_event() {

    //let $a = $(this).parent().hide().prev();
    //let $b = $a.show().prev().hide();

    //$a.find("input").val($b.find('.title').text());

    let target = $(this).data("target");
    switch (target) {
        case "amac": formEditAmac.Edit(this); break;
    }
}

function on_delete_sp_click_event(button) {

    let id = $(button).data("id");

    silmeMesaji("Stratejik Planı silmek istediğinize emin misiniz? Bu kayda bağlı tüm kayıtlar silinecektir.").then(function (d) {

        if (d) {
            a.Delete(id).done(function (d) {
                $(button).parents("tr").hide(500, function () { $(this).remove(); });
            });
        }

    });


}

var a;

var birimler;

var birimListStr = "";

$(function () {

    a = new StratejikPlanItem();
    //$(document).on("click", ".btn-add", add_click_event);

    $(document).on("click", ".btn-add-performans", add_performans_click_event);

    $(document).on("click", ".btn-add-strateji", add_strateji_click_event);

    $(document).on("click", ".btn-add-hedef", add_hedef_click_event);

    $(document).on("click", ".btn-add-amac", add_amac_click_event);

    $(document).on("click", ".btn-delete", on_btnDelete_click_event);

    $(document).on("click", ".btn-edit", on_btnEdit_click_event);

    $('#uyarilarTextArea').summernote({
        height: 300,
    });


    api_get("/api/Birimler").done(function (d) {
        birimler = d;        
    });


});

function birimListe(selectedValue,multiselect = false) {

    let html = "";
    selectedValue = selectedValue ?? "";
    
    try {
        selectedValue = selectedValue.split(',');
    } catch  {
        console.log(selectedValue);
        selectedValue = "";
    }
    

    for (var i = 0; i < birimler.length; i++) {
        const birim = birimler[i];
        if (selectedValue.indexOf(birim.Id.toString()) >= 0)
            html += `<option selected value="${birim.Id}">${birim.Baslik}</option>`;
        else
            html += `<option value="${birim.Id}">${birim.Baslik}</option>`;
    }

    return `<select class="select-mini birim-select" ${multiselect?"multiple":""}><option value="">(BİRİM SEÇİNİZ)</option>${html}</select>`;

}

function showTab(tab) {
    return $('.nav-tabs a[href="#' + tab + '"]').tab('show',true);
}