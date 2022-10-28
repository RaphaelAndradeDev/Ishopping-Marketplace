
$(document).ready(function () {

    var name = $('#Name').data('name');
    $('#Name').val(name.split(","));

    var title = $('#Title').data('title');
    $('#Title').val(title.split(","));

    var client = $('#Client').data('client');
    $('#Client').val(client.split(","));

    var description = $('#Description').data('description');
    $('#Description').val(description.split(","));

    var category = $('#Category').data('category');
    $('#Category').val(category.split(","));

    var team = $('#Team').data('team');
    $('#Team').val(team.split(","));

    $('.selectpicker').addClass('col-xs-12 col-sm-6  col-md-6 col-lg-6').selectpicker('setStyle');
});

function Salvar() {
    $.ajax({
        url: '/ProjectsOption/Salvar',
        data: {
            textView: $("#titleView").val(),
            styleTextView: toStyle($("#stitleView").text()),
            subTitleView: $("#subtitleView").val(),
            styleSubTitleView: toStyle($("#ssubtitleView").text()),
            name: toStyle($("#Name").val()),
            title: toStyle($("#Title").val()),
            client: toStyle($("#Client").val()),
            description: toStyle($("#Description").val()),
            category: toStyle($("#Category").val()),
            team: toStyle($("#Team").val())
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