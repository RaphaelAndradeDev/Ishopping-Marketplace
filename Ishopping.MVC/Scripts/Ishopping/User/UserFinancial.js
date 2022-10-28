
var txt = "Valor promocional do plano:  ";
var group, plan, templateCod, templateCodOld, viewCod, viewCodOld;
var token = $('[name=__RequestVerificationToken]').val();

// Início ###############################

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

$(document).ready(function () {
    $('.dropdown-toggle').dropdown();

    //popover salvar
    $("#salvar").popover({
        trigger: 'hover',
        content: '<p><span class="glyphicon glyphicon-info-sign text-info"></span> Atenção: Ao trocar de template, todas as suas imagens e configurações anteriores serão excluídas.</p>',
        html: true
    });

    // popover pagseguro
    $("#pay").popover({
        trigger: 'hover'
    });

    // show modal info
    $("#infoPlan").click(function () {
        $('#myModalInfoPlan').modal('show');
    });

    $("#infoPayment").click(function () {
        $('#myModalInfoPayment').modal('show');
    });

    $("#historic").click(function () {
        $('#myModalHistoric').modal('show');
    });

    // filter
    filter();
});


// ###########################################
 
$('#filter').on("click", function () {
    if ($(this).prop('checked')) {
        showAll();
    } else {
        filter();
    }
})

function filter() {
    var x = 0;
    $("tr").each(function () {
        if (!isNaN(parseInt($(this).prop("class")))) {
            $(this).hide();
            var cl = parseInt($(this).prop("class"))
            x = cl > x ? cl : x;
        }
    });
    $("." + x).show();
}

function showAll() {
    $("tr").each(function () {
        if (!isNaN(parseInt($(this).prop("class")))) {
            $(this).show();
        }
    });
}

// ###########################################

$(".form-control").on('change', function () {
    $("#Status").fadeOut(500);
});

// ##########################################

$(document).ready(function () {
    $.ajax({
        url: '/Plan/GetPlan',
        type: 'POST',
        dataType: "json"
    })
    .success(function (data) {
        $("#value").empty();
        $("#ddmTemplate").empty();
        $("#ddmView").empty();
        $(".group").html(data.GroupName + "&nbsp;&nbsp;" + "<span class='caret'></span>");
        $(".template").html(data.TemplateName + "&nbsp;&nbsp;" + "<span class='caret'></span>");
        $(".view").html(data.ViewName + "&nbsp;&nbsp;" + "<span class='caret'></span>");
        group = data.KeyGroup;
        templateCod = data.KeyTemplete;
        templateCodOld = data.KeyTemplete;
        viewCod = data.KeyViewStart;
        viewCodOld = data.KeyViewStart;
        $("#templateHeader").prop('disabled', true);
        $("#viewHeader").prop('disabled', true);
        $("#textValue").append("<p class='color1'>" + txt + data.Price + " por mês." + "</p>");
    })
    .error(function (xhr, status) {
        alert("Nenhum resultado encontrado");
    })
});

// ##########################################

function GetTemplate() {
    $.ajax({
        url: '/Plan/GetTemplate',
        type: 'POST',
        data: { group: group },
        dataType: "json"
    })
    .success(function (data) {        
        $("#ddmTemplate").empty();
        $("#ddmView").empty();
        $(data.template).each(function (index, item) {
            $("#ddmTemplate").append("<li><a name='TemplateCod' id='" + item.cod + "'>" + item.name + "</a></li>")
        });

        //tabela
        $("#tabItens").text(data.financial.PlanName);
        $("#tabMonth").text(data.financial.Month);
        $("#tabValue").text(data.financial.PlanValue);
        $("#tabBalance").text(data.financial.Balance);
        $("#tabBonus").text(data.financial.Bonus);
        $("#tabDueDate").text(data.financial.DueDate);
        $("#payment").text(data.financial.Payment);

    })
    .error(function (xhr, status) {
        alert("Nenhum resultado encontrado");
    })
};

function GetView() {
    $.ajax({
        url: '/Plan/GetView',
        data: { templateCod: templateCod },
        type: 'POST',
        dataType: "json"
    })
    .success(function (data) {
        $("#ddmView").empty();
        $(data).each(function (index, item) {
            $("#ddmView").append("<li><a name='ViewStart' id='" + item.cod + "'>" + item.name + "</a></li>")
        })
    })
    .error(function (xhr, status) {
        alert("Nenhum resultado encontrado");
    })
};

// Salvar ##################################

