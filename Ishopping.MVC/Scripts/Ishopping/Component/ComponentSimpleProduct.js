
var categoryId, subCategoryId;

function GetDefaultForm() {
    GetDefaoutStyle();
    clear();
}

function GoToOption() {
    window.location.href = '/SimpleProductOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/SimpleProduct/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#sname").text(json.name);
            $("#scategory").text(json.category);
            $("#sbrand").text(json.brand);
            $("#smodel").text(json.model);           
            $("#sdescription").text(json.description);
            $("#sprice").text(json.price);
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

function GetSubCategory(categoryId) {
    $.ajax({
        url: '/SimpleProduct/GetSubCategory',
        type: 'POST',
        data: { categoryId: categoryId },
        dataType: "json"
    })
    .success(function (data) {
        $("#ddmSubCategory").empty();    
        $(data).each(function (index, item) {            
            $("#ddmSubCategory").append("<li><a class='itemSubCategory' id='" + item.Id + "'>" + item.Name + "</a></li>")
        });   
    })
    .error(function (xhr, status) {
        alert("Nenhum resultado encontrado");
    })
};

$(document).ready(function () {

    categoryId = $('#category').data('categoryid');
    subCategoryId = $('#subCategory').data('subcategoryid');

    $(".itemCategory").on("click", function () {
        var categoryName = $(this).text();
        categoryId = $(this).attr('id');     
        $(this).parents('.btn-group').find('#category').html(categoryName + "   " + "<span class='caret'></span>");
        $("#subCategory").html('Selecione uma sub categoria <span class="caret"></span>');    
        GetSubCategory(categoryId);
    });

    $(document).on("click", ".itemSubCategory", function () {
        var subCategoryName = $(this).text();
        subCategoryId = $(this).attr('id');
        $(this).parents('.btn-group').find('#subCategory').html(subCategoryName + "   " + "<span class='caret'></span>");
    });
});


//################################################

function Salvar() {   
    var img = [];
    $('.image').each(function (i) {
        img[i] = $(this).val();
    });  
    $.ajax({
        url: '/SimpleProduct/Salvar',
        data: {
            id: id,
            displayOnPage: $('#DisplayOnPage').prop('checked'),
            displayOnlyPage: $('#DisplayOnlyPage').prop('checked'),
            name: $('#name').val(),
            brand: $('#brand').val(),
            category: categoryId,
            subCategory: subCategoryId,
            model: $('#model').val(),
            price: $('#price').val(),
            img1: img[0],
            img2: img[1],
            img3: img[2],
            description: $('#description').val(),
            tags: $('#tags').val(),

            stName: toStyle($('#sname').text()),
            stBrand: toStyle($('#sbrand').text()),
            stCategory: toStyle($('#scategory').text()),
            stModel: toStyle($('#smodel').text()),
            stPrice: toStyle($('#sprice').text()),
            stDescription: toStyle($('#sdescription').text())
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
            name: {
                validators: {
                    notEmpty: {},
                    regexp: {
                        regexp: /^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+$/,
                        message: 'Apenas letras e números são permitidos'
                    },
                    stringLength: { min: 2, max: 32, message: 'O campo Nome deve conter entre 2 e 32 digitos' }
                }
            },
            brand: {
                validators: {
                    regexp: {
                        regexp: /^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+$/,
                        message: 'Apenas letras e números são permitidos'
                    },
                    stringLength: { min: 2, max: 32, message: 'O campo Marca deve conter entre 2 e 32 digitos' }
                }
            },    
            model: {
                validators: {
                    regexp: {
                        regexp: /^[0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+$/,
                        message: 'Apenas letras e números são permitidos'
                    },
                    stringLength: { min: 2, max: 32, message: 'O campo Modelo deve conter entre 2 e 32 digitos' }
                }
            },
            price: {
                validators: {
                    stringLength: { max: 6 }
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
                    stringLength: { min: 12, max: 512, message: 'O campo Descrição deve conter entre 12 e 512 digitos' }
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