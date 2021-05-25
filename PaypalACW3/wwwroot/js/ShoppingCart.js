function Add(_food, _price) {
    // Stops unneeded calls to UpdateProgression when pageProgress has not been implemented
    $.ajax({
        url: '/Add',
        type: 'POST',
        async: false,
        dataType: 'JSON',
        data: {
            food: _food,
            price: _price
        },
        cache: false,
        success: function (data) {
            GetCount();
        }
    });
}

function GetCount() {
    var cartCount = 0;
    $.ajax({
        url: '/CartCount',
        type: 'GET',
        async: false,
        dataType: 'JSON',
        cache: false,
        success: function (data) {
            cartCount = data.count;
        }
    });
    return cartCount;
}