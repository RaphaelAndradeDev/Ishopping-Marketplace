


function GetDefaultForm() {
    GetDefaoutStyle();
    clear();
}

function GoToOption() {
    window.location.href = '/ActivityOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/Activity/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#stitle").text(json.title);
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


// Retorna Resultado da Pesquisa ( por uma posição e um titulo) ################

    $(document).ready(function () {
        $(".pesq").on('click', function () {       
            $.ajax({
                url: '/Activity/GetResultTxt',
                data: {
                    ps: $("#txtPosition").val(),
                    term: $("#txtTexto").val()
                },
                type: 'POST',
                dataType: "json"
            })
            .success(function (json) {
                if (json.FileFound) {
                    id = json.id;
                    $("#title").val(json.title);
                    $("#icon").val(json.icon);
                    $("#description").val(json.description);
                    $("#stitle").text(json.stTitle);
                    $("#sdescription").text(json.stDescription);                              
                }
                else {                
                    jsonFileNotFound(json);
                }
            })
            .error(function (xhr, status) {               
                $('#Status').html("Erro na tentativa de busca");
            });
        });
    });


// Salvar Mudanças ##############################

    function Salvar() {  
        $.ajax({
            url: '/Activity/Salvar',
            data: {
                id: id,
                position: setPosition($("#txtPosition").val()),
                title: $("#title").val(),              
                icon: $("#icon").val(),
                description: $("#description").val(),
                stTitle: toStyle($("#stitle").text()),
                stDescription: toStyle($("#sdescription").text())
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
    }


// Regras de validação ###########################

    $(document).ready(function () {
        $('#defaultForm').bootstrapValidator({
            message: 'This value is not valid',
            fields: {
                title: {
                    validators: {
                        notEmpty: {},
                        stringLength: { min: 1, max: 64 }
                    }
                },
                icon: {
                    validators: {
                        notEmpty: {},
                        stringLength: { min: 1, max: 32 }
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
    });