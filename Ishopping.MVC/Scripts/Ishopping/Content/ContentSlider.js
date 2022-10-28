

var viewCod, ps, maxps, item, slideType, slideName, slideClass;


function GetDefaultForm() {    
    clear();
    id = guidEmpity;
    $("#Info").empty();
    $("#txtSlider").val(SetPosition());
    $("input").not("[name=txtsearch],[name=txtSlider]").prop('disabled', true);
    $("button[type=submit], .btn-default,#deletar").prop('disabled', true);    
    $("#btnSliderName").html('Selecione um slider &nbsp&nbsp<span class="caret"></span>');
    $("#btnSliderClass").html('Selecione a classe do slider &nbsp&nbsp<span class="caret"></span>');
    $('#fz').html("px &nbsp&nbsp<span class='caret'></span>");
    $("#btnSliderName,#btnSliderClass,#novo,.txt").prop('disabled', true);
    if (viewCod) GetSlideType();
}

// Início ############################### txtItem
$(document).ready(function () {
    GetDefaultForm();
});

// Load fonts
$(document).ready(function () {
    var fonts = [
        'medium_grey',
        'small_text',
        'medium_text',
        'large_text',
        'very_large_text',
        'very_big_white',
        'very_big_black',
        'modern_medium_fat',
        'modern_medium_fat_white',
        'modern_medium_light',
        'modern_big_bluebg',
        'modern_big_redbg',
        'modern_small_text_dark',
        'thinheadline_dark',
        'thintext_dark',
        'largeblackbg',
        'largepinkbg',
        'largewhitebg',
        'largegreenbg',
        'excerpt',
        'large_bold_grey',
        'medium_thin_grey',
        'small_thin_grey',
        'lightgrey_divider',
        'large_bold_darkblue',
        'medium_bg_darkblue',
        'medium_bold_red',
        'medium_light_red',
        'medium_bg_red',
        'medium_bold_orange',
        'medium_bg_orange',
        'large_bold_white',
        'medium_light_white',
        'mediumlarge_light_white',
        'mediumlarge_light_white_center',
        'medium_bg_asbestos',
        'medium_light_black',
        'large_bold_black',
        'mediumlarge_light_darkblue',
        'small_light_white',
        'large_bg_black',
        'mediumwhitebg'   
    ];
    $.each(fonts.sort(), function (index, value) {
        $("#ddmCaptions").append('<li><a>' + value + '</a></li>');
    });
});

// ##########################################

function SetPosition() {
    ps = $("#txtSlider").val();
    if (ps) {
        ps = parseInt(ps)
        if (ps >= 1 && ps <= maxps) {
            return ps;        
        } else {
            return 1;
        }
    } else {
        return 1;
    }
};

// ##########################################

function GetSlideType() {
    $.ajax({
        url: '/Slider/GetSlideType',
        type: 'POST',
        data: { viewCod: viewCod },
        dataType: "json"
    })
    .success(function (data) {
        $("#ddmSliderType").empty();
        $("#ddmSliderName").empty();
        $("#ddmSliderClass").empty();
        maxps = data.maxps;
        $(data.admSt).each(function (index, item) {
            $("#ddmSliderType").append("<li><a name='SliderType' id='" + item.Key + "'>" + item.Value + "</a></li>")
        });
        $("#btnSelect").text('Selecione 1/' + maxps);
        $("#txtSlider").attr({ "max": + maxps, "placeholder": "slider max " + maxps });
        $("#btnSliderType,#novo").prop('disabled', false);
    })
    .error(function (xhr, status) {
        alert("Nenhum resultado encontrado");
    })
};

// ##########################################

