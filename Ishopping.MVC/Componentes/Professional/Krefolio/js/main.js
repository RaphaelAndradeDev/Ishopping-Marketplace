$(document).ready(function () {
  'use strict';
  /* ========================================================================
     Fullscreen burger menu
   ========================================================================== */
  $(".menu-trigger, .mobilenav").click(function () {
    $(".mobilenav").fadeToggle(500);
  });
  $(".menu-trigger, .mobilenav").click(function () {
    $(".top-menu").toggleClass("top-animate");
    $(".mid-menu").toggleClass("mid-animate");
    $(".bottom-menu").toggleClass("bottom-animate");
  });

  /* ========================================================================
     On click menu item animate to the section
   ========================================================================== */
  $(".mobilenav li, .back-to-top").on('click', function() {
    var target = $(this).data('rel');
    var $target = $(target);
    $('html, body').stop().animate({
        'scrollTop': $target.offset().top
    }, 900, 'swing');
  });

  /* Header Height Control
   ========================================================================== */
  var height = $(window).height();
  if(height<600) {
    height = 600;
  }
  $('header').css({
    'minHeight': 0,
    'maxHeight': 'none',
    'height': height
  });
  /* ========================================================================
   Header carousel
   ========================================================================== */
  $('.carousel').carousel({
    interval: 50000
  })

  /* ========================================================================
     Wow Animation
   ========================================================================== */
  var wow = new WOW({
    mobile: false
  });
  wow.init();

  /* ========================================================================
     Collapse event
   ========================================================================== */
  $('.panel-collapse').on('shown.bs.collapse', function () {
   $(this).parent().find(".state").html('<strong>-</strong>');
  });

  $('.panel-collapse').on('hidden.bs.collapse', function () {
    $(this).parent().find(".state").html('<strong>+</strong>');
  });

  /* ========================================================================
     Animated Skill Bar
   ========================================================================== */
  $('.skill-bar li').each(function (i) {
    $(this).appear(function() {
      $(this).animate({opacity:1,left:"0px"},1200);
      var b = $(this).find(".wrapper span").attr("data-width");
      $(this).find("span").animate({
      width: b + "%"
      }, 1700, "swing");
    });
  });

  /* ========================================================================
    Member Skill chart
   ========================================================================== */
    for(var i=1; i<=16; i++) { // 16 for 4 members | 4 x 4 = 16
      $('#skill-' + i).circliful();
    }

  /* ========================================================================
    Testimonial Carousel
   ========================================================================== */
  var testimonialCarousel = $("#testimonial-carousel");
  testimonialCarousel.owlCarousel({
    autoPlay : 5000,
    stopOnHover : true,
    slideSpeed  :  1000,
    paginationSpeed : 500,
    goToFirstSpeed : 2000,
    singleItem : true,
    responsive : true,
    addClassActive : true,
    navigation: false
  });

  /* ========================================================================
     Nivo Lightbox
   ========================================================================== */
  $('.portfolio a').nivoLightbox({
    effect: 'fall'
  });

  /* ========================================================================
    Portfolio Filter
   ========================================================================== */
  var container = $('.portfolio-wrapper'); // portfoolio container

  container.isotope({
      itemSelector: '.portfolio-item',
      animationEngine: 'best-available',
      animationOptions: {
          duration: 200,
          queue: false
      },
      layoutMode: 'fitRows'
  });

  // sort items on button click
  $('.filters a').on( 'click', function() {
    $('.filters a').removeClass('active');
    $(this).addClass('active');
    var filterValue = $(this).attr('data-filter');
    container.isotope({
      filter: filterValue
    });
    initIsotope();
    return false;
  });

  // Split columns for different size layout
  function splitColumns() {
      var windowWidth = $(window).width(),
      columnNumber = 1; //  default column number
      if (windowWidth > 1200) {
          columnNumber = 4;
      } else if (windowWidth > 767) {
          columnNumber = 3;
      } else if (windowWidth > 600) {
          columnNumber = 2;
      }
      return columnNumber;
  }
  // Set width for portfolio item
  function setColumns() {
    var windowWidth = $(window).width(),
        columnNumber = splitColumns(),
        postWidth = Math.floor(windowWidth / columnNumber);

    container.find('.portfolio-item').each(function() {
        $(this).css({
            width: postWidth + 'px'
        });
    });
  }
  // initialize isotope
  function initIsotope() {
      setColumns();
      container.isotope('layout');
  }
  container.imagesLoaded(function() {
      setColumns();
  });
  $(window).bind('resize', function() {
      initIsotope();
  });
  $(window).load(function(){
    initIsotope();
  });


  /* ========================================================================
     Component: Contact Form
   ========================================================================== */

    function isValidEmail(emailAddress) {
        var pattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
        return pattern.test(emailAddress);
    };

    $("#contact-form").submit(function (e) {
        e.preventDefault();
        var mailTo = $("#mailTo").val();
        var name = $("#first-name").val();
        var phone = $("#last-name").val();
        var email = $("#email").val();
        var subject = $("#project-name").val();
        var message = $("#description").val();

        if (isValidEmail(email) && (message.length > 1) && (email.length > 1)) {
            $.ajax({                
                url: "/AppServices/EmailC",
                data: {
                    siteNumber: mailTo,
                    email: email,
                    name: name,
                    phone: phone,
                    subject: subject,
                    message: message
                },
                type: 'POST',
                cache: false,
                dataType: "json",
                success: function () {
                    notie.alert(1, 'Sua mensagem foi enviada.', 2.5);
                    $("#contact-form").val("");
                }
            });
        } else {
            notie.alert(3, 'Sua mensagem n?o pode ser enviada.', 2.5);
        }

        return false;
    });
});

/* ========================================================================
   Component: Map
 ========================================================================== */

function initMap() {
    var lat = $('#map-container').data('latitude')
    var lng = $('#map-container').data('longitude')
    var myLatlng = new google.maps.LatLng(lat, lng);
    var mapOptions = {
        zoom: 16,
        center: myLatlng,
        disableDefaultUI: true,
        zoomControl: true,
        scrollwheel: false,
        navigationControl: true,
        mapTypeControl: true,
        scaleControl: false,
        draggable: true,        
        styles: [{ featureType: "landscape", stylers: [{ saturation: -100 }, { lightness: 65 }, { visibility: "on" }] }, { featureType: "poi", stylers: [{ saturation: -100 }, { lightness: 51 }, { visibility: "simplified" }] }, { featureType: "road.highway", stylers: [{ saturation: -100 }, { visibility: "simplified" }] }, { featureType: "road.arterial", stylers: [{ saturation: -100 }, { lightness: 30 }, { visibility: "on" }] }, { featureType: "road.local", stylers: [{ saturation: -100 }, { lightness: 40 }, { visibility: "on" }] }, { featureType: "transit", stylers: [{ saturation: -100 }, { visibility: "simplified" }] }, { featureType: "administrative.province", stylers: [{ visibility: "off" }]/**/ }, { featureType: "administrative.locality", stylers: [{ visibility: "off" }] }, { featureType: "administrative.neighborhood", stylers: [{ visibility: "on" }]/**/ }, { featureType: "water", elementType: "labels", stylers: [{ visibility: "on" }, { lightness: -25 }, { saturation: -100 }] }, { featureType: "water", elementType: "geometry", stylers: [{ hue: "#ffff00" }, { lightness: -25 }, { saturation: -97 }] }],
    };
    var mapElement = document.getElementById('map-container');
    var map = new google.maps.Map(mapElement, mapOptions);

    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map
    });
}