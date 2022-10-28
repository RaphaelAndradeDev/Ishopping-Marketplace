
$(document).ready(function () {
      
    var imgType = $('#data').data('imgtype');
    var imgSearch = $('#data').data('imgsearch');
    var imgController = $('#data').data('imgcontroller');
      
    var txt = "Essa imagem não pode ser deletada porque está sendo usada por um ou vários itens." +
              " Para deletar essa imagem primeiro delete os itens que a está usando." +
              " Va até Componentes, depois em " + imgType + " e procure pelo item com nome ou título ";

    var txtCard = "Essa imagem não pode ser deletada porque está sendo usada como Cartão de Visita." +
              " Para deletar essa imagem primeiro altere o item que a está usando." +
              " Va até Configurações, depois em Cartão de Visita e substitua a imagem ";

    function SearchShare(id) {
        $.ajax({
            url: '/ImageGallery/' + imgSearch,
            data: { id: id },
            type: 'POST',
            cache: false,
            dataType: "json"
        })
        .success(function (data) {
            if (data !== "") {
                $(".modal-body p").html(txt + '<b>' + data + '</b>');
                $("[name='delete']").hide();
                $('#myModal').modal('show');
            }
            else {
                $(".modal-body p").html('Você tem certeza que deseja deletar permanentemente essa imagem ?');
                $("[name='delete']").attr('href', "/ImageGallery/Delete/" + id + "?view=" + imgController);
                $("[name='delete']").show();
                $('#myModal').modal('show');
            }
        })
        .error(function (xhr, status) {
            alert("Erro na tentativa de salvar dados");
        })
    };      

    $("[name='getDelete']").on('click', function () {
        var id = $(this).val();
        switch (imgType) {
            case "Cartão de Visita":
                txt = txtCard;
                SearchShare(id);
                break;
            default:
                SearchShare(id);
        }
    });

});