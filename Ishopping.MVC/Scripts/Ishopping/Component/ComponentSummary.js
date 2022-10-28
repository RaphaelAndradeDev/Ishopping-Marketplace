


function GetDefaultForm() {
    GetDefaoutStyle();
    clear();
}

function GoToOption() {
    window.location.href = '/SummaryOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/Summary/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#stitle").text(json.title);
            $("#scategory").text(json.category);
            $("#sdescription").text(json.description);
        }
        else {
            jsonFileNotFound();
        }
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de busca");
    });
};

// Retorna Resultado da Pesquisa ( por uma posição e um titulo) ################
$(document).ready(function () {
    $(".pesq").on('click', function () {
        ps = $("#txtPosition").val();
        term = $("#txtTexto").val();
        $.ajax({
            url: '/Summary/GetResultTxt',
            data: { ps: ps, term: term },
            type: 'POST',
            dataType: "json"
        })
        .success(function (json) {
            if (json.FileFound) {
                id = json.id;
                $("#title").val(json.title);
                $("#category").val(json.category);
                $("#description").val(json.description);
                $("#stitle").text(json.stTitle);
                $("#scategory").text(json.stCategory);
                $("#sdescription").text(json.stDescription);
            }
            else {                
                jsonFileNotFound();
            }
        })
        .error(function (xhr, status) {               
            $('#Status').html("Erro na tentativa de busca");
        });
    });
});

// Salvar Mudanças ##############################

function Salvar() {    
    $.ajax({
        url: '/Summary/Salvar',
        data: {
            id: id,
            position: setPosition($("#txtPosition").val()),
            title: $("#title").val(),
            category: $("#category").val(),
            description: $("#description").val(),
            stTitle: toStyle($("#stitle").text()),
            stCategory: toStyle($("#scategory").text()),
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
            title: {
                validators: {
                    notEmpty: {},
                    stringLength: { min: 1, max: 64 }
                }
            },
            category: {
                validators: {
                    stringLength: { max: 32 }
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