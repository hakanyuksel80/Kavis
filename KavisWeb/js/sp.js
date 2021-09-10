
class PlanItem {

    constructor(id, title, siraNo, items = [], state="") {
        this.Id = id;

        this.SiraNo = siraNo;

        this.Title = title;

        this.Items = items;

        this.State = state;
    }

    Id = 0;

    Order = 0;

    No = "";

    Title = "";

    State = "";

    Items = [];

    Add(item) {
        this.Items.push(item);
    }

    Remove(item) {
        //this.Items.pop(item);
        item.deleted = true;
    }

    GetItem(index) {
        return this.Items[index];
    }

    Draw(container) {

    }

    Build(data_list) {
        return;
    }

    Collect(data) {
        for (var i = 0; i < this.Items.length; i++) {
            const item = this.Items[i];
            item.Collect();
        }
    }

}

class AmacPlanItem extends PlanItem {

    Draw(state = "") {

        let $obj = $(`<div class="card" data-id="${this.Id}"  data-state="${state}"></div>`);

        let $obj1 = $(this.amac_panel_baslik(this.SiraNo, this.Title));

        let $obj2 = $(this.amac_panel_content(this.SiraNo));

        for (var i = 0; i < this.Items.length; i++) {
            $obj2.find('.amac-content').append(this.Items[i].Draw());
        }

        $obj.append($obj1);

        $obj.append($obj2);

        //$(element).parent().prev().append($obj);
        //$(container).append($obj);



        //$obj1.slideDown();

        this.obj = $obj;

        return $obj;
    }

    amac_panel_baslik(i, text = '') {

        return `<div class="card-header" id="panelHeaderAmac${i}" data-id="${id}">
                <div class="float-left" style="width:93%">
                    <h2 class="mb-0">
                        <button class="btn btn-link text-left" type="button" data-toggle="collapse" data-target="#collapseAmac_${i}" aria-expanded="true" aria-controls="collapseAmac@i">
                            AMAÇ : <span class="amac-order">${i + 1}</span>. <span class="amac-title">${text}</span>
                        </button>
                    </h2>
                </div>
                <div class="float-left" style='border:solids 1px black;width:7%;min-width:7%;'>
                    <button class="btn btn-sm btn-edit" data-target="amac"><span class="fa fa-pencil"></span></button>
                    <button class="btn btn-sm btn-delete" data-target="amac"><span class="fa fa-trash"></span></button>
                </div>
                
                
            </div>`;
    }

    amac_panel_content(i) {

        return ` <div id="collapseAmac_${i}" class="collapse" aria-labelledby="heading@i" data-parent="#accordionSP">
                <div class="card-body">
                    <div class="amac-content">
                     
                    </div>
                    <div class="text-center"><button class="text-center btn-add btn-add-hedef">Hedef Ekle</button></div>

                    <br />
                </div>
            </div>`;

    }

    Build(data) {

        if (data.Hedefler != undefined)
            for (var i = 0; i < data.Hedefler.length; i++) {
                const item = data.Hedefler[i];
                let planItem = new HedefPlanItem(item.Id, item.Baslik, item.SiraNo);
                this.Add(planItem);
                planItem.Build(item);

            }

    }

    Collect() {
        let id = this.obj.data("id");
        let text = this.obj.find(".amac-title").text();
        let state = this.obj.data("state");
        //console.log("Amac:" + text);
        let hedef_data = new Array();

        for (var i = 0; i < this.Items.length; i++) {
            const item = this.Items[i];
            hedef_data.push(item.Collect());
        }

        return { Id: id, Baslik: text, Hedefler: hedef_data, State: state };
    }

}

class HedefPlanItem extends PlanItem {

    Stratejiler = [];

    Gostergeler = [];

    AddStrateji(item) {
        this.Stratejiler.push(item);
        console.log(this);
    }

    RemoveStrateji(item) {
        this.Stratejiler.Remove(item);
    }

    GetStrateji(index) {
        return this.Stratejiler[index];
    }

    AddGosterge(item) {
        this.Gostergeler.push(item);
    }

    RemoveGosterge(item) {
        this.Gostergeler.Remove(item);
    }

    GetGosterge(index) {
        return this.Gostergeler[index];
    }

    Draw(state = '') {


        let $obj = $(this.hedef_karti(this.Id, this.SiraNo, this.Title, state));

        let $str = $($obj.find(".stratejiler")[0]);



        let $gos = $obj.find(".gostergeler");

        for (var i = 0; i < this.Stratejiler.length; i++) {
            const item = this.Stratejiler[i];
            $str.append(item.Draw());
        }

        for (var i = 0; i < this.Gostergeler.length; i++) {
            const item = this.Gostergeler[i];
            $gos.append(item.Draw());
        }

        this.obj = $obj;
        console.log($obj);
        return $obj;
    }

