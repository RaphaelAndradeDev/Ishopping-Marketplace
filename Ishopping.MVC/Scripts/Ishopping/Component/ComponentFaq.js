


function GetDefaultForm() {
    GetDefaoutStyle();
    clear();
}

function GoToOption() {
    window.location.href = '/FaqOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/Faq/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#spergunta").text(json.pergunta);
            $("#sresposta").text(json.resposta);
        }
        else {
            jsonFileNotFound();
        }
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de busca");
    });
};

// ##########################################

$(document).ready(function () {
    $(".search").on('click', function () {
        term = $("#txtTexto").val();
        ps = $("#txtPosition").val();
        if (ps === "") { ps = 1 };
        if (ps <= 6) { GetResult(); }
    });
});

function GetResult() {
    $.ajax({
        url: '/Faq/GetResult',
        type: 'POST',
        data: { ps: ps, term: term },
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            id = json.id;
            $("#categoria").val(json.categoria);
            $("#pergunta").val(json.pergunta);         
            $("#resposta").val(json.resposta);
            $("#spergunta").val(json.stPergunta);
            $("#sresposta").val(json.stResposta);
        }
        else {
            jsonFileNotFound(json);
        }
    })
    .error(function (xhr, status) {
        alert("Nenhum resultado encontrado");
    })
};

//################################################      

function Salvar() {
    $.ajax({
        url: '/Faq/Salvar',
        data: {
            id: id,
            ps: setPosition($("#txtPosition").val()),
            categoria: $("#categoria").val(),
            pergunta: $("#pergunta").val(),           
            resposta: $("#resposta").val(),          
            stPergunta: toStyle($("#spergunta").text()),
            stResposta: toStyle($("#sresposta").text())
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
            categoria: {
                validators: {
                    stringLength: { max: 32 }
                }
            },
            pergunta: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 256 }
                }
            },
            resposta: {
                validators: {
                    notEmpty: {},
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