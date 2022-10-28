
var viewCod;
var token = $('[name=__RequestVerificationToken]').val();

$(".form-control").on('change', function () {
    $("#Status").fadeOut(500);
});

// ##########################################

$("#load").on('click', function () {
    var vName = $(".views").text();
    if (vName === "Selecione uma view") { return false; }
    GetItens();
});

// FadeOut (oculta status)
$(document).on('click', 'input', function () {
    $("#Status").fadeOut(500);
});

function BlockInput() {
    $('.disable').each(function (index) {
        $(this).prop('disabled', true);
    });
    $('[name="viewType"]').each(function (index) {    
        if ($(this).text() === "Item do Menu") {         
            $(this).parents('.row').find('[name="textView"]').prop('disabled', true).val("");
            $(this).parents('.row').find('[type="checkbox"]').prop('disabled', true);
        }            
    });
};

function GetItens() {
    $.ajax({
        url: '/ViewItens/GetViewItens',
        data: { viewCod: viewCod },
        type: 'POST',
        dataType: "json"
    })
      .success(function (data) {
          $("#check").empty();
          $(data).each(function (index, item) {
              $("#check").append('<div class="row"><div class="col-md-offset-1">' +
                                    '<div class="col-md-2"><h4 class="color1" name="viewType">' + item.ViewTipo + '</h4></div>' +
                                    '<div class="form-group col-md-2"><input class="form-control texto ' + item.TextMenuCl + '" type="text" name="textMenu" placeholder="Texto do menu" value="' + item.TextMenu + '"/></div>' +
                                    '<div class="form-group col-md-3"><input class="form-control texto ' + item.TextViewCl + '" type="text" name="textView" placeholder="Texto da view" value="' + item.TextView + '"/></div></div>' +
                                    '<div class="checkbox col-md-1 color1"><label><input type="checkbox" id="a_'+ item.Id +'">Ativar</label></div>' +
                                    '<div class="col-md-3"><button type="submit" class="btn btn-primary Salvar" id="' + item.Id + '" style="margin:2px">Salvar</button></div></div></div>');
              $("#a_" + item.Id).prop("checked", item.Active);
          })
          BlockInput();
      })
    .error(function (xhr, status) {
        alert("Nenhum resultado encontrado");
    })
};

// ##########################################

$(document).on('click', '.Salvar', function () {

    var id = $(this).attr('id');
    var ativo = $(this).parents('.row').find('[type="checkbox"]').prop('checked');
    var textMenu = $(this).parents('.row').find('[name="textMenu"]').val();
    var textView = $(this).parents('.row').find('[name="textView"]').val();

    if (textMenu.length > 24) {
        $('#Status').html('<strong>texto do menu não deve ultrapassar 24 caracteres</strong>');
        $('#Status').fadeIn(500);
        return false;
    }

    if (textView.length > 100) {
        $('#Status').html('<strong>texto da view não deve ultrapassar 100 caracteres</strong>');
        $('#Status').fadeIn(500);
        return false;
    }
    
    Salvar(id, ativo, textMenu, textView);
});

function Salvar(id, ativo, textMenu, textView) {
   
    $.ajax({
        url: '/ViewItens/Salvar',
        data: { id: id, ativo: ativo, textMenu: textMenu, textView: textView },
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
        viewCod = $(this).attr('id');
        $(this).parents('.btn-group').find('.views').text(selText);
    });
});

// Regras de validação ###########################
