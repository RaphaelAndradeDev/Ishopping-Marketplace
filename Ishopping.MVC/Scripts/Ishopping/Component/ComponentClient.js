


function GetDefaultForm() {
    GetDefaoutStyle();
    clear();
}

function GoToOption() {
    window.location.href = '/ClientOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/Client/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#sname").text(json.name);
            $("#sfunctio").text(json.functio);
            $("#scomment").text(json.comment);
            $("#sproject").text(json.project);
        }
        else {
            jsonFileNotFound();
        }
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de busca");
    });
};

//################################################

function Salvar() {   
    $.ajax({
        url: '/Client/Salvar',
        data: {
            id: id,
            name: $("#name").val(),           
            functio: $("#functio").val(),            
            project: $("#project").val(),          
            comment: $("#comment").val(),          
            site: $("#site").val(),
            imageFileName: $("#img").val(),
            stName: toStyle($("#sname").text()),
            stFunctio: toStyle($("#sfunctio").text()),
            stProject: toStyle($("#sproject").text()),
            stComment: toStyle($("#scomment").text()),
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


$(document).ready(function () {
    if (id === guidEmpity) {
        GetDefaultForm();
    }
});


// Regras de validação ###########################
$(document).ready(function () {
    $('#defaultForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {
            name: {
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
            project: {
                validators: {
                    stringLength: { max: 128 }
                }
            },
            comment: {
                validators: {
                    stringLength: { max: 512 }
                }
            },
            site: {
                validators: {
                    uri: { allowLocal: false }
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