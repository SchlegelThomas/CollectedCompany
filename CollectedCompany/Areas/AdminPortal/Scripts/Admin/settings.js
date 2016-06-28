
$(function () {

    function buildStoreAddressModel() {
        var model = {
            LegalNameOfBusiness: $('#BusinessName').val(),
            PhoneNumber: $('#Phone').val(),
            Street: $('#Street').val(),
            Street2: $('#Street2').val(),
            City: $('#City').val(),
            Zip: $('#Zip').val(),
            Country: '',
            State: $('#State').val(),
            Email: $('#CustomerEmail').val(),
            Id: $('#StoreAddressId').val()
        };

        return model;
    };

    function buildStoreFrontModel() {
        var model = {
            LogoImageUrl: '',
            BusinessName: $('#LegalBusinessName').val(),
            FavIconUrl: '',
            ContactEmail: $('#ContactEmail').val(),
            Address: $('#Address').val(),
            Address2: $('#Address2').val(),
            State: $('#State1').val(),
            City: $('#City1').val(),
            Zip: $('#Zip1').val(),
            ContactPhone: $('#ContactPhone').val(),
            TimeZoneId: '',
            Id: $('#StorefrontId').val(),
            StoreAddress: buildStoreAddressModel()
        };

        return model;
    };

    $(document).ready(function () {

       


        $(document).on('click', '#SaveStoreFront', function () {
            var model = buildStoreFrontModel();
            var settingsId = $('#SettingsId').val();

            $.makeAjaxPost('/AdminPortal/AdminSettings/SaveStorefrontSettings?settingsId=' + encodeURIComponent(settingsId), model).then(function (response) {
                if (response.Success) {
                    toastr.success('Save Successful', 'General Settings');
                } else {
                    toastr.error('An Admin has been notified.', 'Something went wrong : (');
                }
            });

        });


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