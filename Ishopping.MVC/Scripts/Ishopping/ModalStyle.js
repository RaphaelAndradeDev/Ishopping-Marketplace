

// Modal de estilo ########################################
function SetStyleModal(itemId) {
    var item = $('#' + itemId).text();
    $('#sitem').val(item.split(","));
    $('#styleModal').modal('show');
    $('.selectpicker').selectpicker('render');
}

function StyleSave() {
    var style = $("#sitem").val();
    if (style.length != 0) {
        $("#" + itemId).text(style)
    }
}

function toStyle(style) {
    if (!style || !style.length)
        return "SemEstilo";

    style = style.toString();
    style = style.replace(",SemEstilo", "");
    style = style.replace("SemEstilo,", "");
    return style;
}

$('.bntStyle').on('click', function () {  
    itemId = $(this).parents(".row").find("small span").attr("id");
    SetStyleModal(itemId);    
});



