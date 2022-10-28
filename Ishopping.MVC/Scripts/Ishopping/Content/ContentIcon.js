


function GetDefaultForm() {
    clear();
    $("#position").val(ps);
}


function disableFields(p) {
    var dis = list[p - 1];
    switch (dis) {
        case 1:
            $(".text-muted").text('Ícone: Font Awesome');
            break;
        case 2:          
            $(".text-muted").text('Ícone: Glyphicons');
            break;
        case 3:    
            $(".text-muted").text('Ícone: ElusiveIcons');
            break;
    }
    enableForm(p);
}


function GetPosition() {
    $.ajax({
        url: '/Icons/GetResultPs',       
        data: { viewCod: viewCod, ps: ps },
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            id = json.id;       
            $("#icon").val(json.icon);
            isValueNullOrEmpty(json.icon);
        }
        else {
            jsonFileNotFound(json);
        }
        disableFields(ps);
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de salvar dados");
    })
};

function GetText() {
    $.ajax({
        url: '/Icons/GetResultTxt',        
        data: {
            viewCod: viewCod,
            term: $("#txtTexto").val()
        },
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            id = json.Id;
            disableFields(json.position);
            $("#icon").val(json.icon);
            isValueNullOrEmpty(json.icon);
        }
        else {
            jsonFileNotFound(json);
        };        
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de salvar dados");
    })
};


function Salvar() {
    view = $(".views").text();
    if (view === "Selecione uma view") { return false; }
    $.ajax({
        url: '/Icons/Salvar',
        data: {
            id: id,
            viewCod: viewCod,
            position: $("#position").val(),
            icon: $("#icon").val()      
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
            icon: {
                validators: {               
                    stringLength: { min: 8, max: 32 }
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
};