function GetSlider() {
    $.ajax({
        url: '/Slider/GetResult',
        type: 'POST',
        data: { viewCod: viewCod, ps: ps, item: item },
        dataType: "json"
    })
    .success(function (data) {
        if (ps <= data.maxps) {
            id = data.cs.Id;           
            $("#btnSliderType").html(data.st + '&nbsp&nbsp<span class="caret"></span>');
            $("#btnSliderName").html(data.cs.SliderName + '&nbsp&nbsp<span class="caret"></span>');
            $("#btnSliderClass").html(data.cs.SliderClass + '&nbsp&nbsp<span class="caret"></span>');
            $("#Incoming").val(data.cs.Incoming);
            $("#Outgoing").val(data.cs.Outgoing);
            $("#DataStart").val(data.cs.DataStart);
            $("#DataEnd").val(data.cs.DataEnd);
            $("#DataX").val(data.cs.DataX);
            $("#DataY").val(data.cs.DataY);
            $("#DataHoffset").val(data.cs.DataHoffset);
            $("#DataVoffset").val(data.cs.DataVoffset);
            $("#DataSpeed").val(data.cs.DataSpeed);
            $("#DataEndSpeed").val(data.cs.DataEndSpeed);
            $("#DataEasing").val(data.cs.DataEasing);
            $("#DataEndEasing").val(data.cs.DataEndEasing);
            $("#DataSplitin").val(data.cs.DataSplitin);
            $("#DataSplitout").val(data.cs.DataSplitout);
            $("#DataElementdelay").val(data.cs.DataElementdelay);
            $("#DataEndelementdelay").val(data.cs.DataEndelementdelay);
            $("#DataImgWidth").val(data.cs.DataImgWidth);
            $("#DataImgHeight").val(data.cs.DataImgHeight);
            $("#DataImgZindex").val(data.cs.DataImgZindex);
            $("#Caption").val(data.cs.Caption);
            $("#sttext").text(data.cs.StyleClass);              
            $("#Text").val(data.cs.Text);      
            $("#Url").val(data.cs.Url);
            $("#ImageFileName").val(data.cs.ImageFileName);

            $("#ddmSliderType").empty();
            $("#ddmSliderName").empty();
            $("#ddmSliderClass").empty();
            $(data.admSt).each(function (index, item) {
                $("#ddmSliderType").append("<li><a name='SliderType' id='" + item.Key + "'>" + item.Value + "</a></li>")
            });                    

            $("input, button").prop('disabled', false);
            $("#btnSliderName,#btnSliderClass").prop('disabled', true);            
            slideType = data.cs.SliderType;
            slideName = data.cs.SliderName;
            slideClass = data.cs.SliderClass;
            selectTxt(slideType);      
        }
        else {
            alert("Não existe nenhum slider para posição " + ps + ". O número máximo de slider(s) para essa view é " + data.maxps + ", e o número máximo de itens é 12");
        }
    })
    .error(function (xhr, status) {
        alert("Nenhum resultado encontrado");
    })
};

// ##########################################

function GetSlideName() {
    $.ajax({
        url: '/Slider/GetSlideName',
        type: 'POST',
        data: { viewCod: viewCod, slideType: slideType },
        dataType: "json"
    })
    .success(function (data) {
        $("#ddmSliderName").empty();
        $("#ddmSliderClass").empty();
        $(data).each(function (index, item) {
            $("#ddmSliderName").append("<li><a name='SliderName'>" + item + "</a></li>")
        });
        $("#btnSliderName").prop('disabled', false);
    })
    .error(function (xhr, status) {
        alert("Nenhum resultado encontrado");
    })
};

// ##########################################

function GetSlideClass() {
    $.ajax({
        url: '/Slider/GetSlideClass',
        type: 'POST',
        data: { viewCod: viewCod, slideType: slideType, slideName: slideName },
        dataType: "json"
    })
    .success(function (data) {
        $("#ddmSliderClass").empty();
        $(data).each(function (index, item) {
            $("#ddmSliderClass").append("<li><a name='SliderClass'>" + item + "</a></li>")
        });
    })
    .error(function (xhr, status) {
        alert("Nenhum resultado encontrado");
    })
};

//################################################

$(document).ready(function () {
    $("[name=search]").on('click', function () {
        ps = $("#txtSlider").val();
        ps = parseInt(ps)
        item = $("#txtItem").val();
        item = parseInt(item)
        if (ps > 0 && ps < 8 && item > 0 && item < 12) { GetSlider(); }
    })
});

// Salvar  ###################################

function Salvar() { 
    ps = $("#txtSlider").val();
    ps = parseInt(ps);
    if (ps >= 1 && ps <= maxps) { salvarS(); }
}

