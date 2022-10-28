jQuery(document).ready(function() {
  

   $('#carouselHacked').carousel();

      //this code is for smooth scroll and nav selector
            $(document).ready(function () {
              $(document).on("scroll", onScroll);
              
              //smoothscroll
              $('a[href^="#"]').on('click', function (e) {
                  e.preventDefault();
                  $(document).off("scroll");
                  
                  $('a').each(function () {
                      $(this).removeClass('active');
                  })
                  $(this).addClass('active');
                
                  var target = this.hash,
                      menu = target;
                  $target = $(target);
                  $('html, body').stop().animate({
                      'scrollTop': $target.offset().top+2
                  }, 500, 'swing', function () {
                      window.location.hash = target;
                      $(document).on("scroll", onScroll);
                  });
              });
          });

          function onScroll(event){              
              $('.navbar-default .navbar-nav>li>a').each(function () {
                if ($(this).attr("href").length < 16) {
                    var currLink = $(this);
                    var refElement = $(currLink.attr("href"));                        
                        var scrollPos = $(document).scrollTop();
                        if (refElement.position().top <= scrollPos && refElement.position().top + refElement.height() > scrollPos) {
                            $('.navbar-default .navbar-nav>li>a').removeClass("active");
                            currLink.addClass("active");
                        }
                        else {
                            currLink.removeClass("active");
                        }
                    }                                     
              });
          }
     
     
     //this code is for animation nav
     jQuery(window).scroll(function() {
        var windowScrollPosTop = jQuery(window).scrollTop();

        if(windowScrollPosTop >= 150) {
          jQuery(".header").css({"background": "#B193DD",});
          jQuery(".top-header img.logo").css({"margin-top": "-40px", "margin-bottom": "0"});
          jQuery(".navbar-default").css({"margin-top": "-15px",});
        }
        else{
          jQuery(".header").css({"background": "transparent",});
           jQuery(".top-header img.logo").css({"margin-top": "-12px", "margin-bottom": "25px"});
           jQuery(".navbar-default").css({"margin-top": "12px", "margin-bottom": "0"});
          
        }
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
                 form.prepend(form_status.html('<h4><i class="fa fa-spinner fa-spin"></i> Enviando Email...</h4>').fadeIn());
             }
         }).success(function (json) {
             form_status.html('<h4 class="text-success">Sua mensagem foi enviada</h4>').delay(3000).fadeOut();
         }).error(function (xhr, status) {
             form_status.html('<h4 class="text-danger">Não foi possivel enviar a mensagem</h4>').delay(3000).fadeOut();
         });
     });
     
});


// Contact form
$(document).ready(function () {
    $("#hideForm").on('click', function () {
        $(".contact-caption").toggle();
    });
});

//Google Map
var latitude = $('#map').data('latitude')
var longitude = $('#map').data('longitude')
function initMap() {

    var myLatLng = new google.maps.LatLng(latitude, longitude);
    
    var mapOptions = {
        zoom: 16,
        center: myLatLng,
        disableDefaultUI: true,    
        scrollwheel: false,
        navigationControl: true,     
        scaleControl: false,
        draggable: true,
    };

    var mapElement = document.getElementById('map');
    var map = new google.maps.Map(mapElement, mapOptions);
    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(latitude, longitude),
        map: map
    });
}