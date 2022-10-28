


var idSn, link, rede;

function GetDefaultForm() { 
    GetDefaoutStyle();
    clear();
}

function GoToOption() {
    window.location.href = '/TeamOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/Team/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#sname").text(json.name);
            $("#sfunctio").text(json.functio);
            $("#sdescription").text(json.description);
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
    $('.dropdown-toggle').dropdown();

    if (id === guidEmpity) {
        GetDefaultForm();
        $('#adicionarSn').attr('disabled', 'disabled');
    }
});

// ##########################################

$(".dropdown-menu li a").click(function () {
    var selText = $(this).text();
    $(this).parents('.btn-group').find('.dropdown-toggle').html(selText + ' <span class="caret"></span>');
});

// Salvar ###############################

function Salvar() { 
    $.ajax({
        url: '/Team/Salvar',
        data: {
            id: id,
            name: $("#name").val(),
            imageFileName: $("#img").val(),
            functio: $("#functio").val(),
            description: $("#description").val(),
            stName: $("#sname").text(),            
            stFunctio: $("#sfunctio").text(),
            stDescription: $("#sdescription").text()
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


// Redes Sociais ############################

function AdicionarSn() {
    idSn = guidEmpity;
    link = $("#link").val();
    rede = $("#dt1").text();
    rede = rede.trim();
    if (link !== "" && rede !== "Rede Social") {
        SalvarSn();
    }
};

$('[name="salvarSn"]').on('click', function () {    
    idSn = $(this).parents(".row").find('[name="_idSn"]').val();   
    link = $(this).parents(".row").find('[name="link"]').val();
    rede = $(this).parents(".row").find('[name="rede"]').text();
    rede = rede.trim();
    $('#SocialNetworkForm').data('bootstrapValidator').validate();
});

function SalvarSn() {    
    if (id !== guidEmpity) {
        $.ajax({
            url: '/Team/SalvarSn',
            data: { id: id, idSn: idSn, link: link, rede: rede },
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
    }
};

$('[name="deletarSn"]').click(function () {
    id = id;     
    if (id !== guidEmpity) {
        idSn = $(this).parents(".row").find('[name="_idSn"]').val();
        $('#myModalSn').modal('show');
    }
});

function DeletarSn() {
    $.ajax({
        url: '/Team/DeleteSn',
        data: { idSn: idSn },
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
            name: {
                validators: {
                    notEmpty: {},
                    stringLength: { min: 1, max: 64 }
                }
            },
            img: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 32 }
                }
            },
            functio: {
                validators: {
                    stringLength: { max: 128 }
                }
            },
            description: {
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

    // ************************************************************************

    $('#AddSocialNetworkForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {
            link: {
                validators: {
                    notEmpty: {},
                    uri: { allowLocal: false }
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
          AdicionarSn();
          // Reset
          $form
           .bootstrapValidator('disableSubmitButtons', false)  // Enable the submit buttons
           .bootstrapValidator('resetForm', false);             // Reset the form
      });

    // ************************************************************************

    $('#SocialNetworkForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {
            'socialNetwork[]': {
                validators: {
                    notEmpty: {},
                    uri: { allowLocal: false }
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
           SalvarSn();
           // Reset
           $form
            .bootstrapValidator('disableSubmitButtons', false)  // Enable the submit buttons
            .bootstrapValidator('resetForm', false);             // Reset the form
       });
});