


function GetDefaultForm() {
    GetDefaoutStyle();
    clear();
}

function GoToOption() {
    window.location.href = '/PortfolioOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/Portofolio/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#scategory").text(json.category);
            $("#stitle").text(json.title);
            $("#sdescription").text(json.description);
            $("#slist").text(json.list);
        }
        else {
            jsonFileNotFound();
        }
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de busca");
    });
};

//################################################

function Salvar() {   
    $.ajax({
        url: '/Portofolio/Salvar',
        data: {
            id: id,
            displayOnPage: $('#DisplayOnPage').prop('checked'),
            displayOnlyPage: $('#DisplayOnlyPage').prop('checked'),
            portfolioHead: $('#PortfolioHead').prop('checked'),
            portfolioChild: $('#PortfolioChild').prop('checked'),
            position: setPosition($("#position").val()),
            title: $("#title").val(),
            stitle: toStyle($("#stitle").text()),
            imageFileName: $("#img").val(),
            category: $("#category").val(),
            subCategory: $('#subCategory').val(),
            scategory: toStyle($("#scategory").text()), 
            description: $("#description").val(),
            sdescription: toStyle($("#sdescription").text()), 
            list: $("#list").val(),
            slist: toStyle($("#slist").text()), 
            tags: $('#tags').val()
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


$(document).ready(function () {
    if (id === guidEmpity) {
        GetDefaultForm();
    }
});


// Regras de validação ###########################
$(document).ready(function () {
    $('#defaultForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {
            title: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 64 }
                }
            },
            img: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 32 }
                }
            },
            description: {
                validators: {
                    stringLength: { max: 512 }
                }
            },
            category: {
                validators: {
                    notEmpty: {},
                    regexp: {
                        regexp: /^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+$/,
                        message: 'Apenas letras e números são permitidos'
                    },
                    stringLength: { min: 4, max: 32, message: 'O campo Categoria deve conter entre 4 e 32 digitos' }
                }
            },
            subCategory: {
                validators: {
                    notEmpty: {},
                    regexp: {
                        regexp: /^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+$/,
                        message: 'Apenas letras e números são permitidos'
                    },
                    stringLength: { min: 4, max: 32, message: 'O campo Subcategoria deve conter entre 4 e 32 digitos' }
                }
            },
            list: {
                validators: {
                    stringLength: { max: 512 }
                }
            },
            tags: {
                validators: {               
                    stringLength: { min: 4, max: 512, message: 'O campo Tags de Busca deve conter entre 4 e 512 digitos' }
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