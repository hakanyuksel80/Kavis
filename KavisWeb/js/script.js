
var birimler;

$(function () {

    api_get(base_url("api/Birimler")).done(function (d) {
        birimler = d;
    });

});

function birimListe(selectedValue, multiselect = false) {

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

    return `<select class="select-mini birim-select" ${multiselect ? "multiple" : ""}><option value="">(BİRİM SEÇİNİZ)</option>${html}</select>`;

}

function loadSelectList(ID, list, selected, addEmpty = false, valueName = "value", textName = "text") {

    let $obj = $(ID);
    $obj.empty();

    if (addEmpty)
        $obj.append(`<option value="">(SEÇİNİZ)</option>`);

    for (var i = 0; i < list.length; i++) {
        const eleman = list[i];
        let isSelected = (Array.isArray(selected) && selected.indexOf(eleman["value"]) > -1) || (!Array.isArray(selected) && eleman[valueName] == selected);
        let $option = $(`<option value="${eleman[valueName]}" ${isSelected ? "selected" : ""}>${eleman[textName]}</option>`);
        $obj.append($option);
    }

}

function showTab(tab) {
    return $('.nav-tabs a[href="#' + tab + '"]').tab('show', true);
}


function base_url(l = "") {

    return "/" + l;

}


var api_url = {

    "stratejikPlan": "/api/StratejikPlan",
    "eylemler": "api/Eylemler/",
    "faaliyet": "/api/Faaliyet",
    "faaliyetDurum": "/api/FaaliyetDurum",
    "birimler": "/api/Birimler/",
    "birimFaaliyetler" : "api/BirimFaaliyetler/",

}