    hedef_karti(i, siraNo, baslik, state = '') {

        return `<div class="hedefKarti card" data-id="${i}" data-state="${state}">
                            <div class="card-header">
                                Hedef <span class="hedef-order">${siraNo}</span>. <span class="hedef-title" contenteditable="true">${baslik}</span>
                                <div class="float-right toolbar">                                   
                                    <button class="btn btn-sm btn-delete" data-target="hedef"><span class="fa fa-trash"></span></button>
                                </div>
                            </div>
                            <div class="card-body">

                                <h6>PERFORMANS GÖSTERGELERİ</h6>

                                <table class="table table-bordered table-dar performans-gosterge">
                                    <thead>
                                        <tr>
                                            <th>No</th>
                                            <th width="150">&nbsp;</th>

                                            <th>Hedef Etkisi</th>
                                            <th>Başlangıç</th>
                                            <th>2019</th>
                                            <th>2020</th>
                                            <th>2021</th>
                                            <th>2022</th>
                                            <th>2023</th>
                                            <th>İzleme<br />Sıklığı</th>
                                            <th>Rapor<br />Sıklığı</th>
                                            <th>Sorumlu Birim</th>
                                        </tr>
                                    </thead>
                                    <tbody class="gostergeler">
                                       
                                    </tbody>
                                </table>
                                <div class="text-center"><button class="text-center btn-add btn-add-performans" data-target="performans">Performans Göstergesi Ekle</button></div>
                                <br />
                                <table class="table table-sm table-bordered">
                                    <tbody class="stratejiler">
                                    <tr>
                                        <td rowspan="50" width="150" style="vertical-align:middle;">STRATEJİLER</td>
                                    </tr>
                                   </tbody>
                                </table>
                                <div class="text-center"><button class="text-center btn-add btn-add-strateji">Strateji Ekle</button></div>
                                <br />
                            </div>
                        </div>`;
    }

    Build(data) {

        this.buildStratejiler(data);

        this.buildGostergeler(data);

    }

    buildStratejiler(data) {
        if (data.Stratejiler != undefined)
            for (var i = 0; i < data.Stratejiler.length; i++) {
                const item = data.Stratejiler[i];
                let planItem = new StratejiPlanItem(item.Id, item.Baslik, i + 1);
                this.AddStrateji(planItem);
                planItem.Build(item);

            }
    }

    buildGostergeler(data) {
        if (data.Gostergeler != undefined)
            for (var i = 0; i < data.Gostergeler.length; i++) {
                const item = data.Gostergeler[i];
                let planItem = new GostergePlanItem(item);
                this.AddGosterge(planItem);
                planItem.Build(item);

            }
    }


    Collect(data) {

        let id = this.obj.data("id");
        let text = this.obj.find(".hedef-title").text();
        let state = this.obj.data('state');

        let gosterge_data = new Array();
        let strateji_data = new Array();



        for (var i = 0; i < this.Gostergeler.length; i++) {
            const item = this.Gostergeler[i];
            let d = item.Collect();
            gosterge_data.push(d);
        }

        for (var i = 0; i < this.Stratejiler.length; i++) {
            const item = this.Stratejiler[i];
            let d = item.Collect();
            strateji_data.push(d);
        }

        let hedef_data = { Id: id, Baslik: text, Gostergeler: gosterge_data, Stratejiler: strateji_data, State: state };

        return hedef_data;
    }
}

class StratejiPlanItem extends PlanItem {

    Add(item) {
        return;
    }

    Remove(item) {
        return;
    }

    GetItem(index) {
        return null;
    }

    Draw(state) {
        let obj = $(this.strateji_satir(this.Id, this.SiraNo, this.Title, state));
        this.obj = obj;
        return obj;
    }

    strateji_satir(id, siraNo = 1, text = '', state = '') {
        text = text ?? "&nbsp;";
        return `<tr data-id="${id}" data-state="${state}">
                    <td><span class="strateji-order">${siraNo}</span>. <span class="strateji-title" style="width:100%" contenteditable="true">${text}</span></td>
                    <td style='width:10%'><button class="btn btn-sm btn-delete" data-target="strateji"><span class="fa fa-trash"></span></button></td>
                </tr>`;
    }

