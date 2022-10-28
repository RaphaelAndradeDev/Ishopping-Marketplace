

// Autocomplete ###############################

$(function () {
    $("#txtTexto").autocomplete({
        source: actionGetTexto,
        minLength: 2
    });
});