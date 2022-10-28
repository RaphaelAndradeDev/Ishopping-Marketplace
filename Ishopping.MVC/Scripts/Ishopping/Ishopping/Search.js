
$(function () {
    $("#txtSearchBySemantic").autocomplete({
        minLength: 3,
        source: function (request, response) {
            var value = $("#txtSearchBySemantic").val();
            if (isNaN(value)) {
                $.getJSON('/Home/SearchBySemantic', request, function (data, status, xhr) {
                    response(data);
                });
            }
            else {
                $.getJSON('/Home/SearchSpecific', request, function (data, status, xhr) {
                    response(data);
                });
            }
        }
    });
});

$(function () {
    $("#txtSearchByAddress").autocomplete({
        minLength: 2,
        source: function (request, response) {
            var value = $("#txtSearchByAddress").val();
            if (isNaN(value)) {
                $.getJSON('/Home/SearchByAddress', request, function (data, status, xhr) {
                    response(data);
                });
            }
            else {
                $.getJSON('/Home/SearchSpecificAd', request, function (data, status, xhr) {
                    response(data);
                });
            }
        }
    });
});


$("#getBySearch").on('click', function () {

    var action = "/Home/GetBySearch";
    var sm = $("#txtSearchBySemantic").val();
    var ad = $("#txtSearchByAddress").val();

    if (!(isNaN(sm) || isNaN(ad))) {
        if (sm.length >= 4 || ad.length >= 4) {
            action = '/Home/GetSpecific';
        }
    }

    if (sm || ad) {
        $.ajax({
            url: action,
            contentType: 'application/html; charset=utf-8',
            data: {
                semantic: sm,
                address: ad
            },
            type: 'GET',
            dataType: 'html'
        })
        .success(function (result) {
            $('#image').html(result);
        })
        .error(function (xhr, status) { })
    }
    else {
        getThisLatLong();
    }
});