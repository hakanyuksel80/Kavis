function on_delete_sp_click_event(button) {

    let id = $(button).data("id");

    alert("ddddd");


    silmeMesaji("Stratejik Planı silmek istediğinize emin misiniz? Bu kayda bağlı tüm kayıtlar silinecektir.").then(function (d) {

        if (d) {
            a.Delete(id).done(function (d) {
                $(button).parents("tr").hide(500, function () { $(this).remove(); });
            });
        }

    });


}



var birimler;

var birimListStr = "";

$(function () {    

    api_get("/api/Birimler").done(function (d) {
        birimler = d;        
    });

});

function birimListe(selectedValue,multiselect = false) {

    let html = "";
    selectedValue = selectedValue ?? "";
    selectedValue = selectedValue.toString().split(',');

    for (var i = 0; i < birimler.length; i++) {
        const birim = birimler[i];
        if (selectedValue.indexOf(birim.Id.toString()) >= 0)
            html += `<option selected value="${birim.Id}">${birim.Baslik}</option>`;
        else
            html += `<option value="${birim.Id}">${birim.Baslik}</option>`;
    }

    return `<select class="select-mini birim-select" ${multiselect?"multiple":""}><option value="">(BİRİM SEÇİNİZ)</option>${html}</select>`;

}

function loadSelectList(ID, list, selected, addEmpty = false, valueName = "value", textName = "text") {

    let $obj = $(ID);
    $obj.empty();

    if (addEmpty)
        $obj.append(`<option value="">(SEÇİNİZ)</option>`);

    for (var i = 0; i < list.length; i++) {
        const eleman = list[i];
        console.log(eleman);
        let isSelected = (Array.isArray(selected) && selected.indexOf(eleman["value"]) > -1) || (!Array.isArray(selected) && eleman["value"] == selected);
        
        let $option = $(`<option value="${eleman[valueName]}" ${isSelected ? "selected" : ""}>${eleman[textName]}</option>`);
        $obj.append($option);
    }

}

function showTab(tab) {
    return $('.nav-tabs a[href="#' + tab + '"]').tab('show',true);
}


function base_url(l = "") {

    return "\\"+l;

}