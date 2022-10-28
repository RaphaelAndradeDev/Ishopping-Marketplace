


var viewName, partialView;

function Salvar() {

    viewName = $("#viewName").text();
    partialView = $("#viewName").attr("name");

    if (viewName !== "Selecione uma view") {
        $.ajax({
            url: '/Maintenance/Salvar',
            data: {
                title: $("#title").val(),
                message: $("#message").val(),
                dateReturn: $("#date").val(),
                viewName: viewName,
                partialView: partialView,
                isMaintenance: $("#ativo").prop('checked')
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
    }
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
            date: {
                validators: {
                    date: {
                        format: 'DD/MM/YYYY h:m'
                    }
                }
            },
            message: {
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

    $('#datetimePicker')
    .on('dp.change dp.show', function (e) {
        // Validate the date when user change it
        $('#defaultForm')
         // Get the bootstrapValidator instance
         .data('bootstrapValidator')
         // Mark the field as not validated, so it'll be re-validated when the user change date
         .updateStatus('date', 'NOT_VALIDATED', null)
         // Validate the field
         .validateField('date');
    });
});


// ###########################################
$(function () {
    $('#datetimePicker').datetimepicker({
        locale: 'pt-BR'
    });
});


// ##################################
$(document).ready(function () {
    $('.dropdown-toggle').dropdown();
    $(".dropdown-menu li a").click(function () {
        viewName = $(this).text();
        partialView = $(this).attr('name');
        $(this).parents('.btn-group').find('.views').text(viewName);
    });
});