
// Variaveis Globais
var dataPage;
var param = { getAll: false, term: "", category: [0], subCategory: [0], brand: [""], priceMin: 0, priceMax: 99999, sortBy: 3 };

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
    resetParam();
    getAllByTerm($("#txtSearch").val());
});

// Carrregamento da página
$(document).ready(function () {
    var map = null;
    loadDataPage();

    $(document).on("click", "[name='checkSubCat']", function () {

        param.subCategory = [];  
        $("input:checkbox[name=checkSubCat]:checked").each(function () {
            param.subCategory.push($(this).val());     
        });

        if (param.subCategory.length == 0)
            param.subCategory.push(0);  
    });

    $(document).on("click", "[name='checkBrand']", function () {

        param.brand = [];
        $("input:checkbox[name=checkBrand]:checked").each(function () {
            param.brand.push($(this).val());
        }); 

        if (param.brand.length == 0)
            param.brand.push(""); 
    });   

    $(document).on("click", "#btnFilter", function () {
        param.priceMin = $.isNumeric($('#priceMin').val()) ? $('#priceMin').val() : 0;
        param.priceMax = $.isNumeric($('#priceMax').val()) ? $('#priceMax').val() : 99999;
        getProductT3(1);
    });

    $(document).on("click", "#btnReset", function () {
        $('#txtSearch').val("");
        resetParam(); 
        getAll();
    });

    $(document).on("click", "[name='sortBy']", function () {
        var str = $(this).text();
        param.sortBy = parseInt($(this).attr('id'));
        $(this).parents('.btn-group').find('[type="button"]').html(str); 
        getProductT3(1);
    });

});

function getDataPage(lat, lon) {

    param.term = $('#param').data('term');
    param.category[0] = $('#param').data('category');
    param.subCategory[0] = $('#param').data('subcategory');

    $.ajax({
        type: 'GET',
        url: '/Store/GetDataPage',
        data: {
            lat: lat,
            lon: lon,
            storeFilter: JSON.stringify(param)         
        },
        dataType: 'html',
        cache: false,
        async: true
    })
    .success(function (result) {
        dataPage = JSON.parse(result);  
        getProductT3(1, true);   
        getFilterT1();
    })
    .error(function (xhr, status) {
        alert(status);
    })
}

function getDataPageByParam() {
    $.ajax({
        type: 'POST',
        url: '/Store/GetDataPageByParameters',
        data: {         
            dataPage: JSON.stringify(dataPage.BasicDisplay),
            storeFilter: JSON.stringify(param) 
        },
        dataType: 'html',
        cache: false,
        async: true
    })
    .success(function (result) {
        dataPage = JSON.parse(result);
        getProductT3(1, true);
        getFilterT1();
    })
    .error(function (xhr, status) {
        alert(status);
    })
}

function getFilterT1() {
    $.ajax({
        type: 'POST',
        url: '/Store/LoadPartialPageFilter',
        data: {
            dataFilter: JSON.stringify(getAllDataFilter())
        },
        dataType: 'html',
        cache: false,
        async: true
    })
    .success(function (result) {
        $('#storeFilterT1').html(result);  
        // initialization of range slider
        $.HSCore.components.HSSlider.init('#rangeSlider1');       
    })
    .error(function (xhr, status) {
        alert(status);
    })
}

function getProductT3(page, top) {
    $.ajax({
        type: 'POST',
        url: '/Store/GetProductT3',
        data: {
            productId: getProductId(page).toString(),
            page: page,
            lenght: getIdByFilter().length,
            sortBy: param.sortBy
        },
        dataType: 'html',
        cache: false,
        async: true
    })
    .success(function (result) {
        $('#storeProductT3').html(result); 
        if (!top) location.hash = "_storeProduct";
    })
    .error(function (xhr, status) {
        alert(status);
    })
}

// Filtros
function getAll() {
    resetFilter(); 
    getDataPageByParam();
}

function getAllByTerm(term) {   
    if (term) {
        if (term.length >= 3) {
            resetParam();
            param.term = term;           
            getDataPageByParam();
        }
    }    
}

function getAllByCategory(category) {
    resetFilter()    
    param.category[0] = category;
    setCookieCategory(category)
    getDataPageByParam();
}

// Funções
function getIdByFilter() {

    var element = [];

    if (param.category.indexOf(0) == -1)
        element.push('CategoryId:[' + param.category.toString() + ']');

    if (param.subCategory.indexOf(0) == -1)
        element.push('SubCategoryId:[' + param.subCategory.toString() + ']');

    if (param.brand.indexOf("") == -1)
        element.push('Brand:["' + param.brand.join('","') + '"]');    

    eval('var filterBy=' + "{" + element.join() + "}");

    var result = getAllDataFilter().filter(o => Object.keys(filterBy).every(k => filterBy[k].some(f => o[k] === f)) && o.Price >= param.priceMin && o.Price <= param.priceMax);

    switch (param.sortBy) {
        case 1:
            return sortyByLowPrice(result);
            break;
        case 2:
            return sortyByHighPrice(result);
            break;
        case 3:
            return sortyByLowRadius(result);
            break;
        case 4:
            return sortyByHighRaius(result);       
    }
}

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

    var prodId = getIdByFilter();
    var lngt = prodId.length;
    var first = (page * 12) - 12;
    var last = page * 12 > lngt ? lngt : page * 12;

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

function getAllDataFilter() {
    var dataFilter = [];
    dataPage.BasicDisplay.map(x => x.ProductDataFilter.map(y => dataFilter.push(y)));
    return dataFilter;
}

function sortyByLowPrice(productDataFilter) {
    productDataFilter.sort(function (a, b) {
        if (a.Price > b.Price) {
            return 1;
        }
        if (a.Price < b.Price) {
            return -1;
        }
        return 0;
    });
    return productDataFilter.map(x => x.Id);
}

function sortyByHighPrice(productDataFilter) {
    productDataFilter.sort(function (a, b) {
        if (a.Price < b.Price) {
            return 1;
        }
        if (a.Price > b.Price) {
            return -1;
        }
        return 0;
    });
    return productDataFilter.map(x => x.Id);
}

function sortyByLowRadius(productDataFilter) {
    productDataFilter.sort(function (a, b) {
        if (a.Radius > b.Radius) {
            return 1;
        }
        if (a.Radius < b.Radius) {
            return -1;
        }
        return 0;
    });
    return productDataFilter.map(x => x.Id);
}

function sortyByHighRaius(productDataFilter) {
    productDataFilter.sort(function (a, b) {
        if (a.Radius < b.Radius) {
            return 1;
        }
        if (a.Radius > b.Radius) {
            return -1;
        }
        return 0;
    });
    return productDataFilter.map(x => x.Id);
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

function resetParam() {
    param.getAll = true;
    param.term = "";
    param.category = [0];
    param.subCategory = [0];
    param.brand = [""];
    param.priceMin = 0;
    param.priceMax = 99999;
}

function resetFilter() {
    param.getAll = false;  
    param.category = [0];
    param.subCategory = [0];
    param.brand = [""];
    param.priceMin = 0;
    param.priceMax = 99999;
}

function clearDataPage() {
    dataPage.BasicDisplay.map(x => x.ProductDataPage = [], x.ProductDataFilter = []);
}














