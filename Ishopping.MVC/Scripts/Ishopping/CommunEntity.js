
// Variaveis Comuns
var guidEmpity = "00000000-0000-0000-0000-000000000000";
var token = $('[name=__RequestVerificationToken]').val();

var id = $('[name=_id]').val();
var goGallery = $('[name=_goGallery]').val();

var siteNumber = $('#_dataValues').data('_sitenumber');
var controller = $('#_dataValues').data('_controller');
var actionGetTexto = $('#_dataValues').data('_actiongettexto');
var actionDelete = $('#_dataValues').data('_actiondelete');
var reload = $('#_dataValues').data('_reload');


// função para posição
function setPosition(position)
{
    if (position !== "") {      
        return position;
    }
    else {       
        return 1;
    }         
}

// SetApplicationMenu
$(document).ready(function () {
    var appMenu = $('#_dataValues').data('_appmenu');
    var activeFor = $('#_dataValues').data('_activefor');

    var itens = appMenu.split(",");
    $.each(itens, function (index, value) {
        $("#" + value).removeClass("disabled");
    })
    var home = "/" + itens[0] + "/index/" + itens[1];
    $("#homePage").attr('href', home);
    $("#" + activeFor).addClass("active");
});

// Limpa areas de texto
function clear(){
    $(".texto,.txt,.st,.config,.search").val('');
}

// Habilita ou desabilita busca
function enableSearch(value) {
    $('#txtPosition,#btnPosition,#txtTexto,#btnTexto').prop('disabled', !value);
}

// Inicia serialização
function InitSerialize(jsonFinalize) {
    var controllers = controller.split(",");
    $.each(controllers, function (index, value) {
        Serialize(value, siteNumber, jsonFinalize);
    });
}

function Serialize(controller, siteNumber, jsonFinalize) {
    var urlSerialize = "/" + controller + "/Serialize";
    $.ajax({
        url: urlSerialize,
        data: { siteNumber: siteNumber },
        type: 'POST',
        cache: false,
        headers: { "__RequestVerificationToken": token },
        dataType: "json",
        beforeSend: function () {
            loadingOn();
        },
        complete: function () {
            loadingOff();
        }
    })
    .success(function (json) {      
        if (json === "finalize") {
            finalize(jsonFinalize);
        }        
    })
    .error(function (xhr, status) {
        alert("Erro na tentativa de serializar objeto");
    })
};

// Finaliza serialização
function finalize(jsonFinalize)
{
    if (jsonFinalize.Redirect) {
        window.location.href = jsonFinalize.RedirectUrl;
    }
    else {  
        id = jsonFinalize.Id;
        $('#Status').html('<strong>' + jsonFinalize.Message + '</strong>');
        $('#Status').fadeIn(500);
    }
}

// Retorna mensagem em caso de arquivo salvo ou deletado
function jsonSuccess(json)
{
    if (json.Serialize) {     
        InitSerialize(json);
        $('#Status').html("<strong>Salvando dados. Por favor aguarde!</strong>");
        $('#Status').fadeIn(200);
    }
    else {
        finalize(json);
    }    
}

// Retorna mensagem em caso de arquivo não encontrado
function jsonFileNotFound(json)
{
    id = json.Id;
    $('#Status').html('<strong>' + json.Message + '</strong>');
    $('#Status').fadeIn(500);
    GetDefaultForm();
}

// FadeOut (oculta status)
$('input,button,textarea').not("#salvar").on('change, click', function () {
    $("#Status").fadeOut(500);
});

// Ativar loading animate
function loadingOn() {
    viewDisabled();
    $(".container").css({ opacity: 0.3 });
    $('.well').append('<img id="imgload" src="../../Images/Ishopping/loading.gif" />');
}

// Desativar loading animate
function loadingOff() {
    viewEnable();
    $(".container").css({ opacity: 1 });
    $("#imgload").remove();
}

// Bloqueia view
function viewDisabled() {
    $('body').css('pointer-events', 'none');
}

// Desbloqueia view
function viewEnable() {
    $('body').css('pointer-events','');
}


// Reseta id para gerar novo arquivo
$(document).ready(function () {
    $("#novo").on('click', function () {       
        id = guidEmpity;
        GetDefaultForm();
    });
});

// Abre uma nova guia para galeria de imagens
$("#goToGallery").on('click', function () {
    window.open(goGallery, '_blank');
});

// recarrega a pagina
$("#reload").on('click', function () {
    location.href = reload;
});

// Deleta Arquivo ############################
$('#deletar').on('click', function () {
    if (id !== guidEmpity) {
        $('#myModal').modal('show');
    }
});

$('[name="deletar"]').on('click', function () {
    id = $(this).attr("id");
    if (id !== guidEmpity) {
        $('#myModal').modal('show');
    }
});

function Deletar() {
    $.ajax({
        url: actionDelete,
        data: { id: id },
        type: 'POST',
        cache: false,
        headers: { "__RequestVerificationToken": token },
        dataType: "json",
        beforeSend: function () {
            loadingOn();
        },
        complete: function () {
            loadingOff();
        }
    })
    .success(function (json) {
        jsonSuccess(json);
        GetDefaultForm();
    })
    .error(function (xhr, status) {
        alert("Erro na tentativa de deletar o objeto");
    })
}

