$(document).ready(function(){


 $("#owl-example").owlCarousel({
    // Most important owl features
    items : 4,
    pagination : true,
    paginationSpeed : 1000,
    navigation : true,
    navigationText : ["","<i class='fa fa-angle-right'></i>"],
    slideSpeed : 800,
 });

	$("#navigation").sticky({
		topSpacing : 75,
	});

	$('#nav').onePageNav({
		currentClass: 'current',
		changeHash: false,
		scrollSpeed: 15000,
		scrollThreshold: 0.5,
		filter: ':not(.Blog)',
		easing: 'easeInOutExpo'
	});

     $('#top-nav').onePageNav({
         currentClass: 'active',
         filter: ':not(.Blog)',
         changeHash: true,
         scrollSpeed: 1200
     });

    //Initiat WOW JS
     new WOW().init();


    // Contact form
     var form = $('#main-contact-form');
     form.submit(function (event) {
         event.preventDefault();
         var form_status = $('<div class="form_status"></div><br/>');
         $.ajax({
             url: $(this).attr('action'),
             data: $("#main-contact-form").serialize(),
             type: 'POST',
             cache: false,
             dataType: "json",
             beforeSend: function () {
                 form.prepend(form_status.html('<h4><i class="fa fa-spinner fa-spin"></i> Enviando Email...</h4>').fadeIn());
             }
         }).success(function (json) {
             form_status.html('<h4 class="text-success">Sua mensagem foi enviada</h4>').delay(3000).fadeOut();
         }).error(function (xhr, status) {
             form_status.html('<h4 class="text-danger">Não foi possivel enviar a mensagem</h4>').delay(3000).fadeOut();
         });
     });

});
