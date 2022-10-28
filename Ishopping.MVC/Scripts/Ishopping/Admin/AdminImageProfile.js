

var token = $('[name=__RequestVerificationToken]').val();

var listChecked = [];

function imageChecked( id, siteNumber, fileType, fileName, checked, isBlock) {
    this.Id = id;
    this.SiteNumber = siteNumber;
    this.FileType = fileType;
    this.FileName = fileName;
    this.Checked = checked;
    this.IsBlock = isBlock;
}


function removeItemOfArray(imgId) {
    listChecked = $.grep(listChecked, function (img) { return img.Id != imgId; });
}

function createImgList(){
    $(".block").each(function () {
        var imgId = $(this).parents('.caption').find('[type="hidden"]').data("imgid");
        var siteNumber = $(this).parents('.caption').find('[type="hidden"]').data("sitenumber");
        var imgFileType = $(this).parents('.caption').find('[type="hidden"]').data("imgfiletype");
        var imgFileName = $(this).parents('.caption').find('[type="hidden"]').data("imgfilename");    
        var imgChecked = new imageChecked(imgId, siteNumber, imgFileType, imgFileName, true, false);
        listChecked.push(imgChecked);   
    })
}

$(".noCheck").on('click', function () {
    var imgId = $(this).parents('.caption').find('[type="hidden"]').data("imgid");
    var siteNumber = $(this).parents('.caption').find('[type="hidden"]').data("sitenumber");
    var imgFileType = $(this).parents('.caption').find('[type="hidden"]').data("imgfiletype");
    var imgFileName = $(this).parents('.caption').find('[type="hidden"]').data("imgfilename");

    $(this).removeClass("btn-default");
    $(this).addClass("btn-primary");
    $(this).parents('.caption').find('.block').removeClass("btn-danger").addClass("btn-default");
    
    removeItemOfArray(imgId);
    var imgChecked = new imageChecked(imgId, siteNumber, imgFileType, imgFileName, false, false);
    listChecked.push(imgChecked);
})

$(".block").on('click', function () {
    var imgId = $(this).parents('.caption').find('[type="hidden"]').data("imgid");
    var siteNumber = $(this).parents('.caption').find('[type="hidden"]').data("sitenumber");
    var imgFileType = $(this).parents('.caption').find('[type="hidden"]').data("imgfiletype");
    var imgFileName = $(this).parents('.caption').find('[type="hidden"]').data("imgfilename");

    $(this).removeClass("btn-default");
    $(this).addClass("btn-danger");
    $(this).parents('.caption').find('.noCheck').removeClass("btn-primary").addClass("btn-default");

    removeItemOfArray(imgId);
    var imgChecked = new imageChecked(imgId, siteNumber, imgFileType, imgFileName, true, true);
    listChecked.push(imgChecked);
})

$(document).ready(function () {
    createImgList();
});

$("#Salvar").on('click', function () {
    $.ajax({
        url: '/AdminCheckProfile/Salvar',
        data: {          
            imageChecked: JSON.stringify(listChecked)
        },
        type: 'POST',
        cache: false,
        headers: { "__RequestVerificationToken": token },
        dataType: "json"
    })
    .success(function (json) {
        location.reload();
    })
    .error(function (xhr, status) {
        $('#Status').html("Erro na tentativa de salvar dados");
    });    
});