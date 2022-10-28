

// Autocomplete ###############################
$(document).ready(function () {
    $("#txtTexto").autocomplete({
        source: function (request, response) {
            minLength: 2,
            $.ajax({
                url: actionGetTexto,
                dataType: "json",
                data: {
                    term: request.term,
                    ps: $("#txtPosition").val()
                },
                success: function (data) {              
                    response(data);
                }
            });
        },
    });
});