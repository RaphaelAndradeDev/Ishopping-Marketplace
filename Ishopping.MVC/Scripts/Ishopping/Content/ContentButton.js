

function GetDefaultForm() {
    clear();
    GetDefaoutStyle();
    $("#position").val(ps);    
}

function GoToOption() {
    window.location.href = '/ButtonOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/Button/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#stextBtn").text(json.textBtn);            
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
        url: '/Button/GetResultPs',        
        data: { viewCod: viewCod, ps: ps },
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            id = json.id;        
            $("#textBtn").val(json.textBtn);
            $("#textUrl").val(json.textUrl);
            $("#stextBtn").text(json.stTextBtn);
            isValueNullOrEmpty(json.textBtn);
        }
        else {
            jsonFileNotFound(json);           
        }
        enableForm(ps);
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de salvar dados");
    })
};


function GetText() {
    term = $("#txtTexto").val();
    $.ajax({
        url: '/Button/GetResultTxt',       
        data: { viewCod: viewCod, term: term },
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            id = json.id;
            enableForm(json.position);
            $("#textBtn").val(json.textBtn);
            $("#textUrl").val(json.textUrl);
            $("#stextBtn").text(json.stTextBtn);
            isValueNullOrEmpty(json.textBtn);
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
        url: '/Button/Salvar',
        data: {
            id: id,
            viewCod: viewCod,
            position: $("#position").val(),
            textBtn: $("#textBtn").val(),
            textUrl: $("#textUrl").val(),
            stTextBtn: toStyle($("#stextBtn").text()),
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


// Regras de validação ###########################

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
            textBtn: {
                validators: {                    
                    stringLength: { max: 64 }
                }
            },
            textUrl: {
                validators: {
                    uri: {
                        allowLocal: true,
                        message: 'A URL inserida não é valida'
                    }
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

