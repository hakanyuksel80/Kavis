class strateji_templates {

    constructor() {

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

    performans_satir() {

        return `<tr>
                <td>P.G.1.1.1</td>
                <td contenteditable="true">Performans G.1</td>
                <td contenteditable="true"></td>
                <td contenteditable="true"></td>
                <td contenteditable="true"></td>
                <td contenteditable="true"></td>
                <td contenteditable="true"></td>
                <td contenteditable="true"></td>
                <td contenteditable="true"></td>
                <td>
                    ${this.period_list()}
                </td>
                <td>
                    ${this.period_list()}
                </td>
                <td>
                    ${this.birim_list()}
                </td>
                <td>
                    <button class="btn btn-sm btn-delete" data-target="performans"><span class="fa fa-trash"></span></button>
                </td>

            </tr>`;
    }

    strateji_satir(n = 1, text = '') {
        return `<tr>
                    <td><span class="strateji-item">${n}.</span>${text}</td>
                    <td style='width:10%'><button class="btn btn-sm btn-delete" data-target="strateji"><span class="fa fa-trash"></span></button></td>
                </tr>`;
    }

    hedef_karti(i, baslik) {

        return `<div class="hedefKarti card">
                            <div class="card-header">
                                Hedef ${i}. ${baslik}  
                                <div class="float-right toolbar">
                                    <button class="btn btn-sm"><span class="fa fa-pencil"></span></button>
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
                                    <tbody>
                                        ${this.performans_satir()}
                                    </tbody>
                                </table>
                                <div class="text-center"><button class="text-center btn-add btn-add-performans" data-target="performans">Performans Göstergesi Ekle</button></div>
                                <br />
                                <table class="table table-sm table-bordered">
                                    <tr>
                                        <td rowspan="50" width="150" style="vertical-align:middle;">STRATEJİLER</td>

                                    </tr>
                                    ${this.strateji_satir()}
                                </table>
                                <div class="text-center"><button class="text-center btn-add btn-add-strateji">Strateji Ekle</button></div>
                                <br />
                            </div>
                        </div>`;
    }

    amac_panel_baslik(i, text = '') {

        return `<div class="card-header" id="panelHeaderAmac${i}">
                <div class="float-left" style="width:93%">
                    <h2 class="mb-0">
                        <button class="btn btn-link text-left" type="button" data-toggle="collapse" data-target="#collapseAmac_${i}" aria-expanded="true" aria-controls="collapseAmac@i">
                            AMAÇ : ${i + 1}. ${text}
                        </button>
                    </h2>
                </div>
                <div class="float-left" style='border:solids 1px black;width:7%;min-width:7%;'>
                    <button class="btn btn-sm btn-edit" data-target="amac"><span class="fa fa-pencil"></span></button>
                    <button class="btn btn-sm btn-delete" data-target="amac"><span class="fa fa-trash"></span></button>
                </div>
                
                
            </div>`;
    }

    amac_panel_content(i, content = '') {

        return ` <div id="collapseAmac_${i}" class="collapse" aria-labelledby="heading@i" data-parent="#accordionSP">
                <div class="card-body">
                    <div class="amac-content">
                       ${content}
                    </div>
                    <div class="text-center"><button class="text-center btn-add btn-add-hedef">Hedef Ekle</button></div>

                    <br />
                </div>
            </div>`;

    }
}

