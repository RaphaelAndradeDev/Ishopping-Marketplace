
$(document).ready(function () {
    var textBtn = $('#TextBtn').data('textbtn');
    $('#TextBtn').val(textBtn.split(","));
    $('.selectpicker').addClass('col-xs-12 col-sm-6  col-md-6 col-lg-6').selectpicker('setStyle');
});

$("#salvar").on('click', function(){
    $.ajax({
        url: '/ButtonOption/Salvar',
        data: {
            TextBtn: toStyle($("#TextBtn").val())
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