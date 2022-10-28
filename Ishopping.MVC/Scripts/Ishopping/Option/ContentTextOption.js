
$(document).ready(function () {
    var text32 = $('#Text32').data('text32');
    $('#Text32').val(text32.split(","));

    var text512 = $('#Text512').data('text512');
    $('#Text512').val(text512.split(","));

    var text5120 = $('#Text5120').data('text5120');
    $('#Text5120').val(text5120.split(","));

    $('.selectpicker').addClass('col-xs-12 col-sm-6  col-md-6 col-lg-6').selectpicker('setStyle');
});

$("#salvar").on('click', function(){
    $.ajax({
        url: '/TextOption/Salvar',
        data: {
            text32: toStyle($("#Text32").val()),
            text512: toStyle($("#Text512").val()),
            text5120: toStyle($("#Text5120").val())
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
});