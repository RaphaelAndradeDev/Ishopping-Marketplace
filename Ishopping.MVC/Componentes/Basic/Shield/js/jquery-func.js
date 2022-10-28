!function ($) {
	//=================================== scroll  ===================================//

$body.scrollspy({
      target: '#navbar-main',
      offset: navHeight
    })

    $window.on('load', function () {
      $body.scrollspy('refresh')
    })

    $('#navbar-main [href=#]').click(function (e) {
      e.preventDefault()
    })    
};

$(document).ready(function () {
    // Contact form
    var form = $('#main-contact-form');
    form.submit(function (event) {
        event.preventDefault();
        var form_status = $('<div class="form_status"></div>');
        $.ajax({
            url: $(this).attr('action'),
            data: $("#main-contact-form").serialize(),
            type: 'POST',
            cache: false,
            dataType: "json",
            beforeSend: function () {
                form.prepend(form_status.html('<p>Enviando Email...</p>').fadeIn());
            }
        }).success(function (json) {
            form_status.html('<p class="text-success">Sua mensagem foi enviada</p>').delay(3000).fadeOut();
        }).error(function (xhr, status) {
            form_status.html('<p class="text-danger">N�o foi possivel enviar a mensagem</p>').delay(3000).fadeOut();
        });
    });
});



