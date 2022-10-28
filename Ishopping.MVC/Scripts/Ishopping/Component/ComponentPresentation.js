


function GetDefaultForm() {
    GetDefaoutStyle();
    clear();
}

function GoToOption() {
    window.location.href = '/PresentationOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/Presentation/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#stitle").text(json.title);
            $("#sdescription").text(json.description);
            $("#scategory").text(json.category);
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
        url: '/Presentation/Salvar',
        data: {
            id: id,
            position: setPosition($('#txtPosition').val()),
            title: $('#title').val(),
            category: $('#category').val(),
            icon: $('#icon').val(),
            imageFileName: $('#img').val(),
            description: $('#description').val(),
            stTitle: toStyle($('#stitle').text()),
            stCategory: toStyle($('#scategory').text()),
            stDescription: toStyle($('#sdescription').text())
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
            img: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 32 }
                }
            },
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