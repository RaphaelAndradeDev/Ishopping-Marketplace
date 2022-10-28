
var model;

function GetDefaultForm() {
    GetDefaoutStyle();
    clear();
}

function GoToOption() {
    window.location.href = '/PostOption/Alter';
}

function GotoSinglePost(id) { 
    if (id !== guidEmpity)
        window.open('/AppView/SinglePost/' + id);
};

function GetDefaoutStyle() {
    $.ajax({
        url: '/Post/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#stitulo").text(json.titulo);
            $("#sautor").text(json.autor);
            $("#scategoria").text(json.categoria);           
            $("#ssubtitulo").text(json.subtitulo);
            $("#sparagrafo").text(json.paragrafo);           
        }
        else {
            jsonFileNotFound();
        }
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de busca");
    });
};


// Tratamento dropdown
$(".dropdown-menu li a").click(function () {
    var selText = $(this).text(); 
    $(this).parents('.btn-group').find('#categoria').text(selText);
});


// ##########################################

function modelIsValid()
{
    var md = $(".model").text();
    if (md.trim() === "Selecione um modelo") {
        $('#Status').html('<strong style="color:red">Selecione um modelo para esse post</strong>');
        $('#Status').fadeIn(500);
        $('#salvar').prop("disabled", true);
    } else {

        var result = modelValidate(model)
        if (result == true) {
            Salvar();
        } else {
            $('#Status').html('<strong style="color:red">O modelo escolhido requer ' + result + '</strong>');
            $('#Status').fadeIn(500);
            $('#salvar').prop("disabled", true);
        }
    }
}

function Salvar() {
    var img = [];
    $('.image').each(function (i) {
        img[i] = $(this).val();
    });
    $.ajax({
        url: '/Post/Salvar',
        data: {
            id: id,
            displayOnPage: $('#displayOnPage').prop('checked'),
            displayOnlyPage: $('#DisplayOnlyPage').prop('checked'),
            model: model,
            titulo: $("#titulo").val(),
            subTitulo1: $("#subTitulo1").val(),
            paragrafo1: $("#paragrafo1").val(),
            subTitulo2: $("#subTitulo2").val(),
            paragrafo2: $("#paragrafo2").val(),
            subTitulo3: $("#subTitulo3").val(),
            paragrafo3: $("#paragrafo3").val(),
            autor: $("#autor").val(),
            categoria: $("#categoria").text(),
            img1: img[0],
            img2: img[1],
            img3: img[2],
            video: $("#video").val(),
            tags: $('#tags').val(),
            stTitulo: toStyle($("#stitulo").text()),
            stCategoria: toStyle($("#scategoria").text()),
            stAutor: toStyle($("#sautor").text()),
            stSubTitulo: toStyle($("#ssubtitulo").text()),
            stParagrafo: toStyle($("#sparagrafo").text())
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

function modelValidate(value)
{
    var validate = true;
    switch (value) {
        case "_PartialPost_1":
            validate = model_1_Validate();
            break;
        case "_PartialPost_2":
            validate = model_2_Validate();
            break;
        case "_PartialPost_3":
            validate = model_3_Validate();
            break;
        case "_PartialPost_4":
            validate = model_4_Validate();
            break;
        case "_PartialPost_5":
            validate = model_5_Validate();
            break;
        case "_PartialPost_6":
            validate = model_6_Validate();
            break;
        case "_PartialPost_7":
            validate = model_7_Validate();
            break;
        case "_PartialPost_8":
            validate = model_8_Validate();
            break;
        case "_PartialPost_9":
            validate = model_9_Validate();
    }
    return validate;
}

function model_1_Validate() {
    if (imgCount(1)) {
        return true;
    }
    return "1 imagem";
}

function model_2_Validate() {
    if (imgCount(2)) {
        return true;
    }
    return "2 imagens";
}

function model_3_Validate() {
    if (imgCount(3)) {
        return true;
    }
    return "3 imagens";
}

function model_4_Validate() {
    if (imgCount(1)) {
        return true;
    }
    return "ao menos 2 imagens";
}

function model_5_Validate() {  
    if (imgCount(2) && exVideo()) {
        return true;
    }
    return "ao menos 2 imagens e 1 vídeo";
}

function model_6_Validate() {    
    if (imgCount(1) && exVideo()) {
        return true;
    }
    return "1 imagem e 1 vídeo";
}

function model_7_Validate() { 
    if (imgCount(2) && exVideo()) {
        return true;
    }
    return "ao menos 2 imagens e 1 vídeo";
}

function model_8_Validate() {
    if (imgCount(2) && exVideo()) {
        return true;
    }
    return "ao menos 2 imagens e 1 vídeo";
}

function model_9_Validate() {
    if (exVideo()) {
        return true;
    }
    return "1 vídeo";
}

function imgCount(value) {
    var count = $('.image').size();
    return count >= value;
}

function exVideo() {
    var video = $("#video").val(); 
    return !!video;
}


$(document).ready(function () {
    if (id === guidEmpity) {
        GetDefaultForm();
    }
});



$(document).ready(function () {

    $('.model').dropdown();
    $("[name='model']").on("click", function () {
        var str = $(this).text();
        model = $(this).attr('id');
        $(this).parents('.btn-group').find('.model').html(str + "   " + "<span class='caret'></span>");
    });

    model = $('#model').data('model');
    $('[name=model]').each(function (index) {
        var m = $(this).attr("id");
        if (m === model) {
            var str = $(this).text();
            $(this).parents('.btn-group').find('.model').html(str + "   " + "<span class='caret'></span>");
            return false;
        }
    });
    
    // Regras de validação ###########################
    $('#defaultForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {
            titulo: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 64 }
                }
            },
            img1: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 32 }
                }
            },
            img2: {
                validators: {
                    stringLength: { max: 32 }
                }
            },
            img3: {
                validators: {
                    stringLength: { max: 32 }
                }
            },
            subTitulo1: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 128 }
                }
            },
            subTitulo2: {
                validators: {
                    stringLength: { max: 128 }
                }
            },
            subTitulo3: {
                validators: {
                    stringLength: { max: 128 }
                }
            },
            paragrafo1: {
                validators: {
                    notEmpty: {},
                    stringLength: { max: 5120 }
                }
            },
            paragrafo2: {
                validators: {          
                    stringLength: { max: 5120 }
                }
            },
            paragrafo3: {
                validators: {              
                    stringLength: { max: 5120 }
                }
            },        
            categoria: {
                validators: {
                    stringLength: { max: 32 }
                }
            },
            autor: {
                validators: {
                    stringLength: { max: 32 }
                }
            },
            video: {
                validators: {
                    uri: { allowLocal: false }
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
        modelIsValid();
    });
});