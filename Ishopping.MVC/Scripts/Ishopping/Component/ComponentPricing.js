

function GetDefaultForm() {
    GetDefaoutStyle();
    clear();
}

function GoToOption() {
    window.location.href = '/PricingOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/Pricing/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#snomePlano").text(json.nomePlano);
            $("#smoeda").text(json.moeda);
            $("#spriceUnid").text(json.priceUnid);
            $("#spriceCent").text(json.priceCent);
            $("#speriodo").text(json.periodo);
            $("#sdescription").text(json.description);
            $("#scomment").text(json.comment);
            $("#stextButton").text(json.textButton);           
        }
        else {
            jsonFileNotFound();
        }
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de busca");
    });
};

// ##########################################

$(document).ready(function () {
    $("#btnTexto").on('click', function () {      
        $.ajax({
            url: '/Pricing/GetResultTxt',
            data: { term: $("#txtTexto").val() },
            type: 'POST',
            dataType: "json"
        })
        .success(function (json) {
            if (json.FileFound) {
                id = json.id;
                $("#nomePlano").val(json.nomePlano);
                $("#destacar").prop("checked", json.destacar);
                $("#moeda").val(json.moeda);
                $("#priceUnid").val(json.priceUnid);
                $("#priceCent").val(json.priceCent);
                $("#periodo").val(json.periodo);
                $("#description").val(json.description);
                $("#comment").val(json.comment);
                $("#textButton").val(json.textButton);
                $("#urlButton").val(json.urlButton);

                $("#snomePlano").text(json.stNomePlano);
                $("#smoeda").text(json.stMoeda);
                $("#spriceUnid").text(json.stPriceUnid);
                $("#spriceCent").text(json.stPriceCent);
                $("#speriodo").text(json.stPeriodo);
                $("#sdescription").text(json.stDescription);
                $("#scomment").text(json.stComment);
                $("#stextButton").text(json.stTextButton);
            }
            else {
                jsonFileNotFound();
            }
        })
        .error(function (xhr, status) {
            $('#Status').html("Erro na tentativa de busca");
        })
    });
});


//################################################

function Salvar() {   
    $.ajax({
        url: '/Pricing/Salvar',
        data: {
            id: id,
            nomePlano: $("#nomePlano").val(),
            destacar: $("#destacar").prop('checked'),
            moeda: $("#moeda").val(),
            priceUnid: $("#priceUnid").val(),
            priceCent: $("#priceCent").val(),
            periodo: $("#periodo").val(),
            description: $("#description").val(),
            comment: $("#comment").val(),
            textButton: $("#textButton").val(),
            urlButton: $("#urlButton").val(),

            stNomePlano: toStyle($("#snomePlano").text()),            
            stMoeda: toStyle($("#smoeda").text()),
            stPriceUnid: toStyle($("#spriceUnid").text()),
            stPriceCent: toStyle($("#spriceCent").text()),
            stPeriodo: toStyle($("#speriodo").text()),
            stDescription: toStyle($("#sdescription").text()),
            stComment: toStyle($("#scomment").text()),
            stTextButton: toStyle($("#stextButton").text()),
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
    })
};

// Regras de validação ###########################

$(document).ready(function () {
    $('#defaultForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {
            nomePlano: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 64 }
                }
            },
            moeda: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 2 }
                }
            },
            price: {
                validators: {
                    notEmpty: {},
                    integer: {}
                }
            },
            periodo: {
                validators: {
                    stringLength: { max: 32 }
                }
            },
            description: {
                validators: {
                    stringLength: { max: 512 }
                }
            },
            comment: {
                validators: {
                    stringLength: { max: 512 }
                }
            },
            textButton: {
                validators: {
                    stringLength: { max: 32 }
                }
            },
            urlButton: {
                validators: {
                    uri: { allowLocal: true }
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