
$(document).ready(function () {
    var autor = $('#Autor').data('autor');
    $('#Autor').val(autor.split(","));

    var category = $('#Categoria').data('categoria');
    $('#Categoria').val(category.split(","));

    var title = $('#Titulo').data('titulo');
    $('#Titulo').val(title.split(","));

    var subtitle = $('#SubTitulo').data('subtitulo');
    $('#SubTitulo').val(subtitle.split(","));

    var paragraph = $('#Paragrafo').data('paragrafo');
    $('#Paragrafo').val(paragraph.split(","));

    $('.selectpicker').addClass('col-xs-12 col-sm-6  col-md-6 col-lg-6').selectpicker('setStyle');
});

function Salvar() {
    $.ajax({
        url: '/PostOption/Salvar',
        data: {
            textView: $("#titleView").val(),
            styleTextView: toStyle($("#stitleView").text()),
            subTitleView: $("#subtitleView").val(),
            styleSubTitleView: toStyle($("#ssubtitleView").text()),
            autor: toStyle($("#Autor").val()),
            categoria: toStyle($("#Categoria").val()),
            titulo: toStyle($("#Titulo").val()),
            subTitulo: toStyle($("#SubTitulo").val()),
            paragrafo: toStyle($("#Paragrafo").val())
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
            titleView: {
                validators: {
                    stringLength: { max: 100 }
                }
            },
            subtitleView: {
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