
$(document).ready(function () {
    InitSerialize();
});

function InitSerialize() {

    var siteNumber = $("#dataSerialize").data('sitenumber');
    var controller = $("#dataSerialize").data('controller');
    var serialize = $("#dataSerialize").data('serialize').toLowerCase();
    
    if (serialize == 'true') {
        var controllers = controller.split(",");
        $.each(controllers, function (index, value) {
            Serialize(value, siteNumber);
        });
    };
};

function Serialize(controller, siteNumber) {
    var urlSerialize = "/" + controller + "/Serialize";
    $.ajax({
        url: urlSerialize,
        data: { siteNumber: siteNumber },
        type: 'POST',
        cache: false,
        dataType: "json"
    })
    .success(function (json) {
        if (json === "finalize") {
            console.log("finalize");
        }
    })
    .error(function (xhr, status) {
        alert("Erro na tentativa de serializar objeto");
    })
};