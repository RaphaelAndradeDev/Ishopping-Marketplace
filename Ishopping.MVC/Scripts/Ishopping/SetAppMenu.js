
function SetApplicationMenu(actionLink) {
    $.ajax({
        url: actionLink,
        type: 'POST',
        dataType: "json"
    })
    .success(function (data) {
        var itens = data.data.split(",");
        $.each(itens, function (index, value) {
            $("#" + value).removeClass("disabled");
        })
        var home = "/" + itens[0] + "/index/" + itens[1];
        $("#homePage").attr('href', home);
        $("#" + data.activeFor).addClass("active");
    })
    .error(function (xhr, status) {
        alert("Nenhum resultado encontrado");
    })
}