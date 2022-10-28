


function GetDefaultForm() {
    GetDefaoutStyle();
    clear();
}

function GoToOption() {
    window.location.href = '/FeaturesOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/Features/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#stitle").text(json.title);
            $("#scount").text(json.count);
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

// ##########################################

$(document).ready(function () {
    $("#btnTexto").on('click', function () {      
        $.ajax({
            url: '/Features/GetResultTxt',
            data: { term: $("#txtTexto").val() },
            type: 'POST',
            dataType: "json"
        })
        .success(function (json) {
            if (json.FileFound) {
                id = json.id;
                $("#title").val(json.title);               
                $("#icon").val(json.icon);
                $("#count").val(json.count);             
                $("#description").val(json.description);                
                $("#stitle").val(json.stTitle);
                $("#scount").val(json.stCount);
                $("#sdescription").val(json.stDescription);
            }
            else {
                jsonFileNotFound();
            }
        })
        .error(function (xhr, status) {
            alert("Erro na tentativa de busca");
        })
    });
});

//################################################

function Salvar() {
    $.ajax({
        url: '/Features/Salvar',
        data: {
            id: id,
            title: $("#title").val(),           
            icon: $("#icon").val(),
            count: $("#count").val(),      
            description: $("#description").val(),        
            stTitle: toStyle($("#stitle").text()),
            stCount: toStyle($("#scount").text()),
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
            title: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 64 }
                }
            },
            icon: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 32 }
                }
            },
            count: {
                validators: {
                    notEmpty: {},
                    integer: { max: 1000 }
                }
            },
            description: {
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
});