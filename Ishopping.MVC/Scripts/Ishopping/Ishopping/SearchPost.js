
$(function () {
    $("#txtTexto").autocomplete({
        minLength: 3,
        source: function (request, response) {                     
            $.getJSON('/AppView/GetTexto', request, function (data, status, xhr) {              
                response(data);
            });         
        }
    });
});