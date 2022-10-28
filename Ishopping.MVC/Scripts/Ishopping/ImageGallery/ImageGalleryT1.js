

$(document).ready(function () {

    var viewCod;
    var filetype = $('#data').data('filetype');
    var imgController = $('#data').data('imgcontroller');    
    
    // Alter position
    $('#alt').click(function () {
        var p = "0";
        $('input[type="number"]').each(function () {
            p += "," + ($(this).val());
        });
        $.ajax({
            url: '/ImageGallery/Edit',
            contentType: 'application/html; charset=utf-8',
            data: { p: p, t: filetype },
            type: 'GET',
            dataType: 'html'
        })
        .success(function () {      
            location.reload();
        })
        .error(function (xhr, status) {
            alert('Erro na tentativa de alterar posições');
        })
    });

    // Load Views
    $("#load").on('click', function () {
        var vName = $("#views").text();
        vName = vName.trim();
        if (vName !== "Selecione uma view") {
            GetImagePartial();
        }
    });        
   
    // Dropdown config
    $('.dropdown-toggle').dropdown();
    $(".dropdown-menu li a").click(function () {
        var selText = $(this).text();
        viewCod = $(this).attr('id');
        $(this).parents('.btn-group').find('.dropdown-toggle').html(selText + ' <span class="caret"></span>');
    });

    // Add image
    $("#addImg").on('click', function () {
        var vName = $("#views").text();
        vName = vName.trim();
        if (vName !== "Selecione uma view") {
            location.href = '/ImgUpload/ImageUpLoad/?fileType=' + filetype + '&' + 'viewCod=' + viewCod;
        }
    });

    // Delete image  
    $(document).on("click", "[name='getDelete']", function () {
        var id = $(this).val();    
        $("[name='delete']").attr('href', "/ImageGallery/Delete/" + id + "?view=" + imgController);
        $('#myModal').modal('show');
    });

    function GetImagePartial() {
        $.ajax({
            url: '/ImageGallery/GetImagePartial',
            contentType: 'application/html; charset=utf-8',
            data: { fileType: filetype, viewCod: viewCod },
            type: 'GET',
            dataType: 'html'
        })
        .success(function (result) {
            $('#imageViews').html(result);
            InitSerialize();
        })
        .error(function (xhr, status) {
            alert('Erro na tentativa de buscar views ' + xhr + status);
        })
    };

});









