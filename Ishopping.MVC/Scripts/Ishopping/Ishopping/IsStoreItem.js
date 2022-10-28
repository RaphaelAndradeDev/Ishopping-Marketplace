
// Variaveis Globais
var prodId;

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
            window.location = '/store/Item?term=' + term;
        }
    }
});

// Carrregamento da página
$(document).ready(function () {
    var map = null;
    getListProductId();    
});

function getListProductId() {

    $.ajax({
        type: 'GET',
        url: '/Store/GetListProductId',
        data: { siteNumber: $('#siteNumber').data('sitenumber')},
        dataType: 'html',
        cache: false,
        async: true
    })
    .success(function (result) {
        prodId = JSON.parse(result);  
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
            lenght: prodId.length
        },
        dataType: 'html',
        cache: false,
        async: true
    })
    .success(function (result) {
        $('#storeProductT1').html(result); 
        if (!stop) location.hash = "storeProductT1";      
    })
    .error(function (xhr, status) {
        alert(status);
    })
}


// Funções
function getProductId(page) { 
    var lngt = prodId.length;
    var first = (page * 12) - 12;
    var last = page * 12 > lngt ? lngt : page * 12;

    var result = [];
    for (first; first < last; first++) {
        result.push(prodId[first]);
    }
    return result;
}










