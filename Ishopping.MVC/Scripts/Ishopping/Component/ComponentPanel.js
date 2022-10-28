


function GetDefaultForm() {
    GetDefaoutStyle();
    clear();
}

function GoToOption() {
    window.location.href = '/PanelOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/Panel/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#stitle").text(json.title);
            $("#stext").text(json.text);
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
    $(".btnpesq").on('click', function () {
        term = $("#txtTexto").val();
        ps = $("#txtPosition").val();
        if (ps === "") { ps = 1 };
        if (ps <= 6) { GetResult(); }
    });
});

function GetResult() {
    $.ajax({
        url: '/Panel/GetResultTxt',
        type: 'POST',
        data: { ps: ps, term: term },
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            id = json.id;
            $("#title").val(json.title);
            $("#icon").val(json.icon);
            $("#text").val(json.text);
            $("#stitle").text(json.stTitle);
            $("#stext").text(json.stText);
        }
        else {
            jsonFileNotFound();
        };
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de busca");
    })
};


//################################################

function Salvar() {   
    $.ajax({
        url: '/Panel/Salvar',
        data: {
            id: id,
            position: setPosition($("#txtPosition").val()),
            title: $("#title").val(),
            icon: $("#icon").val(),
            text: $("#text").val(),
            stTitle: toStyle($("#stitle").text()),         
            stText: toStyle($("#stext").text())
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
            title: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 64 }
                }
            },
            icon: {
                validators: {
                    stringLength: { max: 32 }
                }
            },
            text: {
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