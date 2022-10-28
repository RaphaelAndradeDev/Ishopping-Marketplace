// Hello.
//
// This is The Scripts used for ___________ Theme
//
//

function main() {

(function () {
   'use strict';

   /*====================================
    Page a Link Smooth Scrolling 
    ======================================*/
    $('a.page-scroll').click(function() {
        if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
          var target = $(this.hash);
          target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
          if (target.length) {
            $('html,body').animate({
              scrollTop: target.offset().top
            }, 900);
            return false;
          }
        }
      });

    /*====================================
    Menu Active Calling Scroll Spy
    ======================================*/
    $('body').scrollspy({ 
      target: '.navmenu',
      offset: 80,
    });


    /* ==============================================
	Testimonial Slider
	=============================================== */ 

	$(document).ready(function() {
	 
	  $("#testimonial").owlCarousel({
	 
	      navigation : false, // Show next and prev buttons
	      slideSpeed : 300,
	      paginationSpeed : 400,
	      singleItem:true,
	      autoHeight : true
	 
	      // "singleItem:true" is a shortcut for:
	      // items : 1, 
	      // itemsDesktop : false,
	      // itemsDesktopSmall : false,
	      // itemsTablet: false,
	      // itemsMobile : false
	 
	  });
	 
	});
 

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
	            form.prepend(form_status.html('<p><i class="fa fa-spinner fa-spin"></i> Enviando Email...</p>').fadeIn());
	        }
	    }).success(function (json) {
	        form_status.html('<p class="text-success">Sua mensagem foi enviada</p>').delay(3000).fadeOut();
	    }).error(function (xhr, status) {
	        form_status.html('<p class="text-danger">Não foi possivel enviar a mensagem</p>').delay(3000).fadeOut();
	    });
	});


}());


}
main();