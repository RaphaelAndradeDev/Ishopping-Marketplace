


function GetDefaultForm() {
    GetDefaoutStyle();
    clear();
}

function GoToOption() {
    window.location.href = '/BrandOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/Brand/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#smarca").text(json.marca);
            $("#scomment").text(json.comment);
        }
        else {
            jsonFileNotFound();
        }
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de busca");
    });
};


$(document).ready(function () {
    if (id === guidEmpity) {
        GetDefaultForm();
    }
});


//################################################
function Salvar() { 
    $.ajax({
        url: '/Brand/Salvar',
        data: {
            id: id,
            marca: $('#marca').val(),                 
            comment: $('#comment').val(),
            imageFileName: $('#img').val(),
            stMarca: toStyle($('#smarca').text()),
            stComment: toStyle($('#scomment').text())
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
        alert("Erro na tentativa de salvar dados");
    })
};

// Regras de validação ###########################

$(document).ready(function () {
    $('#defaultForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {
            marca: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 64 }
                }
            },
            img: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 32 }
                }
            },
            comment: {
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