$("#salvar").on('click', function () {
    if (viewCod != 0) {
        if (templateCod != templateCodOld) {
            $('#myModalNewTemplate').modal('show');
        }
        else if (viewCod != viewCodOld) {
            $('#myModalNewView').modal('show');
        }
    }
});

function Salvar() {
    $.ajax({
        url: '/Plan/Salvar',
        data: { group: group, templateCod: templateCod, viewCod: viewCod, plan: plan },
        type: 'POST',
        cache: false,
        headers: { "__RequestVerificationToken": token },
        dataType: "json",
        beforeSend: function () {
            loadingOn();
        }  
    }) 
    .success(function (json) {
        if (json.Redirect) {
            window.location.href = json.RedirectUrl;
        }
        else {
            loadingOff();
            $('#Status').html(json.Message);
            $('#Status').fadeIn(500);
        }
    })
    .error(function (xhr, status) {
        loadingOff();
        alert("Não foi possível salvar os dados");
    })
};

// Payment
function Pay() {
    name = $("#name").val();
    email = $("#email").val();
    areaCod = $("#areaCod").val();
    phone = $("#phone").val();
    cpf = $("#cpf").val();
    $.ajax({
        url: '/Plan/Pay',
        data: { company: 1, name: name, email: email, areaCod: areaCod, phone: phone, cpf: cpf },
        type: 'POST',
        cache: false,
        headers: { "__RequestVerificationToken": token },
        dataType: "json",
        beforeSend: function () {
            loadingOn();
        } 
    })
    .success(function (json) {
        if (json.Redirect) {
            window.location.href = json.RedirectUrl;
        }
        else {
            loadingOff();
            $('#Status').html(json.Message);
            $('#Status').fadeIn(500);
        }
    })
    .error(function (xhr, status) {
        loadingOff();
        alert("Não foi possível efetuar o pagamento");
    })
};

// ##########################################

// Ativar loading animate
function loadingOn() {
    viewDisabled();
    $(".container").css({ opacity: 0.3 });
    $('#defaultForm').append('<img id="imgload" src="../../Images/Ishopping/loading.gif" />');
}

// Desativar loading animate
function loadingOff() {
    viewEnable();
    $(".container").css({ opacity: 1 });
    $("#imgload").remove();
}

// Bloqueia view
function viewDisabled() {
    $('input,button,textarea').prop('disabled', true);
}

// Desbloqueia view
function viewEnable() {
    $('input,button,textarea').prop('disabled', false);
}

$(document).ready(function () {
    $("[name='Group']").on("click", function () {
        var selText = $(this).text();
        group = $(this).attr('id');
        group = group.replace("g_", "");
        $(this).parents('.btn-group').find('.group').html(selText + "   " + "<span class='caret'></span>");
        $("#templateHeader").html('Selecione um template <span class="caret"></span>');
        $("#viewHeader").html('Selecione uma página inicial <span class="caret"></span>');
        $("#templateHeader").prop('disabled', false);
        $("#viewHeader").prop('disabled', true);
        viewCod = 0;
        GetTemplate();
    });

    $(document).on("click", "[name='TemplateCod']", function () {
        var str = $(this).text();
        templateCod = $(this).attr('id');
        $(this).parents('.btn-group').find('.template').html(str + "   " + "<span class='caret'></span>");
        $("#viewHeader").html('Selecione uma página inicial <span class="caret"></span>');
        $("#viewHeader").prop('disabled', false);
        viewCod = 0;
        GetView();
    });

    $(document).on("click", "[name='ViewStart']", function () {
        var str = $(this).text();
        viewCod = $(this).attr('id');
        $(this).parents('.btn-group').find('.view').html(str + "   " + "<span class='caret'></span>");
    });
});

// Regras de validação ###########################

$(document).ready(function () {
    $('#defaultForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {
            name: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 64 }
                }
            },
            email: {
                validators: {
                    emailAddress: {}
                }
            },
            areaCod: {
                validators: {
                    notEmpty: {},
                    between: { min: 11, max: 99 }
                }
            },
            phone: {
                validators: {
                    notEmpty: {},
                    integer: { message: 'Apenas números são permitidos' },
                    stringLength: { min: 8, max: 9 }
                }
            },
            cpf: {
                validators: {
                    notEmpty: {},
                    integer: { message: 'Apenas números são permitidos' },
                    stringLength: { min: 11, max: 11, message: 'O campo CPF deve conter 11 digitos' }
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
           // Call save
           Pay();
       });
});