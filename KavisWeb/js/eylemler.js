﻿
class Eylemler_Templates {

    constructor() {

    }


    birim_select() {

        return `<select class="select-mini birim-select">
            <option value="">(BİRİM SEÇİNİZ)</option>
        </select>`;

    }

    eylem(id, title, no, birim, state) {
        return ` <div class="boxed eylem" data-id="${id}" data-state="${state}">
                Eylem <span class='eylem-no'>${no}</span>
                <span class='eylem-title' contenteditable="true">${title}</span>
                <div class="float-right d-flex">
                    <div>
                       ${this.birim_select(birim)}
                    </div>
                   <div><button class="btn btn-sm btn-outline-danger btn-delete-eylem"><span class="fa fa-trash"></span></button></div>

                </div>
            </div>

           `;
    }

    strateji(no, text, id) {
        return `<div class="stratejiContainer" data-id="${id}">
        <div class="boxed strateji">
            Strateji <span class='no'>${no}</span>  <span class='text'>${text}</span> <button class="float-right btn-add-eylem btn btn-sm btn-primary" title="Eylem Ekle">+</button>
        </div>
        <div class="eylemler">
           
        </div>
    </div>`;
    }



}


class StratejiListItem extends PlanItem {



    Draw() {

        let template = new Eylemler_Templates();

        let $obj = $(template.strateji(this.No, this.Title, this.Id));

        let newItems = [];
        if (this.Items != null)
            for (var i = 0; i < this.Items.length; i++) {
                let item = this.Items[i];

                let newItem = new EylemItem(item.Id, item.Baslik, i + 1, null, '');//item.SiraNo
                newItems.push(newItem);
                newItem.No = item.No;
                let h = newItem.Draw();
                $obj.find(".eylemler").append($(h));
            }

        return $obj;
    }

}

class EylemItem extends PlanItem {

    Birim = "";

    Draw(state) {
        let template = new Eylemler_Templates();
        return template.eylem(this.Id, this.Title, this.No, this.Order, this.State);
    }

}

function reorder(container, target_name) {
    $(container).find(target_name).each(function (b, d) {
        d.innerText = b + 1;
    });
}


class Eylemler extends PlanItem {


    Build(d) {
        for (var i = 0; i < d.Items.length; i++) {
            let item = d.Items[i];
            let newItem = new StratejiListItem(item.Id, item.Baslik, item.SiraNo, item.Items, item.State);
            newItem.No = item.No;
            this.Add(newItem);

        }
    }

    Draw() {
        let $container = $('#stratejiListContainer').empty();
        for (var i = 0; i < this.Items.length; i++) {
            let str = this.Items[i];
            let $obj = str.Draw();
            $container.append($obj);
        }
    }



    Get() {
        let THIS = this;
        api_get("/api/Eylemler/1").done(function (d) {
            console.log(d);
            THIS.Build(d);
            THIS.Draw();
        });
    }

    Post() {
        let THIS = this;

        let data = this.Collect();
        console.log(data);

        api_post("/api/Eylemler", JSON.stringify(data), function (d) {
            successMessage("Kaydedildi.");
        });
    }

    Collect() {

        let data = [];

        let $stratejiler = $('.stratejiContainer');

        $stratejiler.each(function (index, value) {
            let $obj = $(value);
            let id = $obj.data("id");
            $obj.find(".eylem").each(function (x, y) {

                let $eylemObj = $(y);
                let eylemId = $eylemObj.data("id");
                let state = $eylemObj.data("state");
                let eylemNo = $eylemObj.find(".eylem-no").text();
                let text = $eylemObj.find(".eylem-title").text();
                let birim = $eylemObj.find(".birim-select").val();

                data.push({ Id: eylemId, ParentId: id, Baslik: text, State: state, Birim: birim, No: eylemNo });

            })
        });

        return data;

    }

}


var etemp = new Eylemler_Templates();


function on_btnDeleteEylem_click_event() {

    let main_container = $(this).parents('.eylemler')[0];

    let $a = $($(this).parents('.eylem')[0]);
    let id = $a.data("id") ?? 0;
    if (id > 0) {
        $a.hide();
        $a.data("state", "deleted");
    } else
        $($(this).parents('.eylem')[0]).remove();
        

    reorder(main_container, '.eylem:visible .eylem-no');

}

function on_btnAddEylem_click_event() {
    let container = $($(this).parents('.stratejiContainer')[0]).find('.eylemler');
    let c = container.find(".eylem").length;
    container.append(etemp.eylem("", "", c+1, "", ""));

};


function on_btnSaveEylemler_click_event() {

    e.Post();
}

var e = new Eylemler();


$(function () {



    e.Get();

    $(document).on('click', '.btn-add-eylem', on_btnAddEylem_click_event);

    $(document).on('click', '.btn-delete-eylem', on_btnDeleteEylem_click_event);

    $(document).on('click', '.btn-kaydet-eylemler', on_btnSaveEylemler_click_event);

});

