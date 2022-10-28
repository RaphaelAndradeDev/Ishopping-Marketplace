


function GetDefaultForm()
{  
    clear(); 
    GetDefaoutStyle();
    $("#position").val(ps);
}

function GoToOption() {
    window.location.href = '/TextOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/Text/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#stext32").text(json.text32);
            $("#stext512").text(json.text512);
            $("#stext5120").text(json.text5120);
        }
        else {
            jsonFileNotFound();
        }
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de busca");
    });
};


function disableFields(p) {
    $(".texto").prop('disabled', true);
    var dis = list[p - 1];
    switch (dis) {
        case 1:
            $("#text32").prop('disabled', false);
            break;
        case 2:
            $("#text512").prop('disabled', false);
            break;
        case 3:
            $("#text5120").prop('disabled', false);
            break;
    }
    $(".sub").prop('disabled', false);
    $("#position").val(p);
}


function GetPosition() {
    $.ajax({
        url: '/Text/GetResultPs',
        type: 'POST',
        data: { viewCod: viewCod, ps: ps },
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            id = json.id;            
            $("#text32").val(json.text32);
            $("#text512").val(json.text512);
            $("#text5120").val(json.text5120);
            $("#stext32").text(json.stText32);
            $("#stext512").text(json.stText512);
            $("#stext5120").text(json.stText5120);
            isValueNullOrEmpty(json.text32, json.text512, json.text5120);
        }
        else {
            jsonFileNotFound(json);
        };
        disableFields(ps);
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de salvar dados");
    })
};


function GetText() { 
    $.ajax({
        url: '/Text/GetResultTxt',
        data: {
            viewCod: viewCod,
            term: $("#txtTexto").val()
        },
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            id = json.id;
            disableFields(json.position);
            $("#text32").val(json.text32);
            $("#text512").val(json.text512);
            $("#text5120").val(json.text5120);
            $("#stext32").text(json.stText32);
            $("#stext512").text(json.stText512);
            $("#stext5120").text(json.stText5120);            
        }
        else {
            jsonFileNotFound(json);
        }
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de salvar dados");
    })
};


function Salvar() {
    view = $(".views").text();
    if (view === "Selecione uma view") { return false; }    
    $.ajax({
        url: '/Text/Salvar',
        data: {
            id: id,
            viewCod: viewCod,
            position: $("#position").val(),
            text32: $("#text32").val(),
            text512: $("#text512").val(),
            text5120: $("#text5120").val(),
            stText32: toStyle($("#stext32").text()),
            stText512: toStyle($("#stext512").text()),
            stText5120: toStyle($("#stext5120").text())
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
                    notEmpty: {},
                    between: { min: 1, max: nps }
                }
            },
            text32: {
                validators: {                  
                    stringLength: { max: 64 }
                }
            },
            text512: {
                validators: {              
                    stringLength: { max: 512 }
                }
            },
            text5120: {
                validators: {                 
                    stringLength: { max: 5120 }
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

