$(document).ready(function () {
    $.ajaxSetup({ cache: false });
});

jQuery.makeAjaxGet = function(url, data) {
    var r = $.Deferred();


    $.ajax({
        type: "GET",
        url: url,
        data: data,
        dataType: "json",
        traditional: true,
        success: function (response) {
            r.resolve(response);
        },
        error: function (jqXhr, textStatus, errorThrown) {
            r.resolve(textStatus);
        }
    });

    return r;
};

jQuery.makeAjaxPost = function(url, data) {
    var r = $.Deferred();


    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(data),
        dataType: "json",
        contentType: 'application/json',
        success: function (response) {
            r.resolve(response);
        },
        error: function (jqXhr, textStatus, errorThrown) {
            r.resolve(textStatus);
        }
    });

    return r;
};

jQuery.makeAjaxDelete = function(url, data) {
    var r = $.Deferred();


    $.ajax({
        type: "DELETE",
        url: url,
        data: data,
        traditional: true,
        success: function (response) {
            r.resolve(response);
        },
        error: function (jqXhr, textStatus, errorThrown) {
            r.resolve(textStatus);
        }
    });

    return r;

};