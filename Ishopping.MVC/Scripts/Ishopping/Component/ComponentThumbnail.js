

function GetDefaultForm() {
    clear();
}


function Salvar() {   
    $.ajax({
        url: '/Thumbnail/Salvar',
        data: {
            id: id,
            icon: $('#icon').val(),
            category: $('#category').val(),
            webSite: $('#webSite').val(),
            imageFileName: $('#img').val()
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
            img: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 32 }
                }
            },
            icon: {
                validators: {
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
            webSite: {
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