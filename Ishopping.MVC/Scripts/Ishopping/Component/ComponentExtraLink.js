


function GetDefaultForm() {
    GetDefaoutStyle();
    clear();
}

function GoToOption() {
    window.location.href = '/ExtraLinkOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/ExtraLink/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {           
            $("#sdescription").text(json.description);
            $("#stextLink").text(json.textLink);
        }
        else {
            jsonFileNotFound();
        }
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de busca");
    });
};

// Retorna Resultado da Pesquisa (por titulo) ################

$(document).ready(function () {
    $("#btnTexto").on('click', function () {      
        $.ajax({
            url: '/ExtraLink/GetResultTxt',
            data: { term: $("#txtTexto").val() },
            type: 'POST',
            dataType: "json"
        })
        .success(function (json) {
            if (json.FileFound) {
                id = json.id;
                $("#link").val(json.link);
                $("#textLink").val(json.textLink);              
                $("#description").val(json.description);
                $("#stextLink").val(json.stTextLink);
                $("#sdescription").val(json.stDescription);
            }
            else {
                jsonFileNotFound();
            }
        })
        .error(function (xhr, status) {
            alert("Nenhum resultado encontrado");
        })
    });
});


// Salvar Mudanças ##############################

function Salvar() {  
    $.ajax({
        url: '/ExtraLink/Salvar',
        data: {
            id: id,
            link : $("#link").val(),
            textLink: $("#textLink").val(),            
            description: $("#description").val(),           
            stTextLink: toStyle($("#stextLink").text()),
            stDescription: toStyle($("#sdescription").text())
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
    })
};


// Regras de validação ###########################

$(document).ready(function () {
    $('#defaultForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {
            link: {
                validators: {
                    notEmpty: {},
                    uri: { allowLocal: true }
                }
            },
            txtLink: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 128 }
                }
            },
            description: {
                validators: {
                    stringLength: { max: 512 }
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
});