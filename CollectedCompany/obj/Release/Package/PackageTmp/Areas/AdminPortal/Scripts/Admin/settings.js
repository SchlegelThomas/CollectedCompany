
$(function () {
    $(document).ready(function () {








        $(document).on('change', '#State', function() {
            var self = $(this);
            var state = $(self).val();
            $.makeAjaxGet('/CityState/GetCities?stateAbbreviation=' + state, null).then(function (response) {
                
                if (response.Success) {
                    $('#City').empty();
                    $.each(response.Data, function (key, value) {
                        if (value) {
                            $('#City')
                                .append($("<option></option>")
                                    .attr("value", value.Name)
                                    .text(value.Name));
                        }
                    });
                }
            });

        });

        $(document).on('change', '#State1', function () {
            var self = $(this);
            var state = $(self).val();
            $.makeAjaxGet('/CityState/GetCities?stateAbbreviation=' + state, null).then(function (response) {

                if (response.Success) {
                    $('#City1').empty();
                    $.each(response.Data, function (key, value) {
                        if (value) {
                            $('#City1')
                                .append($("<option></option>")
                                    .attr("value", value.Name)
                                    .text(value.Name));
                        }
                    });
                }
            });

        });


        $.makeAjaxGet('/CityState/GetStates', null).then(function(response) {
            if (response.Success) {
                $('#State').empty();
                $.each(response.Data, function(key, value) {
                    if (value) {
                        $('#State')
                            .append($("<option></option>")
                                .attr("value", value.Abbreviation)
                                .text(value.Name));
                        $('#State1')
                            .append($("<option></option>")
                                .attr("value", value.Abbreviation)
                                .text(value.Name));
                    }
                });
            }
        });

    });

});