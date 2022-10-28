


function GetDefaultForm() {
    GetDefaoutStyle();
    clear();
}

function GoToOption() {
    window.location.href = '/SkillOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/Skill/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#scategory").text(json.category);
            $("#sdescription").text(json.description);
            $("#slevel").text(json.level);
        }
        else {
            jsonFileNotFound();
        }
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de busca");
    });
};

// Retorna Resultado da Pesquisa ################

$(document).ready(function () {
    $("#btnTexto").on('click', function () {
        ps = $("#txtPosition").val();
        term = $("#txtTexto").val();
        $.ajax({
            url: '/Skill/GetResultTxt',
            data: {ps: ps, term: term },
            type: 'POST',
            dataType: "json"
        })
        .success(function (json) {
            if (json.FileFound) {
                id = (json.Id);
                $("#category").val(json.category);
                $("#level").val(json.level);
                $("#description").val(json.description);
                $("#scategory").val(json.stCategory);
                $("#slevel").val(json.stLevel);
                $("#sdescription").val(json.stDescription);
            }
            else {
                jsonFileNotFound();
            }
        })
        .error(function (xhr, status) {
            $('#Status').html("Erro na tentativa de busca");
        })
    });
});


// Salvar Mudanças ##############################

function Salvar() {    
    $.ajax({
        url: '/Skill/Salvar',
        data: {
            id: id,
            position: setPosition($("#txtPosition").val()),
            category: $("#category").val(),
            level: $("#level").val(),
            description: $("#description").val(),
            stCategory: toStyle($("#scategory").text()),
            stLevel: toStyle($("#slevel").text()),
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
    });
};


// Regras de validação ###########################

$(document).ready(function () {
    $('#defaultForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {
            category: {
                validators: {
                    notEmpty: {},
                    regexp: {
                        regexp: /^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$/,
                        message: 'Apenas letras e números são permitidos'
                    },
                    stringLength: { min: 4, max: 32, message: 'O campo Categoria deve conter entre 4 e 32 digitos' }
                }
            },
            level: {
                validators: {
                    notEmpty: {},
                    between: { min: 1, max: 100 }
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