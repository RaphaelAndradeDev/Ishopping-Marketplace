


// Variaveis

var nps, view, viewCod, ps, pos, term, list;


// Funções 

function isNullOrEmpty(value) {
    return (value == null || value === '');
}

function enableForm(postition) {
    $('.texto,.sub').prop('disabled', false);
    $("#position").val(postition);
}

function disabledForm() {
    $('.texto,.sub,[name="position"]').prop('disabled', true);
}

function isValueNullOrEmpty(txt1, txt2, txt3) { 
    if (!txt1 && !txt2 && !txt3) {        
        $('#Status').html("<strong>Item com valor nulo ou vazio</strong>");
        $('#Status').fadeIn(500);
    }
}


// Metodos

$(document).ready(function () {


    // Início 
    disabledForm();
    enableSearch(false);
    $('.dropdown-toggle').dropdown();


    // Autocomplete 
    $("#txtTexto").autocomplete({    
        source: function (request, response) {
            minLength: 2,
            $.ajax({
                url: actionGetTexto,
                dataType: "json",
                data: {
                    term: request.term,
                    viewCod: viewCod
                },
                success: function (data) {
                    response(data);
                }
            });
        }
    });


    // Tratamento dropdown
    $(".dp li a").click(function () {
        var selText = $(this).text();
        viewCod = $(this).attr('id');
        nps = $(this).attr('name');
        validar();
        $(this).parents('.btn-group').find('.views').text(selText);       
        id = guidEmpity;
        enableSearch(true);
    });

    $(".dps li a").click(function () {
        var selText = $(this).text();
        viewCod = $(this).attr('id');
        var string = $(this).attr('name');
        list = string.split(',').map(function (n) {
            return Number(n);
        });
        nps = list.length;
        validar();
        $(this).parents('.btn-group').find('.views').text(selText);
        id = guidEmpity;
        enableSearch(true);
    });


    // Tratamento butão
    $("#btnPosition").on('click', function () {
        view = $(".views").text();
        if (view === "Selecione uma view") { return false; }
        ps = $("#txtPosition").val();
        ps = parseInt(ps)       
        if (ps > 0 && ps <= nps) { GetPosition(); }
    })


    // Tratamento butão
    $("#btnTexto").on('click', function () {
        view = $(".views").text();
        if (view === "Selecione uma view") { return false; }      
        GetText();
    })


    // Tratamento butão
    $("#anterior").on('click', function () {
        pos = $("#position").val();
        view = $(".views").text();
        if (view === "Selecione uma view" || parseInt(pos) <= 1) { return false; }
        $('#Status').fadeOut(500);
        ps = parseInt(pos) - parseInt(1);
        if (ps > 0) { GetPosition(); };
    })


    // Tratamento butão
    $("#proximo").on('click', function () {
        pos = $("#position").val();
        view = $(".views").text();
        if (view === "Selecione uma view" || parseInt(pos) >= nps) { return false; }
        $('#Status').fadeOut(500);
        ps = parseInt(pos) + parseInt(1);
        if (ps <= nps) { GetPosition(); };
    })


    $("#deletar").click(function () {
        ps = $("#position").val();
    });

});


