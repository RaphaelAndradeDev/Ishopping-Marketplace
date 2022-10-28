

var id;
var token = $('[name=__RequestVerificationToken]').val();

$('input, button, textarea').on('change, click', function () {
    $("#Status").fadeOut(500);
});

// Início ###############################
$(document).ready(function () {    

    $('[name="colorPicker"]')
     .colorpicker()
     .on('showPicker changeColor', function (e) {
         $('#defaultForm').bootstrapValidator('revalidateField', 'UserColor');
     });

});

$("#hideDefault").click(function () {
    $('.defaultColor').toggle();
});

// ##########################################

$("#Restaurar").on('click', function () {
    GetAparencia();
});

function GetAparencia() {
    $.ajax({
        url: '/Appearance/GetAparencia',
        type: 'POST',
        dataType: "json"
    })
    .success(function (data) {
        if (data === "reload") {
            location.reload();
        }
        else {
            $('#Status').html("Erro na tentativa de restaurar padrão");
            $('#Status').fadeIn(500);
        }
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de restaurar padrão");
        $('#Status').fadeIn(500);
    })
};


// Salva mudanças
 function Salvar() {
     var form = $('#defaultForm'),
        url = form.attr('action'),
        type = form.attr('method');

    var userColor = [];
    $("[name=UserColor]").each(function (index, value) {
        userColor[index] = $(this).val();
    });

    id = $("#Id").val();
    userColorSerialize = JSON.stringify(userColor);
    $.ajax({
        url: url,
        data: { id: id, data: userColorSerialize },
        type: type,
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

    var hex = new RegExp(/^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$/gm);
    var rgba = new RegExp(/^rgba\((\d{1,3}),\s*(\d{1,3}),\s*(\d{1,3}),\s*(\d*(?:\.\d+)?)\)$/);
    var color = new RegExp(hex.source + "|" + rgba.source);

    $('#defaultForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {      
            UserColor: {
                validators: {
                    regexp: {
                        regexp: color,
                        message: 'Cor inválida'
                    }
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