    Collect() {
        let id = this.obj.data("id");
        let text = this.obj.find(".strateji-title").text();

        let d = { Id: id, Baslik: text };

        return d;
    }

}

class GostergePlanItem extends PlanItem {

    data = {

    }

    constructor(data) {
        super(data.Id, data.Baslik, data.SiraNo);
        this.data = data;
        
    }

    Add(item) {
        return;
    }

    Remove(item) {
        return;
    }

    GetItem(index) {
        return null;
    }

    Draw() {
        let $obj = $(this.performans_satir(this.data));
        this.obj = $obj;
        return $obj;
    }

    performans_satir(data) {

        return `<tr data-id='${this.Id}'>
                <td>P.G.<span class="gosterge-order"  contenteditable="true">${data.PGNo??""}</span></td>
                <td contenteditable="true" class="gosterge-title">${this.Title}</td>
                <td contenteditable="true">${data.Etkisi ?? ""}</td>
                <td contenteditable="true">${data.Baslangic ?? ""}</td>
                <td contenteditable="true">${data.Yil1 ?? ""}</td>
                <td contenteditable="true">${data.Yil2 ?? ""}</td>
                <td contenteditable="true">${data.Yil3 ?? ""}</td>
                <td contenteditable="true">${data.Yil4 ?? ""}</td>
                <td contenteditable="true">${data.Yil5 ?? ""}</td>
                
                <td>
                    ${this.period_list(data.IzlemeSikligi)}
                </td>
                <td>
                    ${this.period_list(data.RaporSikligi)}
                </td>
                <td>
                   ${this.birim_list(data.Birim)}
                </td>
                <td>
                    <button class="btn btn-sm btn-delete" data-target="performans"><span class="fa fa-trash"></span></button>
                </td>

            </tr>`;
    }

    period_list() {
        return `<select class="select-mini">
                        <option></option>
                        <option>6 Ay</option>
                        <option>1 Yıl</option>
                    </select>`;
    }

    birim_list() {
        return `<select class="select-mini">
                        <option></option>
                        <option>TEMEL EĞİTİM</option>
                        <option>ORTA ÖĞRETİM</option>
                    </select>`;
    }

    Collect() {
        let id = this.obj.data("id");
        let text = this.obj.find(".gosterge-title").text();
        let fields = this.obj.children();
        let hedefeEtkisi = fields[2].innerText;
        let baslangic = fields[3].innerText;
        let yil1 = fields[4].innerText;
        let yil2 = fields[5].innerText;
        let yil3 = fields[6].innerText;
        let yil4 = fields[7].innerText;
        let yil5 = fields[8].innerText;
        let izlemeSikligi = $(fields[9]).find("select").val();
        let raporSikligi = $(fields[10]).find("select").val();
        let birim = $(fields[11]).find("select").val();

        let d = { Id: this.Id, Baslik: text, Baslangic: baslangic, HedefeEtkisi: hedefeEtkisi, Yil1: yil1, Yil2: yil2, Yil3: yil3, Yil4: yil4, Yil5: yil5, IzlemeSikligi: izlemeSikligi, RaporSikligi: raporSikligi, Birim: birim };

        return d;
    }
}

class StratejikPlanItem extends PlanItem {

    constructor(data) {
        if (data != undefined) {
            super(data.Id, data.Baslik);
            this.Build(data);
            this.Draw("#accordionSP");
        } else {
            super(0, "");
        }
    }

    Build(data) {

        for (var i = 0; i < data.Amaclar.length; i++) {
            const amac_data = data.Amaclar[i];
            let amac = new AmacPlanItem(amac_data.Id, amac_data.Baslik, i);
            this.Add(amac);
            amac.Build(amac_data);
        }

    }

    Draw(container) {

        for (var i = 0; i < this.Items.length; i++) {
            const item = this.Items[i];
            let obj = item.Draw();
            this.obj = obj;
            $(container).append(obj);
        }

    }


    Collect(container) {

        let amac_data = [];

        for (var i = 0; i < this.Items.length; i++) {
            const item = this.Items[i];
            amac_data.push(item.Collect());
        }

        return { Id: 0, Baslik: "Deneme", Amaclar: amac_data };
    }

    Get() {
        let THIS = this;
        api_get("/api/StratejikPlan/1").done(function (d) {
            console.log(d);
            THIS.Build(d);
            THIS.Draw("#accordionSP");
        });
    }

    Post() {
        let THIS = this;

        let data = this.Collect();

        api_post("/api/StratejikPlan", data).done(function (d) {



        });
    }

}



