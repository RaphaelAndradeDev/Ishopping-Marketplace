


function GetDefaultForm() {
    GetDefaoutStyle();
    clear();
}

function GoToOption() {
    window.location.href = '/MenuOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/Menu/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#stitle").text(json.title);
            $("#sdescription").text(json.description);
            $("#sprice").text(json.price);
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
        url: '/Menu/Salvar',
        data: {
            id: id,
            title: $("#title").val(),
            imageFileName: $("#img").val(),
            price: $("#price").val(),
            description: $("#description").val(),
            category: $("#category").val(),
            isDynamic: $("#ativo").prop('checked'),
            dayOfWeek: $("#dayOfWeek").val(),
            stTitle: toStyle($("#stitle").text()),
            stDescription: toStyle($("#sdescription").text()),
            stPrice: toStyle($("#sprice").text())
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
            title: {
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
            description: {
                validators: {
                    stringLength: { max: 512 }
                }
            },
            category: {
                validators: {
                    notEmpty: {},
                    regexp: {
                        regexp: /^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$/,
                        message: 'Apenas letras e números são permitidos'
                    },
                    stringLength: { min: 4, max: 64, message: 'O campo Categoria deve conter entre 4 e 64 digitos' }
                }
            },
            price: {
                validators: {
                    stringLength: { max: 12 }
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