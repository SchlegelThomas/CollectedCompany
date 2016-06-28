$(function () {


    $(document).ready(function () {

       
        $(document).on('click', '#Save', function () {
            var themeName = $('#Theme').val();
            var formData = new FormData();
            var blob = $('#ThemeImage')[0].files[0];
            formData.append('file', blob);

            $.ajax('/AdminPortal/Secret/UploadThemePicture?themeName=' + themeName, {
                method: "POST",
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    toastr.success('Image Updated', 'General Settings');
                },
                error: function () {

                }
            });

        });

    });







});