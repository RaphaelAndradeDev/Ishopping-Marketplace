

var link, rede;

function GetDefaultForm() { 
    clear();
}


$(document).ready(function () {
    if (id === guidEmpity) {
        GetDefaultForm();
    }
});


function Salvar() {
    $.ajax({
        url: '/SocialNetworks/Salvar',
        data: {
            id: id,
            link: link,
            rede: rede
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
        alert("Erro na tentativa de salvar dados");
    })
};

// ##########################################

$('[name="adicionar"]').click(function () {
    link = $(this).parents('#addSnForm').find('[name="link"]').val();
    rede = $(this).parents('#addSnForm').find('[name="rede"]').text();
    rede = rede.trim();
    $('#addSnForm').data('bootstrapValidator').validate();
});

$('[name="salvar"]').click(function () {
    id = $(this).parents('.row').find('[name="id"]').val();
    link = $(this).parents('.row').find('[name="link"]').val();
    rede = $(this).parents('.row').find('[name="rede"]').text();
    rede = rede.trim();
    $('#defaultForm').data('bootstrapValidator').validate();
});


// ##########################################

$(".dropdown-menu li a").click(function () {
    var selText = $(this).text();  
    $(this).parents('.btn-group').find('.dropdown-toggle').html(selText + ' <span class="caret"></span>');
});



$(document).ready(function () {

    $('.dropdown-toggle').dropdown();

    // Regras de validação ###########################
    $('#addSnForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {
            link: {
                validators: {
                    notEmpty: {},
                    uri: { allowLocal: false },
                    stringLength: { min: 12, max: 128, message: 'O campo deve conter uma URL valida entre 12 e 128 caracteres' }
                }
            },
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

    $('#defaultForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {      
            link: {
                validators: {
                    notEmpty: {},
                    uri: { allowLocal: false },
                    stringLength: { min: 12, max: 128, message: 'O campo deve conter uma URL valida entre 12 e 128 caracteres' }
                }
            },
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