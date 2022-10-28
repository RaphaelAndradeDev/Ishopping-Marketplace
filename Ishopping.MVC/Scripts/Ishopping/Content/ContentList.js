


function GetDefaultForm() {
    clear();
    GetDefaoutStyle();
    $("#position").val(ps);
}

function GoToOption() {
    window.location.href = '/ListOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/List/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#stlista").text(json.lista);   
        }
        else {
            jsonFileNotFound();
        }
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de busca");
    });
};


function GetPosition() {
    $.ajax({
        url: '/List/GetResultPs',
        type: 'POST',
        data: { viewCod: viewCod, ps: ps },
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            id = json.id;           
            $("#lista").val(json.lista);
            isValueNullOrEmpty(json.lista);
        }
        else {
            jsonFileNotFound(json);
        };
        enableForm(ps);
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de salvar dados");
    })
};


function Salvar() {
    view = $(".views").text();
    if (view === "Selecione uma view") { return false; }    
    $.ajax({
        url: '/List/Salvar',
        data: {
            id: id,
            viewCod: viewCod,
            position: $("#position").val(),
            lista: $("#lista").val(),
            stLista: toStyle($("#slista").text())
        },
        type: 'POST',
        cache: false,
        headers: { "__RequestVerificationToken": token },
        dataType: "json"
    })
    .success(function (json) {
        jsonSuccess(json);
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de salvar dados");
    });
};


function validar() {
    $('#defaultForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {
            position: {
                validators: {
                    between: { min: 1, max: nps }
                }
            },
            lista: {
                validators: {              
                    stringLength: { max: 256 }
                }
            }
        }
    })
       .on('success.form.bv', function (e) {
           // Prevent form submission
           e.preventDefault();
           // Get the form instance
           var $form = $(e.target);
           // Get the BootstrapValidator instance
           var bv = $form.data('bootstrapValidator');
           // Call action save
           Salvar();
       });
};