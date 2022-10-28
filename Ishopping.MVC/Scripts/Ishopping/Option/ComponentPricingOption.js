
$(document).ready(function () {

    var nomePlano = $('#NomePlano').data('nomeplano');
    $('#NomePlano').val(nomePlano.split(","));

    var moeda = $('#Moeda').data('moeda');
    $('#Moeda').val(moeda.split(","));

    var priceUnid = $('#PriceUnid').data('priceunid');
    $('#PriceUnid').val(priceUnid.split(","));

    var priceCent = $('#PriceCent').data('pricecent');
    $('#PriceCent').val(priceCent.split(","));

    var periodo = $('#Periodo').data('periodo');
    $('#Periodo').val(periodo.split(","));

    var description = $('#Description').data('description');
    $('#Description').val(description.split(","));

    var comment = $('#Comment').data('comment');
    $('#Comment').val(comment.split(","));

    var textButton = $('#TextButton').data('textbutton');
    $('#TextButton').val(textButton.split(","));

    var price = $('#Price').data('price');
    $('#Price').val(price.split(","));

    $('.selectpicker').addClass('col-xs-12 col-sm-6  col-md-6 col-lg-6').selectpicker('setStyle');
});

function Salvar() {
    $.ajax({
        url: '/PricingOption/Salvar',
        data: {
            textView: $("#titleView").val(),
            styleTextView: toStyle($("#stitleView").text()),
            subTitleView: $("#subtitleView").val(),
            styleSubTitleView: toStyle($("#ssubtitleView").text()),
            nomePlano: toStyle($("#NomePlano").val()),
            moeda: toStyle($("#Moeda").val()),
            priceUnid: toStyle($("#PriceUnid").val()),
            priceCent: toStyle($("#PriceCent").val()),
            periodo: toStyle($("#Periodo").val()),
            description: toStyle($("#Description").val()),
            comment: toStyle($("#Comment").val()),
            textButton: toStyle($("#TextButton").val()),
            price: toStyle($("#Price").val()),
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