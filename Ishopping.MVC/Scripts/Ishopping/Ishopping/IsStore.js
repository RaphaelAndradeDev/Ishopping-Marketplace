
// Variaveis Globais
var dataPage;

// Autocomplete ###############################
$(document).ready(function () {
    $("#txtSearch").autocomplete({
        minLength: 3,
        source: function (request, response) {     
                $.ajax({
                    url: '/store/Search',
                    dataType: "json",
                    data: {
                        term: request.term,
                        siteNumber: getAllSiteNumber().toString()
                    },
                    success: function (data) {
                        response(data);
                    }
                });
        },
    });
});

// Retorna resultado das Buscas
$("#btnSearch").on('click', function () {
    var term = $("#txtSearch").val();
    if (term) {
        if (term.length >= 3) {
            window.location = '/store/filter?term=' + term;
        }
    }
});

// Carrregamento da página
$(document).ready(function () {
    var map = null;
    loadDataPage();    
});

function getDataPage(lat, lon) {
    $.ajax({
        type: 'GET',
        url: '/Store/GetDataPage',
        data: { lat: lat, lon: lon },
        dataType: 'html',
        cache: false,
        async: true
    })
    .success(function (result) {
        dataPage = JSON.parse(result);  
        getProductT1(1, true);        
    })
    .error(function (xhr, status) {
        alert(status);
    })
}



function getProductT1(page, stop) {
    $.ajax({
        type: 'GET',
        url: '/Store/GetProductT1',
        data: {
            productId: getProductId(page).toString(),
            page: page,
            lenght: getAllProductId().length
        },
        dataType: 'html',
        cache: false,
        async: true
    })
    .success(function (result) {
        $('#storeProductT1').html(result); 
        if (!stop) location.hash = "storeProductT1"; 
        if (page == 1) {
            getProductT2(getAllSiteNumber(), getCookieCategoryByDate());
            getProductT4(getCookieCategoryByDate());
        }
    })
    .error(function (xhr, status) {
        alert(status);
    })
}

function getProductT2(siteNumber, category) {
    $.ajax({
        type: 'GET',
        url: '/Store/GetProductT2',
        data: { siteNumber: siteNumber.toString(), category: category.toString() },
        dataType: 'html',
        cache: false,
        async: true
    })
    .success(function (result) {
        $('#storeProductT2').html(result); 
        carousel();
    })
    .error(function (xhr, status) {
        alert(status);
    })
}

function getProductT4(category) {
    $.ajax({
        type: 'GET',
        url: '/Store/GetProductT4',
        data: {category: category.toString() },
        dataType: 'html',
        cache: false,
        async: true
    })
    .success(function (result) {
        $('#storeProductT4').html(result);   
    })
    .error(function (xhr, status) {
        alert(status);
    })
}




// Funções
function loadDataPage() {
    var lat = getCookie("lat");
    var lon = getCookie("lon"); 
    if (lat != "" && lon != "") {
        getDataPage(lat, lon);                    
    }
    else {
        getThisLatLong();
    }
}

function getProductId(page) {

    var prodId = getAllProductId();
    var lngt = prodId.length;
    var first = (page * 16) - 16;
    var last = page * 16 > lngt ? lngt : page * 16;

    var result = [];
    for (first; first < last; first++) {
        result.push(prodId[first]);
    }
    return result;
}

function getAllSiteNumber() {

    var siteNumber = [];
    dataPage.BasicDisplay.map(x => siteNumber.push(x.SiteNumber));
    return siteNumber;
}

function getAllProductId() {

    var ProductId = [];
    dataPage.BasicDisplay.map(x => x.ProductDataPage.map(y => ProductId.push(y.Id)));
    return ProductId;
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
            getDataPage(lat, lon);       
        }
    }
}

var text = '{"category":[{"n":"category1", "d":"1529558919580", "a":"180"},{"n":"category2", "d":"1529558919580", "a":"100"}]}';

function setCookieCategory(catg) {
 
    var getCatCookie = function () {
        var cookie = getCookie("sctg");
        if (cookie) {
            return JSON.parse(cookie);
        } else {
            return { "category": [{ "n": catg, "d": Date.now(), "a": "0" }] };
        }
    }

    var obj = getCatCookie();
    function addElement(category) {
        var name = [];
        obj.category.forEach(x => name.push(x.n));
        if (parseInt(name.indexOf(category)) == -1) {
            obj.category.push({ "n": category, "d": Date.now(), "a": "0" });
        }
        return obj;
    }

    function modifyElement(category) {
        if (category.n == catg) {
            category.a = parseInt(category.a) + 1;
            category.d = Date.now();
        }
        return category;
    }

    function ctgStringfy() {
        var ctg = { category: addElement(catg).category.map(modifyElement) }
        return JSON.stringify(ctg);
    }
    setCookie("sctg", ctgStringfy(), 90);
}

function getCookieCategoryByDate() {

    var getCatCookie = function () {
        var cookie = getCookie("sctg");
        if (cookie) {
            return JSON.parse(cookie);
        } else {
            return {
                "category": [               
                    { "n": "00", "d": Date.now(), "a": "0" }]
            };
        }
    }

    var date = [];
    var catg = [];

    var obj = getCatCookie();
    for (i = 0; i < obj.category.length; i++) {
        date.push(parseInt(obj.category[i].d));
    }

    date.sort();
    date.reverse();

    date.forEach(function (d_item, d_index) {
        obj.category.forEach(function (item, index) {
            if (d_item == item.d)
                catg.push(item.n);
        })
    })

    return catg;
}

function getCookieCategoryByAcess() {

    var obj = JSON.parse(getCookie("sctg"));

    var acess = [];
    var catg = [];

    for (i = 0; i < obj.category.length; i++) {
        acess.push(obj.category[i].a);
    }

    acess.sort();
    acess.reverse();

    acess.forEach(function (a_item, a_index) {
        obj.category.forEach(function (item, index) {
            if (a_item == item.a)
                catg.push(item.n);
        })
    })
    return catg;
}









function carousel() {
    // initialization of carousel
    $.HSCore.components.HSCarousel.init('[class*="js-carousel"]');

    $('#carouselCus1').slick('setOption', 'responsive', [{
        breakpoint: 1200,
        settings: {
            slidesToShow: 4
        }
    }, {
        breakpoint: 992,
        settings: {
            slidesToShow: 3
        }
    }, {
        breakpoint: 768,
        settings: {
            slidesToShow: 2
        }
    }], true);
};






