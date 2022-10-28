
function getByCategory(category) {
    $.ajax({
        type: 'GET',
        url: '/Portfolio/GetByCategory',
        data: { category: category },
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

function getByTag(tag) {
    $.ajax({
        type: 'GET',
        url: '/Portfolio/GetByTag',
        data: { tag: tag },
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


