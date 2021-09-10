class Form {

    constructor(modalId) {
        this.modalId = modalId;
        let THIS = this;

        $(document).ready(function () {
            THIS.Validate();
        });

    }

    Clear() {
        $(this.modalId + " form")[0].reset();
        this.ClearInputs();
    }

    ClearInputs() {
        let $form = $(this.modalId + " form");
        $form.find("input,select,textarea").val('');
    }

    Show() {
        $(this.modalId).modal();
    }

    Close() {
        $(this.modalId).modal("hide");
    }

    New() {
        this.Clear();

        this.Show();
    }

    Edit() {
        this.Show();
        return;
    }

    PutValues(data) {
        for (const [key, value] of Object.entries(data)) {
            $(`${this.modalId} [name=${key}]`).val(value);
        }
    }

    GetValues() {
        let data = {};
        let $inputs = $(`${this.modalId}`).find(`input,select,textarea`);

        $inputs.each(function (t, v) {
            data[v.name] = v.value;
        });

        return data;
    }

    Save() {
        return true;
    }

    Validate() {

        let $form = $($(this.modalId + " form")[0]);

        let THIS = this;

        this.Validator = $form.validate({
            rules: {
                faaliyetAdi: {
                    required: true,
                    minlength: 5
                },
            },
            messages: {
                faaliyetAdi: "Faaliyet Adı",

            },
            submitHandler: function (e) {
                if (THIS.Save())
                    THIS.Close();
            }

        });




    }
}