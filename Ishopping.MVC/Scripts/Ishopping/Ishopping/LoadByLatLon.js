

$(document).ready(function () {
    var map = null;
    loadLatLon();
});

$(window).on("load", function () {
    $(".title").each(function () {
        var lat = $(this).data("lat");
        var lon = $(this).data("lon");
        var name = $(this).data("title");        
        addMarker(lat, lon, name);    
    })
    inicializemap();
})

function getResult(lat, lon) {
    $.ajax({
        url: '/Home/GetResult',
        contentType: 'application/html; charset=utf-8',
        data: { lat: lat, lon: lon },
        type: 'GET',
        dataType: 'html'
    })
    .success(function (result) {
        $('#image').html(result);
    })
    .error(function (xhr, status) {        
    })
}

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function loadLatLon() {
    var lat = getCookie("lat");
    var lon = getCookie("lon");
    if (lat != "" && lon != "") {
        getResult(lat, lon);        
    } else {
        getThisLatLong();
    }
}

function getThisLatLong() {
    var divMapa = document.getElementById('mapa');
    navigator.geolocation.getCurrentPosition(fn_ok, fn_mal);
    function fn_mal() { }
    function fn_ok(rta) {
        var lat = rta.coords.latitude.toPrecision(9);
        var lon = rta.coords.longitude.toPrecision(9);
        if (lat != "" && lat != null) {
            setCookie("lat", lat, 365);
            setCookie("lon", lon, 365);
            getResult(lat, lon);
        }
    }
}

function maplocation(lat, lon, name) {
    this.lat = lat;
    this.lon = lon;
    this.name = name;
}

var markers = [];
function addMarker(lat, lon, name) {
    var marker = new maplocation(lat, lon, name);
    markers.push(marker);
}


function inicializemap() {

    var latitude = getCookie("lat");
    var longitude = getCookie("lon");

    var image = new google.maps.MarkerImage('../../Componentes/Professional/Patros/images/marker.png', new google.maps.Size(84, 56), new google.maps.Point(0, 0), new google.maps.Point(42, 56));
    var mapCoordinates = new google.maps.LatLng(latitude, longitude);
    var mapOptions = {
        backgroundColor: '#ffffff',
        zoom: 15,
        disableDefaultUI: true,
        center: mapCoordinates,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        scrollwheel: true,
        draggable: true,
        zoomControl: true,
        disableDoubleClickZoom: true,
        mapTypeControl: false
    };

    map = new google.maps.Map(document.getElementById('map-canvas-holder'), mapOptions);

    var my = new google.maps.LatLng(latitude, longitude);    
    marker = new google.maps.Marker({ position: my, raiseOnDrag: false, icon: image, map: map, draggable: false, title: 'Eu' });
       
    for (var i = 0; i < markers.length; i++) {        
        var egglabs = new google.maps.LatLng(markers[i].lat, markers[i].lon);    
        marker = new google.maps.Marker({ position: egglabs, raiseOnDrag: false, map: map, title: markers[i].name });
    }

    google.maps.event.addListener(map, 'zoom_changed', function () {
        var center = map.getCenter();
        google.maps.event.trigger(map, 'resize');
        map.setCenter(center);
    });
}