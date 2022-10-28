
var token = $('[name=__RequestVerificationToken]').val();

$(".form-control").on('change', function () {
    $("#Status").fadeOut(500);
});

// ##########################################

$(".Salvar").on('click', function () {

    var id = $(this).attr('id');
    var ativo = $("#a_" + id).prop('checked');
    var viewCod = $("#n_" + id).val();
    var textMenu = $("#t_" + id).val();        

    if (textMenu.length > 24) {
        $('#Status').html('<strong>texto do menu não deve ultrapassar 24 caracteres</strong>');
        $('#Status').fadeIn(500);
        return false;
    }

    if (ativo === undefined) ativo = true;
    Salvar(id, ativo, viewCod, textMenu);
});

function Salvar(id, ativo, viewCod, textMenu) {   
    $.ajax({
        url: '/Itens/Salvar',
        data: { id: id, ativo: ativo, viewCod: viewCod, textMenu: textMenu },
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

// ##########################################

$(document).ready(function () {
    $('.dropdown-toggle').dropdown();
    $(".dropdown-menu li a").click(function () {
        var selText = $(this).text();
        $(this).parents('.btn-group').find('.views').text(selText);
        var key = $(this).attr('id');
        $(this).parents('.btn-group').find('.views').val(key);
    });
});

// Regras de validação ###########################
