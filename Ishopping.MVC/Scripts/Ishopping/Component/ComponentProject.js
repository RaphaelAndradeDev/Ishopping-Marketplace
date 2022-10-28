


function GetDefaultForm() {
    GetDefaoutStyle();
    clear();
}

function GoToOption() {
    window.location.href = '/ProjectOption/Alter';
}

function GetDefaoutStyle() {
    $.ajax({
        url: '/Project/GetDefaoutStyle',
        data: {},
        type: 'POST',
        dataType: "json"
    })
    .success(function (json) {
        if (json.FileFound) {
            $("#sname").text(json.name);
            $("#stitle").text(json.title);            
            $("#sclient").text(json.client);
            $("#sdescription").text(json.description);
            $("#scategory").text(json.category);
            $("#steam").text(json.team);
        }
        else {
            jsonFileNotFound();
        }
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de busca");
    });
};

// ###########################################

$('#datetimePicker').datetimepicker({
    locale: 'pt-BR'
});


//################################################

function Salvar() {
    var img = [];
    $('.image').each(function (i) {
        img[i] = $(this).val();
    });
    $.ajax({
        url: '/Projects/Salvar',
        data: {
            id: id,
            name: $("#name").val(),
            date: $("#date").val(),
            title: $("#title").val(),
            client: $("#client").val(),
            webSite: $("#website").val(),
            category: $("#category").val(),
            description: $("#description").val(),
            team: $("#team").val(),
            urlVideo: $("#video").val(),
            img1: img[0],
            img2: img[1],
            img3: img[2],
            stName: toStyle($("#sname").text()),        
            stTitle: toStyle($("#stitle").text()),
            stClient: toStyle($("#sclient").text()),
            stCategory: toStyle($("#scategory").text()),
            stDescription: toStyle($("#sdescription").text()),
            stTeam: toStyle($("#steam").text())
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
            name: {
                validators: {
                    stringLength: { max: 64 }
                }
            },
            date: {
                validators: {
                    date: {
                        format: 'DD/MM/YYYY h:m'
                    }
                }
            },
            client: {
                validators: {
                    stringLength: { max: 256 }
                }
            },
            website: {
                validators: {
                    uri: { allowLocal: false }
                }
            },
            description: {
                validators: {
                    stringLength: { max: 512 }
                }
            },
            category: {
                validators: {
                    stringLength: { max: 32 }
                }
            },
            team: {
                validators: {
                    stringLength: { max: 256 }
                }
            },
            video: {
                validators: {
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
        Salvar();
    });

    $('#datetimePicker')
    .on('dp.change dp.show', function (e) {
        // Validate the date when user change it
        $('#defaultForm')
         // Get the bootstrapValidator instance
         .data('bootstrapValidator')
         // Mark the field as not validated, so it'll be re-validated when the user change date
         .updateStatus('date', 'NOT_VALIDATED', null)
         // Validate the field
         .validateField('date');
    });
});