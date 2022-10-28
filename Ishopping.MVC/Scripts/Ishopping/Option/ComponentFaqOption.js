
$(document).ready(function () {
    var pergunta = $('#Pergunta').data('pergunta');
    $('#Pergunta').val(pergunta.split(","));

    var resposta = $('#Resposta').data('resposta');
    $('#Resposta').val(resposta.split(","));

    $('.selectpicker').addClass('col-xs-12 col-sm-6  col-md-6 col-lg-6').selectpicker('setStyle');
});

function Salvar() {
    $.ajax({
        url: '/FaqOption/Salvar',
        data: {
            textView: $("#titleView").val(),
            styleTextView: toStyle($("#stitleView").text()),
            subTitleView: $("#subtitleView").val(),
            styleSubTitleView: toStyle($("#ssubtitleView").text()),
            pergunta: toStyle($("#Pergunta").val()),
            resposta: toStyle($("#Resposta").val())
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