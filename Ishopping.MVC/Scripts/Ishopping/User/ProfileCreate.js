

var txt = "Valor atual do plano:  ";
var group, templateCod, viewCod;
var token = $('[name=__RequestVerificationToken]').val();


function GetTemplate() {
    $.ajax({
        url: '/Profiles/GetTemplate',
        type: 'POST',
        data: { group: group },
        dataType: "json"
    })
    .success(function (data) {
        $("#value").empty();
        $("#ddmTemplate").empty();
        $(data.template).each(function (index, item) {
            $("#ddmTemplate").append("<li><a name='TemplateCod' id='" + item.Key + "'>" + item.Value + "</a></li>")
        })
        $("#value").append("<span class='color1'>" + txt + data.value + " por mês." + "</span>");
    })
    .error(function (xhr, status) {
        alert("Nenhum resultado encontrado");
    })
};

function GetView() {
    $.ajax({
        url: '/Profiles/GetView',
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


function Salvar() {
    var form = $('#defaultForm'),       
         data = {};
    form.find("[name]").not("[name=__RequestVerificationToken]")
        .each(function (index, value) {
            var form = $(this),
            name = form.attr('name'),
            value = form.val();
            data[name] = value;
        });

    data['Group'] = group;
    data['TemplateCod'] = templateCod;
    data['ViewStart'] = viewCod;
    myJSON = JSON.stringify(data);
    $.ajax({
        url: '/Profiles/CreateProfile',
        data: { dados: myJSON },
        type: 'POST',
        headers: { "__RequestVerificationToken": token },
        dataType: "json",
        beforeSend: function () {
            loadingOn();
        }
    })
    .success(function (json) {
        if (json.isRedirect) {
            window.location.href = json.redirectUrl;
        }
        else {
            loadingOff();
            $('#Status').html(json.message);
            $('#Status').fadeIn(500);          
        }
    })
    .error(function (xhr, status) {
        loadingOff();
        alert("Erro na tentativa de salvar dados");   
    })
    return false;
};


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


// GoogleMaps
function getResult(lat, lon) {
    $('[name=Latitude]').val(lat);
    $('[name=Longitude]').val(lon);
}

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function loadLatLon() {
    var lat = getCookie("lat");
    var lon = getCookie("lon");
    if (lat != "" && lon != "") {
        getResult(lat, lon);
    } else {
        getThisLatLong();
    }
}

function getThisLatLong() {
    var divMapa = document.getElementById('mapa');
    navigator.geolocation.getCurrentPosition(fn_ok, fn_mal);
    function fn_mal() { }
    function fn_ok(rta) {
        var lat = rta.coords.latitude.toPrecision(9);
        var lon = rta.coords.longitude.toPrecision(9);
        if (lat != "" && lat != null) {
            setCookie("lat", lat, 365);
            setCookie("lon", lon, 365);
            getResult(lat, lon);
        }
    }
}

$(window).load(function () {
    loadLatLon();
});

$(document).ready(function () {

    $('.dropdown-toggle').dropdown();

    $("[name='Group']").on("click", function () {
        var selText = $(this).text();
        group = $(this).attr('id');
        group = group.replace("g_", "");
        $(this).parents('.btn-group').find('.group').html(selText + "   " + "<span class='caret'></span>");
        GetTemplate();
    });

    $(document).on("click", "[name='TemplateCod']", function () {
        var str = $(this).text();
        templateCod = $(this).attr('id');
        $(this).parents('.btn-group').find('.template').html(str + "   " + "<span class='caret'></span>");
        GetView();
    });

    $(document).on("click", "[name='ViewStart']", function () {
        var str = $(this).text();
        viewCod = $(this).attr('id');
        $(this).parents('.btn-group').find('.view').html(str + "   " + "<span class='caret'></span>");
    });


    // Regras de validação ###########################
    $(document).ready(function () {
    $('#defaultForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {      
            SiteNumber: {
                validators: {
                    notEmpty: {},
                    remote: {
                        url: '/Profiles/RemoteValidate',
                        type: 'POST'
                    },
                    between: { min: 111111111, max: 999999999 },
                    remote: {
                        url: '/Profiles/RemoteValidateSiteNumber',
                        type: 'POST',
                        message: 'Este número já está em uso'
                    }
                }
            },
            SiteName: {
                validators: {
                    notEmpty: {},
                    regexp: {
                        regexp: /^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+$/,
                        message: 'Apenas letras, acentos e números são permitidos'
                    },
                    stringLength: { min: 4, max: 24, message: 'O campo Nome do Site deve conter entre 4 e 24 digitos' },
                    remote: {
                        url: '/Profiles/RemoteValidateSiteName',
                        type: 'POST',
                        message: 'Este nome já está em uso'
                    }
                }
            },
            Semantica1: {
                validators: {
                    notEmpty: {},
                    regexp: {
                        regexp: /^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+$/,
                        message: 'Apenas letras, acentos e números são permitidos'
                    },
                    stringLength: { min: 4, max: 24, message: 'O campo Palavra Chave deve conter entre 4 e 24 digitos' }
                }
            },
            Semantica2: {
                validators: {
                    regexp: {
                        regexp: /^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+$/,
                        message: 'Apenas letras, acentos e números são permitidos'
                    },
                    stringLength: { min: 4, max: 24, message: 'O campo Palavra Chave deve conter entre 4 e 24 digitos' }
                }
            },
            Semantica3: {
                validators: {
                    regexp: {
                        regexp: /^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+$/,
                        message: 'Apenas letras, acentos e números são permitidos'
                    },
                    stringLength: { min: 4, max: 24, message: 'O campo Palavra Chave deve conter entre 4 e 24 digitos' }
                }
            },
            Semantica4: {
                validators: {
                    regexp: {
                        regexp: /^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+$/,
                        message: 'Apenas letras, acentos e números são permitidos'
                    },
                    stringLength: { min: 4, max: 24, message: 'O campo Palavra Chave deve conter entre 4 e 24 digitos' }
                }
            },
            Empresa: {
                validators: {
                    regexp: {
                        regexp: /^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+$/,
                        message: 'Apenas letras, acentos e números são permitidos'
                    },
                    notEmpty: {},
                    stringLength: { min: 4, max: 32, message: 'O campo Nome deve conter entre 4 e 32 digitos' },
                    remote: {
                        url: '/Profiles/RemoteValidateEmpresa',
                        type: 'POST',
                        message: 'Este nome já está em uso'
                    }
                }
            },
            Cnpj: {
                validators: {
                    regexp: {
                        regexp: /^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$/,
                        message: 'O CNPJ é inválido'
                    },
                    remote: {
                        url: '/Profiles/RemoteValidateCnpj',
                        type: 'POST',
                        message: 'Este CNPJ já está em uso'
                    }
                }
            },
            Rua: {
                validators: {
                    notEmpty: {},
                    regexp: {
                        regexp: /^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+$/,
                        message: 'Apenas letras, acentos e números são permitidos'
                    },
                    stringLength: { max: 64 }
                }
            },
            NumRua: {
                validators: {
                    notEmpty: {},
                    regexp: {
                        regexp: /^[0-9A-Za-z ]+$/,
                        message: 'Apenas letras e números são permitidos'
                    },
                    stringLength: { max: 5 }
                }
            },
            Distrito: {
                validators: {
                    notEmpty: {},
                    regexp: {
                        regexp: /^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+$/,
                        message: 'Apenas letras, acentos e números são permitidos'
                    },
                    stringLength: { min: 4, max: 32, message: 'O campo Distrito deve conter entre 4 e 32 digitos' }
                }
            },
            Cidade: {
                validators: {
                    notEmpty: {},
                    regexp: {
                        regexp: /^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+$/,
                        message: 'Apenas letras, acentos e números são permitidos'
                    },
                    stringLength: { min: 4, max: 32, message: 'O campo Cidade deve conter entre 4 e 32 digitos' }
                }
            },
            Estado: {
                validators: {
                    notEmpty: {},
                    regexp: {
                        regexp: /^([^0-9]*)$/,
                        message: 'Apenas letras são permitidas'
                    },
                    stringLength: { min: 2, max: 2, message: 'O campo Estado deve conter 2 digitos' }
                }
            },
            CEP: {
                validators: {
                    notEmpty: {},
                    regexp: {
                        regexp: /^([0-9]){5}([-])([0-9]){3}$/,
                        message: 'O CEP é inválido'
                    }
                }
            },
            Telefone: {
                validators: {
                    notEmpty: {},
                    integer: { message: 'Apenas números são permitidos' },
                    stringLength: { min: 10, max: 12, message: 'O campo Telefone deve conter entre 10 e 12 digitos' }
                }
            },
            Telefone2: {
                validators: {
                    integer: { message: 'Apenas números são permitidos' },
                    stringLength: { min: 10, max: 12, message: 'O campo Telefone deve conter entre 10 e 12 digitos' }
                }
            },
            WhatsApp: {
                validators: {
                    integer: { message: 'Apenas números são permitidos' },
                    stringLength: { min: 10, max: 12, message: 'O campo WhatsApp deve conter entre 10 e 12 digitos' }
                }
            },
            Email: {
                validators: {
                    notEmpty: {},
                    emailAddress: {},
                    remote: {
                        url: '/Profiles/RemoteValidateEmail',
                        type: 'POST',
                        message: 'Este email já está em uso'
                    }
                }
            },
            Website: {
                validators: {
                    uri: { allowLocal: false },
                    remote: {
                        url: '/Profiles/RemoteValidateWebsite',
                        type: 'POST',
                        message: 'Este site já está em uso'
                    }
                }
            },
            LatitudeA: {
                validators: {
                    regexp: {
                        regexp: /^(\+|-)?(?:90(?:(?:\.0{7,7})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{7,7})?))$/,
                        message: 'Latitude inválida'
                    },
                    stringLength: { min: 11, max: 11, message: 'O campo Latitude deve conter 11 digitos' }
                }
            },
            LongitudeA: {
                validators: {
                    regexp: {
                        regexp: /^(\+|-)?(?:180(?:(?:\.0{7,7})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\.[0-9]{7,7})?))$/,
                        message: 'Longitude inválida'
                    },
                    stringLength: { min: 11, max: 11, message: 'O campo Longitude deve conter 11 digitos' }
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
           Salvar();
       });
    });
});