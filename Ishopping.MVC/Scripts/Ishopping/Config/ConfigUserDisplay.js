

 function Salvar() {
    $.ajax({
        url: '/Card/Salvar',
        data: {
            id: $('#id').text(),
            title: $('#title').val(),
            imageFileName: $('#img').val(),
            message: $('#description').val()
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
    $('#defaultForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {
            title: {
                validators: {
                    notEmpty: {},
                    stringLength: { min: 1, max: 32 }
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
                    stringLength: { max: 128 }
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