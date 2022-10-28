

$(document).ready(function () {
    var map = null;
    loadLatLon();
});

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

function getResult(lat, lon) {
    $.ajax({
        type: 'GET',
        url: $('#profiles').data('urlcontroller'),        
        data: { lat: lat, lon: lon },        
        dataType: 'html',
        cache: false,
        async: true
    })
    .success(function (result) {
        $('#image').html(result);
    })
    .error(function (xhr, status) {
    })
}


// ESSAS FUNÇÕES FORAM SEPARADAS E ESTÃO ISCOOKIE
//function setCookie(cname, cvalue, exdays) {
//    var d = new Date();
//    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
//    var expires = "expires=" + d.toUTCString();
//    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
//}

//function getCookie(cname) {
//    var name = cname + "=";
//    var ca = document.cookie.split(';');
//    for (var i = 0; i < ca.length; i++) {
//        var c = ca[i];
//        while (c.charAt(0) == ' ') {
//            c = c.substring(1);
//        }
//        if (c.indexOf(name) == 0) {
//            return c.substring(name.length, c.length);
//        }
//    }
//    return "";
//}