function salvarS() {
    var form = $("#defaultForm"),
        url = '/Slider/Salvar',
        type = 'POST',
        data = {};
    form.find("[name]").not("[name=__RequestVerificationToken]")
        .each(function (index, value) {
            var form = $(this),
            name = form.attr('name'),
            value = form.val();
            data[name] = value;
        });

    data['Id'] = id;
    data['Position'] = ps;
    data['ViewCod'] = viewCod;
    data['SliderType'] = slideType;
    data['SliderName'] = slideName;
    data['SliderClass'] = slideClass;
    data['StyleClass'] = $("#sttext").text();
    myJSON = JSON.stringify(data);

    $.ajax({
        url: url,
        data: { data: myJSON },
        type: type,
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

// ########################################## 

$(document).ready(function () {

    $("#ddmViews li a").click(function () {        
        var selText = $(this).text();
        viewCod = $(this).attr('id');
        $(this).parents('.btn-group').find('.views').text(selText);
        GetDefaultForm();
    });    

    $("#ddmCaptions li a").click(function () {
        var selText = $(this).text();
        $(this).parents('.input-group').find('#Caption').val(selText);
    });

    $(".dropdown-menu-right li a").click(function () {
        var selText = $(this).text();
        $(this).parents('.input-group').find('.ddm').html(selText + "&nbsp&nbsp<span class='caret'></span>").val(selText);
    });
    
    $(".dropdown-menu li a").click(function () {
        var selText = $(this).text();
        $(this).parents('.btn-group').find('.ddm').text(selText).val(selText);
    });

});

// ##########################################

$(document).ready(function () {
    $(document).on("click", "[name='SliderType']", function () {
        var selText = $(this).text();
        slideType = $(this).attr('id');
        $(this).parents('.btn-group').find('.sltype').html(selText + "&nbsp&nbsp<span class='caret'></span>");
        $("#btnSliderName").html('Selecione um slider &nbsp&nbsp<span class="caret"></span>');
        $("#btnSliderClass").html('Selecione a classe do slider &nbsp&nbsp<span class="caret"></span>');
        $("#btnSliderName,#btnSliderClass").prop('disabled', true);
        selectTxt(slideType);
        GetSlideName();
    });

    $(document).on("click", "[name='SliderName']", function () {
        slideName = $(this).text();
        $(this).parents('.btn-group').find('.slname').html(slideName + "&nbsp&nbsp<span class='caret'></span>");
        $("#btnSliderClass").html('Selecione a classe do slider &nbsp&nbsp<span class="caret"></span>');
        $("#btnSliderClass").prop('disabled', false);
        GetSlideClass();
    });

    $(document).on("click", "[name='SliderClass']", function () {
        slideClass = $(this).text();
        $(this).parents('.btn-group').find('.slclass').html(slideClass + "&nbsp&nbsp<span class='caret'></span>");
    });
});


// Desabilita campos de texto  
function selectTxt(slideType) {
    $("#Info").empty();
    $(".tag,.txt,.st,.config,.textconfig,.imgconfig").prop('disabled', true);
    switch (parseInt(slideType)) {
        case 1:
            $(".tag,.st,.config,#Text,#Caption,#btnCaptions,#Url").prop('disabled', false); //button
            break;
        case 2:
            $(".tag,.st,.config,.textconfig,#Text").prop('disabled', false);  // text
            break;
        case 3:
            $("#Url").prop('disabled', false);  // video
            break;
        case 4:
            $(".config,.imgconfig,#ImageFileName").prop('disabled', false);  // image
            break;
    };
}



// Regras de validação ########################### 

// form validate 

function ValidateTxt(slideType) {

    if (!viewCod) {
        $('#Status').html("<strong>Por favor selecione uma view!</strong>");
        return false;
    }
     
    $("#Info").empty();

    var result = "";
    var htmlIn = "<p class='Color1'>";
    var htmlOut = "</p>";

    switch (parseInt(slideType)) {
        case 1:
            result += PositionValidate(htmlIn, htmlOut);         
            result += TextValidate(htmlIn, htmlOut); 
            break;         
        case 2:
            result += PositionValidate(htmlIn, htmlOut);       
            result += TextValidate(htmlIn, htmlOut);
           break;
        case 3:
            result += UrlValidate(htmlIn, htmlOut)
            break;
        case 4:
            result += PositionValidate(htmlIn, htmlOut);
            result += ImageValidate(htmlIn, htmlOut);      
            break;
    };

    if (result) {
        $("#Info").append(result);
        return false;
    }
    return true;
};

// fields validate 

function TextValidate(htmlIn, htmlOut) {
    var result = "";  
    var Text = $('#Text').val();
    return result += isNull(Text, "Texto", htmlIn, htmlOut);
}

function PositionValidate(htmlIn, htmlOut) {
    var result = "";
    var dataX = $('#DataX').val();
    var dataY = $('#DataY').val();

    result += isNull(dataX, "Posição X", htmlIn, htmlOut);
    if (isNaN(dataX)) {
        result += strValidate(dataX, ['left','center','right'], "Posição X", htmlIn, htmlOut);
    } else {
        result += intValidate(dataX, -2500, 2500, "Posição X", htmlIn, htmlOut)
    }

    result += isNull(dataY, "Posição Y", htmlIn, htmlOut);
    if (isNaN(dataY)) {
        result += strValidate(dataY, ['top','center','bottom'], "Posição Y", htmlIn, htmlOut);
    } else {
        result += intValidate(dataY, -2500, 2500, "Posição Y", htmlIn, htmlOut)
    }
    return result;
}

function UrlValidate(htmlIn, htmlOut) {
    var result = "";
    var url = $('#Url').val();
    return result += isNull(url, "Url", htmlIn, htmlOut);
}

function ImageValidate(htmlIn, htmlOut) {
    var result = "";
    var dataImgWidth = $('#DataImgWidth').val();
    var dataImgHeight = $('#DataImgHeight').val();
    var dataImgZindex = $('#DataImgZindex').val();
    var imgFileName = $('#ImageFileName').val();
    result += intValidate(dataImgWidth, 10, 800, "Imagem Largura", htmlIn, htmlOut);
    result += intValidate(dataImgHeight, 10, 800, "Imagem Altura", htmlIn, htmlOut);
    result += intValidate(dataImgZindex, 1, 24, "Imagem Z-Index", htmlIn, htmlOut);
    return result += isNull(imgFileName, "Nome da imagem", htmlIn, htmlOut);
}

// function validate 

function isNull(str, field, htmlIn, htmlOut) {
    var result = "";  
    if (!str) result += htmlIn + field + " não pode ser nulo" + htmlOut;
    return result;
}

function strValidate(str, obj, field, htmlIn, htmlOut) {      
    var result = "";  
    if (jQuery.inArray(str, obj) == -1) {    
        result += htmlIn + " argumento inválido para o campo " + field + htmlOut; 
    }
    return result;
}

function intValidate(int, min, max, field, htmlIn, htmlOut) {   
    var result = "";
    if (!int) int = 0;
    if (Number.isInteger(parseInt(int)) && (int < min || int > max)) {     
        result = htmlIn + "digite um número entre " + min + " e " + max + " para " + field + htmlOut;
    }
    return result;
}

// ########################### 

$(document).ready(function () {
    $('#defaultForm').bootstrapValidator({
        message: 'This value is not valid',
        fields: {
            txtSlider: {
                validators: {
                    notEmpty: {}                   
                }
            },
            DataX: {
                validators: {
                    notEmpty: {}               
                }
            },
            DataY: {
                validators: {
                    notEmpty: {}
                }
            },
            DataHoffset: {
                validators: {
                    between: { min: -2500, max: 2500 }
                }
            },
            DataVoffset: {
                validators: {
                    between: { min: -2500, max: 2500 }
                }
            },
            DataStart: {
                validators: {
                    between: { min: 1, max: 20000 }
                }
            },
            DataSpeed: {
                validators: {
                    between: { min: 100, max: 20000 }
                }
            },
            DataEndSpeed: {
                validators: {
                    between: { min: 100, max: 20000 }
                }
            },
            FontSize: {
                validators: {
                    between: { min: 1, max: 200 }
                }
            },
            txtBorderWidth: {
                validators: {
                    between: { min: 1, max: 32 }
                }
            },
            txtSpacing: {
                validators: {
                    between: { min: 1, max: 64 }
                }
            },
            Color: {
                validators: {
                    hexColor: {}
                }
            },
            BackgroundColor: {
                validators: {
                    hexColor: {}
                }
            },
            borderColor: {
                validators: {
                    hexColor: {}
                }
            },
            Text: {
                validators: {
                    stringLength: { max: 128 }
                }
            },         
            ImageFileName: {
                validators: {
                    stringLength: { max: 15 }
                }
            },
            Url: {
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
        if (ValidateTxt(slideType)) {
            Salvar();
        };
    });

});