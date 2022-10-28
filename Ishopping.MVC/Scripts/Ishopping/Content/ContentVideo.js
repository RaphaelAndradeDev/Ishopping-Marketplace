


function GetDefaultForm() {
    clear();   
    $("#position").val(ps);
}


function GetPosition() {
    $.ajax({
        url: '/Video/GetResultPs',
        data: { viewCod: viewCod, ps: ps },
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            id = json.id;           
            $("#textUrl").val(json.url);      
        }
        else {
            jsonFileNotFound(json);
        };
        enableForm(ps);
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de busca");
    })
};


function Salvar() {
    view = $(".views").text();
    if (view === "Selecione uma view") { return false; }  
    $.ajax({
        url: '/Video/Salvar',
        data: {
            id: id,
            viewCod: viewCod,
            position: $("#position").val(),
            url: $("#textUrl").val()
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


function validar() {
    $('#defaultForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {
            position: {
                validators: {
                    notEmpty: {},
                    between: { min: 1, max: nps }
                }
            },
            textUrl: {
                validators: {               
                    uri: {
                        allowLocal: false,
                        message: 'A URL inserida não é valida'
                    }
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
};
